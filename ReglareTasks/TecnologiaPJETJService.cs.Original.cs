using AutoMapper;
using CapturaDadosProcesso.Core.Entidades;
using CapturaDadosProcesso.Core.Enumeradores;
using CapturaDadosProcesso.Facade.Services.Interfaces;
using log4net;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CapturaDadosProcesso.Facade.Models.SolicitacoesCopia;
using CapturaDadosProcesso.Facade.Models;
using System.IO;
using CapturaDadosProcesso.Facade.Models.TecnologiaSite;

namespace CapturaDadosProcesso.Facade.Services
{
    public class TecnologiaPJETJService : ITecnologiaPJETJService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IMapper _mapper;
        private readonly ISession _session;
        private readonly IEmailService _emailService;
        private readonly ICertificadoDigitalService _certificadoDigitalService;
        private readonly IGerenciarFisicoService _gerenciarFisicoService;
        private readonly IBrowserService _browserService;
        private readonly ILoginCertificadoDigitalService _loginCertificadoDigital;
        private readonly ICommonService _commonService;
        private readonly IParametrosService _parametrosService;

        public TecnologiaPJETJService(ISession session,
                                      IMapper mapper,
                                      IEmailService emailService,
                                      ICertificadoDigitalService certificadoDigitalService,
                                      IGerenciarFisicoService gerenciarFisicoService,
                                      IBrowserService browserService,
                                      ILoginCertificadoDigitalService loginCertificadoDigital,
                                      ICommonService commonService,
                                      IParametrosService parametrosService)
        {
            _session = session;
            _mapper = mapper;
            _emailService = emailService;
            _certificadoDigitalService = certificadoDigitalService;
            _gerenciarFisicoService = gerenciarFisicoService;
            _browserService = browserService;
            _loginCertificadoDigital = loginCertificadoDigital;
            _commonService = commonService;
            _parametrosService = parametrosService;
        }

        public DadosLoginModel LogarSite(EquipamentoProcessamentoTribunal configuracao, string folderBase, string macAddr, int taskId, bool baixarCopia, String numeroProcesso, InstanciaTribunal instanciaTribunal)
        {
            DadosLoginModel retorno = new DadosLoginModel();

            try
            {
                string usuarioInstancia = "";
                string pwdInstancia = "";
                retorno.Sucesso = true;

                //============================================================================
                // Identifica a Pagina de Login
                //============================================================================
                Console.WriteLine("Pagina Login");
                string paginaLogin = $"{instanciaTribunal.URL}";
                if (configuracao.Tribunal.Sigla != "TJMG")
                    paginaLogin = $"{paginaLogin}/login.seam";
                //============================================================================


                //============================================================================
                // Identifica a Primeira Instancia
                //============================================================================
                Console.WriteLine("Identifica a Instancia");
                retorno.PrimeiraInstancia = instanciaTribunal;
                //============================================================================


                //============================================================================
                // Identifica se Precisa criar a Pasta Base para Baixa Copias
                //============================================================================
                Console.WriteLine("Pasta Base para Baixa Copias");
                string folderProcessamento = "";
                if (baixarCopia)
                    folderProcessamento = _gerenciarFisicoService.CriarDiretorioProcessamento(folderBase, macAddr, System.Convert.ToInt16(taskId));
                retorno.FolderProcessamento = folderProcessamento;
                //============================================================================


                //============================================================================
                // Identifica se Precisa Exibir o Navegador
                //============================================================================
                bool exibirNavegador = false;
                var parametroExibirNavegador = _commonService.ParametroEquipamento("Exibir Navegador", configuracao.EquipamentoProcessamento.Id);
                if (!string.IsNullOrWhiteSpace(parametroExibirNavegador) && parametroExibirNavegador.ToUpper() == "SIM")
                    exibirNavegador = true;
                //============================================================================

                //============================================================================
                // Abre a Pagina Inicial do Tribunal no Firefox
                //============================================================================
                Console.WriteLine("Abre a Pagina Inicial do Tribunal no Firefox");
                IWebDriver driver = _commonService.AbrePaginaInicial(paginaLogin, folderProcessamento, instanciaTribunal.NavegadorWeb, configuracao.EquipamentoProcessamento.Id, instanciaTribunal.VersaoNavegadorWeb, "", exibirNavegador);
                if (driver == null)
                {
                    retorno.Sucesso = false;
                    retorno.MenssagemErro = "Não foi possível abrir a pagina inicial.";
                    return retorno;
                }
                WebDriverWait navegador = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                retorno.Driver = driver;
                //============================================================================


                //============================================================================
                //Identifica o Usuario de Acesso a Instancia do Site
                //============================================================================
                UsuarioAcesso usuarioAcesso = _commonService.UsuarioAcesso(configuracao.Tribunal.Id, instanciaTribunal.Id, 0);
                if (usuarioAcesso != null)
                {
                    usuarioInstancia = usuarioAcesso.User;
                    pwdInstancia = usuarioAcesso.PWD;
                }
                //============================================================================

                //============================================================================
                // Faz o Login no site
                //============================================================================
                List<WebElementModel> objetosLogin = new List<WebElementModel>();
                objetosLogin.Add(new WebElementModel() { identificador = "Id", idElemento = "btnEntrar", action = "ElementToBeClickable", tipoObjeto = "BotaoEnviar", timeout = new TimeSpan(0, 0, 15) });
                objetosLogin.Add(new WebElementModel() { identificador = "Id", idElemento = "username", action = "ElementToBeClickable", tipoObjeto = "InputUsuario", timeout = new TimeSpan(0, 0, 15) });
                objetosLogin.Add(new WebElementModel() { identificador = "Id", idElemento = "password", action = "ElementToBeClickable", tipoObjeto = "InputPWD", timeout = new TimeSpan(0, 0, 15) });
                objetosLogin.Add(new WebElementModel() { identificador = "Id", idElemento = "menu", action = "ElementToBeClickable", tipoObjeto = "InputNumeroProcesso", timeout = new TimeSpan(0, 0, 15), sequencia = 0 });
                objetosLogin.Add(new WebElementModel() { identificador = "Id", idElemento = "recaptcha-verify-button", action = "ElementToBeClickable", tipoObjeto = "InputNumeroProcesso", timeout = new TimeSpan(0, 0, 15), sequencia = 1 });
                if (!_commonService.Login(driver, navegador, usuarioInstancia, pwdInstancia, objetosLogin, false))
                {
                    retorno.Sucesso = false;
                    retorno.MenssagemErro = "Não foi possível logar no Tribunal.";

                    driver.Close();
                    driver.Dispose();
                    return retorno;
                }


                //===============================================================================
                // Verifica se montou tela do ReCaptcha v3
                //===============================================================================
                //List<WebElementModel> objetosCaptcha = new List<WebElementModel>();
                //objetosCaptcha.Add(new WebElementModel() { identificador = "ClassName", idElemento = "g-recaptcha", action = "ElementIsVisible", tipoObjeto = "Frame", timeout = new TimeSpan(0, 0, 15) });
                //if (_commonService.MontouReCaptchaV2(navegador, objetosCaptcha))
                //{
                //    objetosCaptcha.Add(new WebElementModel() { identificador = "Id", idElemento = "g-recaptcha-response", action = "ElementExists", tipoObjeto = "textArea", timeout = new TimeSpan(0, 0, 15) });
                //    objetosCaptcha.Add(new WebElementModel() { identificador = "Id", idElemento = "btenviar", action = "ElementIsVisible", tipoObjeto = "btnEnviar", timeout = new TimeSpan(0, 0, 15) });
                //    objetosCaptcha.Add(new WebElementModel() { identificador = "ClassName", idElemento = "gcaptcha", action = "ElementExists", tipoObjeto = "divGcaptcha", timeout = new TimeSpan(0, 0, 15) });
                //    objetosCaptcha.Add(new WebElementModel() { identificador = "Name", idElemento = "usuario", action = "ElementToBeClickable", tipoObjeto = "elementoProsseguir", timeout = new TimeSpan(0, 0, 15) });

                //    //Informações para o TRT3
                //    objetosCaptcha.Add(new WebElementModel() { identificador = "Id", idElemento = "capt2", action = "ElementExists", tipoObjeto = "formGcaptcha", timeout = new TimeSpan(0, 0, 15) });
                //    objetosCaptcha.Add(new WebElementModel() { identificador = "Id", idElemento = "postCommentSubmit", action = "ElementToBeClickable", tipoObjeto = "btnEnviarAlternativo", timeout = new TimeSpan(0, 0, 15) });
                //    objetosCaptcha.Add(new WebElementModel() { identificador = "Id", idElemento = "pesquisaForm", action = "ElementToBeClickable", tipoObjeto = "elementoProsseguirAlternativo", timeout = new TimeSpan(0, 0, 15) });

                //    if (!_commonService.ResolverReCaptchaV2(driver, navegador, objetosCaptcha, paginaLogin))
                //    {
                //        retorno.Sucesso = false;
                //        retorno.MenssagemErro = "Não foi possível resolver o Recaptcha.";

                //        driver.Close();
                //        driver.Dispose();
                //        return retorno;
                //    }
                //}


                System.Threading.Thread.Sleep(200);
                //============================================================================




            }
            catch (Exception ex)
            {
                retorno.Sucesso = false;
                retorno.MenssagemErro = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return retorno;
        }




        public DadosLoginModel Capturar(DadosLoginModel dadosLoginModel, List<ProcessoModel> processos, EquipamentoProcessamentoTribunal configuracao, Usuario login, string folderBase, string macAddr, int taskId, int quantidadeMaxinaNaoLocalizado)
        {
            bool atualizar = false;

            //====================================================================================
            //Monta a Lista de Qualidicação das Partes
            //====================================================================================
            List<string> partesAtiva = new List<string>();
            List<string> partesPassiva = new List<string>();

            if (processos.Any(p => p.CapturarPartes))
            {
                partesAtiva = _commonService.ListarQualificacaoPartes("Parte Ativa");
                partesPassiva = _commonService.ListarQualificacaoPartes("Parte Passiva");
            }
            //====================================================================================


            //====================================================================================
            //Faz Loop nas instancias do tribunal
            //====================================================================================
            var instancias = configuracao.Tribunal.Instancias.Where(i => i.Situacao == SituacaoInstancia.Implementado && i.Tecnologia.Id == configuracao.Tecnologia.Id);

            foreach (var instancia in instancias.OrderBy(i => i.SequenciaProcessamento))
            {
                var solicitacoesProcessar = processos.Where(p => p.IdTecnologiaSite == configuracao.Tecnologia.Id &&
                                                                (p.Status == StatusProcesso.EmProcessamento || p.Status == StatusProcesso.Pendente))
                                                      .Select(p => p.IdSolicitacao).Distinct();


                if (dadosLoginModel.Driver == null)
                {
                    bool baixarCopia = false;
                    if (processos.Where(p => p.BaixarCopia).Count() > 0)
                        baixarCopia = true;

                    dadosLoginModel = LogarSite(configuracao, folderBase, macAddr, taskId, baixarCopia, processos.FirstOrDefault().Numero, instancia);
                    dadosLoginModel.FecharBrowser = true;
                }


                if (!dadosLoginModel.Sucesso)
                {
                    if (dadosLoginModel.MenssagemErro == "Não foi possível logar no Tribunal.")
                    {
                        foreach (var processoInconsistente in processos.Where(p => !p.ProcessoDistribuido))
                            atualizar = _commonService.AtualizarSituacaoProcesso(processoInconsistente.Id, login, dadosLoginModel.PrimeiraInstancia, StatusProcesso.Inconsistente, "Não foi possível logar no Tribunal.", true);
                    }
                    dadosLoginModel.Sucesso = false;
                    dadosLoginModel.MenssagemErro = "Não foi possível logar no Tribunal.";
                    return dadosLoginModel;
                }

                foreach (var solicitacaoProcessar in solicitacoesProcessar)
                {
                    var solicitacao = _session.Query<SolicitacaoCaptura>().FirstOrDefault(p => p.Id == solicitacaoProcessar);
                    if (solicitacao == null)
                        throw new ApplicationException("Solicitação não Localizada");

                    if (solicitacao.Status == StatusSolicitacaoCaptura.LiberadoProcessamento)
                    {
                        solicitacao.AlterarStatusParaEmProcessamento(login);
                        using (var transaction = _session.BeginTransaction())
                        {
                            _session.SaveOrUpdate(solicitacao);
                            transaction.Commit();
                        }
                    }

                    TipoNomeExterno tipoNomeExterno = TipoNomeExterno.NumeroProcesso;

                    //====================================================================================
                    // Carrega Advogados Se Precisar Validar
                    //====================================================================================
                    List<string> advogados = new List<string>();
                    if (solicitacao.VerificarAdvogado)
                        advogados = _commonService.ListarAdvogados(solicitacao.CriadoPor.Id);
                    //====================================================================================


                    var processosAProcessar = _mapper.Map<List<ProcessoModel>>(processos.Where(p => p.IdSolicitacao == solicitacaoProcessar && p.IdTecnologiaSite == configuracao.Tecnologia.Id && (p.Status == StatusProcesso.EmProcessamento || p.Status == StatusProcesso.Pendente)).ToList());
                    atualizar = false;

                    foreach (var processoAProcessar in processosAProcessar)
                    {
                        atualizar = _commonService.AtualizarSituacaoProcesso(processoAProcessar.Id, login, dadosLoginModel.PrimeiraInstancia, StatusProcesso.EmProcessamento, "", true);

                        ProcessoModel processoProcessado = ProcessarInstancia(dadosLoginModel.Driver, processoAProcessar, $"{instancia.URL}", login, folderBase, dadosLoginModel.FolderProcessamento, instancia.Descricao, tipoNomeExterno, partesAtiva, partesPassiva, instancia.Tribunal.UF.Sigla);

                        if (processoProcessado.Status != StatusProcesso.EmProcessamento && processoProcessado.Status != StatusProcesso.Pendente)
                        {
                            atualizar = _commonService.AtualizarSituacaoProcesso(processoAProcessar.Id, login, dadosLoginModel.PrimeiraInstancia, processoProcessado.Status, processoProcessado.Inconsistencia, true);
                            if (processoProcessado.Status == StatusProcesso.Capturado)
                            {
                                if (processoProcessado.CapturarDado)
                                {
                                    atualizar = AtualizarDadosProcesso(processoProcessado.Id, processoProcessado.DadosProcesso);

                                    //==========================================================
                                    // Verifica se Advogado da parte é do Solicitador
                                    //==========================================================
                                    if (solicitacao.VerificarAdvogado)
                                        ValidarAdvogado(processoProcessado.Partes, advogados);

                                    atualizar = AtualizarDadosParte(processoProcessado.Id, processoProcessado.Partes, login);
                                }

                                if (processoProcessado.CapturarMovimento)
                                {
                                    atualizar = AtualizarMovimentos(processoProcessado.Movimentos, processoProcessado.Numero, login);
                                    atualizar = AtualizarEventoCapturado(processoProcessado.Id, processoProcessado);
                                }
                            }

                            var processoModel = processos.FirstOrDefault(pm => pm.Id == processoAProcessar.Id);
                            if (processoModel != null)
                                processoModel.Status = processoAProcessar.Status;
                        }

                    }
                }
                //Faz Logout no sistema
                dadosLoginModel.Driver = _browserService.AbrePagina(dadosLoginModel.Driver, $"{instancia.URL}logout.seam");

                //Finaliza o Browser
                dadosLoginModel.Driver.Close();
                dadosLoginModel.Driver.Dispose();

                dadosLoginModel.Driver = null;
            }

            //====================================================================================
            // Atualiza os não localizados
            //====================================================================================
            foreach (var processo in processos.Where(p => p.Status == StatusProcesso.EmProcessamento))
            {
                atualizar = _commonService.AtualizarSituacaoProcesso(processo.Id, login, dadosLoginModel.PrimeiraInstancia, StatusProcesso.NaoLocalizado, "Processo não Localizado.", true);
            }
            //====================================================================================

            //====================================================================================
            // Atualiza Situação das Solicitaçoes
            //====================================================================================
            var solicitacoesProcessadas = processos.Select(p => p.IdSolicitacao).Distinct();
            foreach (var solicitacaoProcessada in solicitacoesProcessadas)
            {
                var solicitacao = _session.Query<SolicitacaoCaptura>().FirstOrDefault(p => p.Id == solicitacaoProcessada);
                if (solicitacao != null)
                {
                    if (solicitacao.Processos.Where(x => x.Status == StatusProcesso.Pendente || x.Status == StatusProcesso.EmProcessamento).Count() == 0)
                    {
                        if (solicitacao.Processos.Where(x => x.Status == StatusProcesso.NaoLocalizado || x.Status == StatusProcesso.Inconsistente).Count() > 0)
                            solicitacao.AlterarStatusParaCapturadoComInconsistencia(login);
                        else
                            solicitacao.AlterarStatusParaCapturadoComSucesso(login);

                        using (var transaction = _session.BeginTransaction())
                        {
                            _session.SaveOrUpdate(solicitacao);
                            transaction.Commit();
                        }
                    }
                }
            }
            return dadosLoginModel;
        }

        public ProcessoModel ProcessarInstancia(IWebDriver driver, ProcessoModel processo, string URL, Usuario login, string folderSolicitacao, string folderProcessamento, string instancia, TipoNomeExterno tipoNomeExterno, List<string> partesAtiva, List<string> partesPassiva, string ufTribunal)
        {
            //Abre a pagina de pesquisa dos Processos
            WebDriverWait navegador = AbrePaginaPesquisaProcesso(driver, $"{URL}Processo/ConsultaProcesso/listView.seam");

            if (navegador != null)
            {
                //Pesquisa as infomrações dos Processos
                IWebDriver janelaProcesso = PesquisarProcesso(driver, navegador, processo.Numero);
                if (janelaProcesso != null)
                {
                    processo.Status = StatusProcesso.Capturado;
                    if (processo.CapturarDado)
                    {
                        processo.DadosProcesso = DadosProcesso(driver, navegador, ufTribunal);

                        if (processo.DadosProcesso.Capturado)
                        {
                            processo.Partes = DadosParte(driver, navegador, partesAtiva, partesPassiva);

                            if (string.IsNullOrWhiteSpace(processo.Instancia))
                                processo.Instancia = "1ª instância";
                        }
                        else
                        {
                            processo.Inconsistencia = "Não foi possível montar Dados do Processo";
                            processo.Status = StatusProcesso.Inconsistente;
                        }
                    }

                    if (processo.CapturarMovimento)
                    {
                        processo.IdEventoAnterior = UltimoIdMovimento(processo.Numero);
                        processo.Movimentos = MovimentosProcesso(driver, navegador, ufTribunal, processo);
                    }

                    if (processo.BaixarCopia)
                    {
                        if (DownloadProcesso(janelaProcesso, navegador, folderSolicitacao, folderProcessamento, $"{processo.Numero.Replace(".", "").Replace("-", "")}_"))
                        {
                            string folderProcesso = "";
                            folderProcesso = _gerenciarFisicoService.CriarDiretorioProcesso(folderSolicitacao, processo.EmailCriadoPor, processo.IdSolicitacao, processo.Numero.Replace("-", "").Replace(".", ""));

                            if (_gerenciarFisicoService.TransferirArquivo(folderProcessamento, $"{processo.Numero.Replace(".", "").Replace("-", "")}_.pdf", folderProcesso, "", "", ""))
                            {
                                processo.Inconsistencia = "";
                                processo.Status = StatusProcesso.Capturado;
                                processo.NomeFisico = $"{processo.Numero.Replace(".", "").Replace("-", "")}_.pdf";
                            }
                        }
                    }

                    fecharJanelaDownload(janelaProcesso);
                    driver = _browserService.TrocarParaPrimeiraJanela(driver, 500);
                }
            }

            return processo;
        }


        private WebDriverWait AbrePaginaPesquisaProcesso(IWebDriver driver, string URL)
        {
            WebDriverWait navegador = null;

            try
            {
                //Abre a Pagina inicial do PJE
                driver = _browserService.AbrePagina(driver, URL);

                navegador = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                IWebElement botaoPesquisar = _browserService.ElementVerify(navegador, "Id", "fPP:searchProcessos", "ElementToBeClickable", null);
                if (botaoPesquisar == null)
                    navegador = null;
            }
            catch (WebDriverException)
            {
            }

            return navegador;
        }

        private IWebDriver PesquisarProcesso(IWebDriver driver, WebDriverWait navegador, string numeroProcesso)
        {
            IWebDriver janelaProcesso = null;

            string numeroProcessoSemEdicao = numeroProcesso.Replace("-", "").Replace(".", "");
            numeroProcessoSemEdicao = $"{numeroProcessoSemEdicao.Substring(0, 13)}{numeroProcessoSemEdicao.Substring(16, 4)}";

            IWebElement numeroSequencial = _browserService.ElementIsVisible(navegador, "Id", "fPP:numeroProcesso:numeroSequencial");
            IWebElement numeroDigitoVerificador = _browserService.ElementIsVisible(navegador, "Id", "fPP:numeroProcesso:numeroDigitoVerificador");
            IWebElement ano = _browserService.ElementIsVisible(navegador, "Id", "fPP:numeroProcesso:Ano");
            if (ano == null)
                ano = _browserService.ElementIsVisible(navegador, "Id", "fPP:numeroProcesso:ano");

            IWebElement numeroOrgaoJustica = _browserService.ElementIsVisible(navegador, "Id", "fPP:numeroProcesso:NumeroOrgaoJustica");
            if (numeroOrgaoJustica == null)
                numeroOrgaoJustica = _browserService.ElementIsVisible(navegador, "Id", "fPP:numeroProcesso:numeroOrgaoJustica");


            if (numeroSequencial == null ||
                numeroDigitoVerificador == null ||
                ano == null ||
                numeroOrgaoJustica == null)
                return janelaProcesso;

            //Informa o numero do Processo 
            numeroSequencial.SendKeys(numeroProcessoSemEdicao.Substring(0, 7));
            numeroDigitoVerificador.SendKeys(numeroProcessoSemEdicao.Substring(7, 2));
            ano.SendKeys(numeroProcessoSemEdicao.Substring(9, 4));
            numeroOrgaoJustica.SendKeys(numeroProcessoSemEdicao.Substring(13, 4));
            System.Threading.Thread.Sleep(500);

            //var tamanhoTela = driver.Manage().Window.Size;
            //tamanhoTela.Width = tamanhoTela.Width / 2;
            //tamanhoTela.Height = tamanhoTela.Height / 2;
            //driver.Manage().Window.Size = tamanhoTela;

            //Click no botão de pesquisar
            IWebElement botaoPesquisar = _browserService.ElementVerify(navegador, "Id", "fPP:searchProcessos", "ElementToBeClickable", new TimeSpan(0, 0, 15));
            if (botaoPesquisar == null)
                return janelaProcesso;

            botaoPesquisar.Click();
            System.Threading.Thread.Sleep(500);

            //tamanhoTela.Width = tamanhoTela.Width * 2;
            //tamanhoTela.Height = tamanhoTela.Height * 2;
            //driver.Manage().Window.Size = tamanhoTela;

            //Verifica se foi montado o link para o processo
            IWebElement linkProcesso = LinkProcessoEletronico(navegador);
            if (linkProcesso == null)
                return janelaProcesso;
            if (linkProcesso.Text.EndsWith("0 resultados encontrados."))
                return janelaProcesso;

            linkProcesso.Click();

            //Verifica se abriu o alert sobre a responsabilidade e fecha
            bool fechajanela = _browserService.FecharAlert(driver, navegador);

            //Troca a tela para onde foi aberto o documento
            janelaProcesso = _browserService.TrocarParaUltimaJanela(driver, 500);

            return janelaProcesso;
        }

        private DadosProcessoModel DadosProcesso(IWebDriver driver, WebDriverWait navegador, string ufTribunal)
        {
            DadosProcessoModel dadosProcesso = new DadosProcessoModel();
            dadosProcesso.Capturado = false;

            //===================================================================
            //Carrega as informações dos Dados do Processo
            //===================================================================
            IWebElement tableInformacoes = _browserService.ElementVerify(navegador, "Id", "navbar", "ElementIsVisible", new TimeSpan(0, 0, 15));
            if (tableInformacoes == null)
                return dadosProcesso;

            //Localizar o Link para abrir os dados do Processo
            IWebElement linkProcesso = _commonService.LocalizaXPath(tableInformacoes, "ul//li//a");
            if (linkProcesso == null)
                return dadosProcesso;
            linkProcesso.Click();

            IWebElement divDeatlhe = _browserService.ElementVerify(navegador, "Id", "maisDetalhes", "ElementIsVisible", new TimeSpan(0, 0, 15));
            if (divDeatlhe == null)
                return dadosProcesso;

            var linhasCabecalho = divDeatlhe.FindElements(By.XPath("dl//dt"));
            var linhasDetalhe = divDeatlhe.FindElements(By.XPath("dl//dd"));

            int sequencia = 0;
            foreach (var cabecalho in linhasCabecalho)
            {
                if (cabecalho.Text == "Classe judicial")
                    dadosProcesso.Classe = linhasDetalhe[sequencia].Text;

                if (cabecalho.Text == "Assunto")
                    dadosProcesso.Assunto = linhasDetalhe[sequencia].Text;

                if (cabecalho.Text == "Autuação")
                    dadosProcesso.Distribuicao = linhasDetalhe[sequencia].Text;

                if (cabecalho.Text == "Autuação")
                    dadosProcesso.Distribuicao = linhasDetalhe[sequencia].Text;

                if (cabecalho.Text == "Valor da causa")
                    dadosProcesso.ValorAcao = linhasDetalhe[sequencia].Text;

                if (cabecalho.Text == "Jurisdição")
                    dadosProcesso.Forum = linhasDetalhe[sequencia].Text;

                sequencia += 1;
            }

            var linhasCabecalhoOutrosDados = divDeatlhe.FindElements(By.XPath("div//dl//dt"));
            var linhasDetalheOutrosDados = divDeatlhe.FindElements(By.XPath("div//dl//dd"));
            sequencia = 0;
            foreach (var cabecalho in linhasCabecalhoOutrosDados)
            {
                if (cabecalho.Text == "Órgão colegiado")
                    dadosProcesso.Vara = linhasDetalheOutrosDados[sequencia].Text;

                if (cabecalho.Text == "Órgão julgador")
                    if (string.IsNullOrWhiteSpace(dadosProcesso.Vara))
                        dadosProcesso.Vara = linhasDetalheOutrosDados[sequencia].Text;

                if (cabecalho.Text == "Competência")
                    dadosProcesso.Area = linhasDetalheOutrosDados[sequencia].Text;

                if (cabecalho.Text == "Relator")
                    dadosProcesso.Juiz = linhasDetalheOutrosDados[sequencia].Text;

                sequencia += 1;
            }



            dadosProcesso.UF = ufTribunal;
            dadosProcesso.Capturado = true;

            var localalizou = LocalizaSituacaoProcesso(navegador, dadosProcesso);

            return dadosProcesso;

        }

        private List<ProcessoParteModel> DadosParte(IWebDriver driver, WebDriverWait navegador, List<string> partesAtiva, List<string> partesPassiva)
        {
            List<ProcessoParteModel> partes = new List<ProcessoParteModel>();

            //===================================================================
            //Carrega os dados do polo Ativo
            //===================================================================
            IWebElement divPoloAtivo = _browserService.ElementVerify(navegador, "Id", "poloAtivo", "ElementIsVisible", new TimeSpan(0, 0, 5));
            if (divPoloAtivo != null)
                partes = MontarDadoParte(TipoParte.Autora, divPoloAtivo, partesAtiva);

            //===================================================================
            //Carrega os dados do polo Ativo
            //===================================================================
            IWebElement divPoloPassivo = _browserService.ElementVerify(navegador, "Id", "poloPassivo", "ElementIsVisible", new TimeSpan(0, 0, 5));
            if (divPoloPassivo != null)
                partes.AddRange(MontarDadoParte(TipoParte.Reu, divPoloPassivo, partesPassiva));


            return partes;
        }

        private bool AtualizarDadosProcesso(int idProcesso, DadosProcessoModel dadosProcesso)
        {
            bool retorno = false;

            var processo = _session.Query<Processo>().FirstOrDefault(x => x.Id == idProcesso);

            var equipamentoProcessamento = _session.Query<EquipamentoProcessamento>()
                           .FirstOrDefault(x => x.Id == processo.EquipamentoProcessamento.Id);

            if (processo != null)
            {
                if (!string.IsNullOrEmpty(dadosProcesso.Situacao) && dadosProcesso.Situacao.Length > 200)
                    dadosProcesso.Situacao = dadosProcesso.Situacao.Substring(0, 199);

                processo.AlterarDadosProcesso(dadosProcesso.Forum, dadosProcesso.Vara, dadosProcesso.Comarca, dadosProcesso.UF, dadosProcesso.Classe, dadosProcesso.Area, dadosProcesso.Assunto, dadosProcesso.OutrosAssuntos, dadosProcesso.Distribuicao, dadosProcesso.Controle, dadosProcesso.ValorAcao, dadosProcesso.Juiz, null, dadosProcesso.Situacao, null, dadosProcesso.JusticaGratuita, processo.PossuiDocumento, equipamentoProcessamento, dadosProcesso.OrgaoJulgador);

                using (var transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(processo);
                    transaction.Commit();
                }

                retorno = true;
            }


            return retorno;
        }

        private bool AtualizarDadosParte(int idProcesso, List<ProcessoParteModel> dadosParte, Usuario login)
        {
            bool retorno = false;

            var processo = _session.Query<Processo>().FirstOrDefault(x => x.Id == idProcesso);

            if (processo != null)
            {
                foreach (var parte in dadosParte.OrderBy(o => o.Sequencia))
                {
                    ProcessoParte processoParte = new ProcessoParte(processo, parte.Nome, parte.Tipo, parte.Sequencia, parte.Qualificacao, login, parte.ClienteEscritorio, null,null);

                    if (parte.Advogados != null)
                    {
                        foreach (var advogadoParte in parte.Advogados)
                        {
                            var advogado = _session.Query<ProcessoAdvogado>().FirstOrDefault(x => x.Processo.Id == idProcesso && x.Nome == advogadoParte.Nome);
                            if (advogado == null)
                            {
                                advogado = new ProcessoAdvogado(processo, advogadoParte.Nome, advogadoParte.Qualificacao, advogadoParte.Documento, advogadoParte.Oab, login);
                                processo.AdicionarAdvogado(advogado);
                            }
                            processoParte.AdcionarAdvogado(advogado, advogadoParte.Sequencia, login);
                        }
                    }

                    processo.AdicionarParte(processoParte);
                }

                using (var transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(processo);
                    transaction.Commit();
                }

                retorno = true;
            }


            return retorno;
        }

        private IWebElement LinkProcessoEletronico(WebDriverWait navegador)
        {
            System.Threading.Thread.Sleep(1000);

            List<WebElementModel> objetosTela = new List<WebElementModel>();
            objetosTela.Add(new WebElementModel() { identificador = "Id", idElemento = "fPP:processosTable", action = "ElementIsVisible" });
            objetosTela.Add(new WebElementModel() { identificador = "Id", idElemento = "fPP:processosTable:j_id416", action = "ElementIsVisible" });
            WebElementModel elementModel = _browserService.ElementsVerify(navegador, objetosTela, new TimeSpan(0, 0, 5));

            if (elementModel.identificador == null)
                return null;

            IWebElement retorno = elementModel.element;
            if (retorno == null)
                return retorno;

            if (retorno.Text.EndsWith("0 resultados encontrados."))
                return retorno;

            IWebElement processos = _browserService.ElementVerify(navegador, "Id", "fPP:processosTable:tb", "ElementIsVisible", new TimeSpan(0, 0, 10));
            if (processos == null)
                return null;

            var linhas = processos.FindElements(By.XPath($"tr"));
            foreach (var linha in linhas)
            {
                var colunas = linha.FindElements(By.XPath($"td"));
                retorno = colunas.FirstOrDefault();
            }

            return retorno;
        }

        private List<ProcessoParteModel> MontarDadoParte(TipoParte tipo, IWebElement divParte, List<string> qualificacaoParte)
        {
            List<ProcessoParteModel> partes = new List<ProcessoParteModel>();

            var linhasPolo = divParte.FindElements(By.XPath("table//tbody//tr//td"));
            int sequencia = 0;
            foreach (var linhaPolo in linhasPolo)
            {
                ProcessoParteModel parte = new ProcessoParteModel();
                sequencia += 1;
                parte.Tipo = tipo;
                parte.Sequencia = sequencia;
                string poloNome = "";
                var nomePolo = _commonService.LocalizaXPath(linhaPolo, "span");
                if (nomePolo == null)
                    nomePolo = _commonService.LocalizaXPath(linhaPolo, "a//span");
                if (nomePolo != null)
                    poloNome = nomePolo.Text.Trim();

                parte.Nome = poloNome;
                int posicaoUltimo = parte.Nome.LastIndexOf("(");
                if (posicaoUltimo > 0)
                {
                    parte.Qualificacao = parte.Nome.Substring(posicaoUltimo, parte.Nome.Length - posicaoUltimo).Replace("(", "").Replace(")", "").Trim();
                    if (!qualificacaoParte.Contains(parte.Qualificacao.ToUpper()))
                        parte.Tipo = TipoParte.NaoQualificado;
                }
                if (parte.Nome.IndexOf(" - ") > 0)
                    parte.Nome = parte.Nome.Replace(" - ", "#").Split('#')[0].Trim();

                //===============================================================================
                // Monta os Advogados
                //===============================================================================
                var advogados = linhaPolo.FindElements(By.XPath("ul//li//small//span"));
                int sequenciaAdvogado = 1;
                foreach (var advogado in advogados)
                {
                    if (parte.Advogados == null)
                        parte.Advogados = new List<ProcessoAdvogadoModel>();

                    ProcessoAdvogadoModel advogadoModel = new ProcessoAdvogadoModel();
                    advogadoModel.Nome = advogado.Text.Trim();
                    if (advogadoModel.Nome.LastIndexOf("(") > 0)
                        advogadoModel.Nome = advogadoModel.Nome.Substring(0, advogadoModel.Nome.LastIndexOf("(") - 1);
                    advogadoModel.Qualificacao = "Advogado";
                    advogadoModel.Sequencia = sequenciaAdvogado;
                    parte.Advogados.Add(advogadoModel);

                    sequenciaAdvogado += 1;
                    sequenciaAdvogado += 1;
                }

                partes.Add(parte);
            }



            return partes;
        }

        private List<ProcessoMovimentoModel> MovimentosProcesso(IWebDriver driver, WebDriverWait navegador, string ufTribunal, ProcessoModel processo)
        {
            List<ProcessoMovimentoModel> movimentosProcesso = new List<ProcessoMovimentoModel>();

            if (!MontarMovimentosProcesso(navegador, movimentosProcesso, processo, ufTribunal))
                return movimentosProcesso;

            return movimentosProcesso;

        }

        private bool MontarMovimentosProcesso(WebDriverWait navegador, List<ProcessoMovimentoModel> movimentosProcesso, ProcessoModel processo, string ufTribunal)
        {
            IWebElement divArquivos = _browserService.ElementVerify(navegador, "Id", "divTimeLine:divEventosTimeLine", "ElementIsVisible", new TimeSpan(0, 0, 5));
            if (divArquivos == null)
                return false;

            string path = "div";
            var linhas = divArquivos.FindElements(By.XPath(path));
            if (linhas == null)
                return false;

            int sequencia = 1;
            string dia = "";
            foreach (var linha in linhas)
            {
                if (linha.GetAttribute("class") == "media data")
                    dia = linha.Text.Trim();


                if (linha.GetAttribute("class").StartsWith("media interno tipo-"))
                {
                    var colunas = _commonService.LocalizaXPath(linha, "div[@class='media-body box']");
                    if (colunas != null)
                    {
                        var hora = _commonService.LocalizaXPath(colunas, "div[@class='col-sm-12']");
                        if (hora != null)
                        {
                            string descricao = "";
                            var textoMovimento = _commonService.LocalizaXPath(colunas, "div//span[@class='text-upper texto-movimento']");
                            if (textoMovimento != null)
                            {
                                var textos = colunas.FindElements(By.XPath("div//span[@class='text-upper texto-movimento']"));
                                foreach (var texto in textos)
                                {
                                    descricao += $"{texto.Text.Trim()} ";
                                }
                            }
                            else
                            {
                                var textoSimples = _commonService.LocalizaXPath(colunas, "span[@class='text-upper texto-movimento']");
                                if (textoSimples != null)
                                {
                                    descricao = textoSimples.Text.Trim();
                                }
                                else
                                {
                                    var temAnexo = _commonService.LocalizaXPath(colunas, "div[@class='anexos']");
                                    if (temAnexo != null)
                                        descricao = "Documento Anexado.";
                                }
                            }

                            if (!string.IsNullOrWhiteSpace(descricao))
                            {
                                if (String.IsNullOrWhiteSpace(processo.IdEventoPrimeiroLista))
                                    processo.IdEventoPrimeiroLista = $"{System.Convert.ToDateTime(dia).ToShortDateString()} {hora.Text.Trim()}";

                                if ($"{System.Convert.ToDateTime(dia).ToShortDateString()} {hora.Text.Trim()}" == processo.IdEventoAnterior)
                                    break;


                                ProcessoMovimentoModel movimentoProcesso = new ProcessoMovimentoModel();
                                movimentoProcesso.Sequencia = sequencia;
                                //movimentoProcesso.IdEvento = "";
                                movimentoProcesso.Descricao = descricao;
                                movimentoProcesso.Data = $"{System.Convert.ToDateTime(dia).ToShortDateString()} {hora.Text.Trim()}";
                                //movimentoProcesso.Responsavel = "";
                                movimentosProcesso.Add(movimentoProcesso);
                                sequencia += 1;


                                processo.IdEventoUltimoLista = movimentoProcesso.Data;
                            }
                        }
                    }
                }
            }


            return true;
        }

        private string UltimoIdMovimento(string processo)
        {
            string retorno = "";

            var ultimoMovimento = _session.Query<ProcessoMovimento>().Where(m => m.Numero == processo && m.IdEvento != null).ToList();
            if (ultimoMovimento.Count() == 0)
            {
                ultimoMovimento = _session.Query<ProcessoMovimento>().Where(m => m.Numero == processo && m.IdEvento == null).ToList();
                retorno = ultimoMovimento.OrderByDescending(o => System.Convert.ToDateTime(o.Data)).FirstOrDefault().Data;
            }
            else
            {
                retorno = ultimoMovimento.OrderByDescending(o => System.Convert.ToDouble(o.IdEvento)).FirstOrDefault().IdEvento; ;
            }

            return retorno;
        }

        private bool AtualizarMovimentos(List<ProcessoMovimentoModel> movimentosProcesso, string numeroProcesso, Usuario login)
        {
            bool retorno = false;

            foreach (var movimento in movimentosProcesso.OrderByDescending(o => o.Sequencia))
            {
                ProcessoMovimento processoMovimento = new ProcessoMovimento(numeroProcesso, movimento.IdEvento, movimento.Data, movimento.Responsavel, movimento.Descricao, login);

                using (var transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(processoMovimento);
                    transaction.Commit();
                }

                retorno = true;
            }


            return retorno;
        }

        private bool AtualizarEventoCapturado(int idProcesso, ProcessoModel processoProcessado)
        {
            bool retorno = false;

            var processo = _session.Query<Processo>().FirstOrDefault(x => x.Id == idProcesso);

            if (processo != null)
            {
                processo.AlterarEventoCaptura(processoProcessado.IdEventoAnterior, processoProcessado.IdEventoPrimeiroLista, processoProcessado.IdEventoUltimoLista);

                using (var transaction = _session.BeginTransaction())
                {
                    _session.SaveOrUpdate(processo);
                    transaction.Commit();
                }

                retorno = true;
            }


            return retorno;
        }

        private bool LocalizaSituacaoProcesso(WebDriverWait navegador, DadosProcessoModel dadosProcesso)
        {

            //=============================================================
            //Precisa trocar por Entidade
            //=============================================================
            List<string> buscarMovimentos = new List<string>();
            buscarMovimentos.Add("Embargos de Declaração");
            buscarMovimentos.Add("Proferido despacho de mero expediente");
            buscarMovimentos.Add("Arquivado Definitivamente");
            buscarMovimentos.Add("Homologada a Desistência do Recurso");
            buscarMovimentos.Add("Conclusos para Homologação");
            buscarMovimentos.Add("Transitado em Julgado");
            buscarMovimentos.Add("Trânsito em julgado");
            buscarMovimentos.Add("Julgado improcedente");
            buscarMovimentos.Add("Julgado procedente");
            buscarMovimentos.Add("Homologada a Transação");
            buscarMovimentos.Add("Extinta a execução");
            buscarMovimentos.Add("Redistribuído por");
            buscarMovimentos.Add("Deliberado em sessão");
            buscarMovimentos.Add("Concedida a Medida Liminar");
            buscarMovimentos.Add("Não Concedida a Medida Liminar");
            buscarMovimentos.Add("Arquivado Provisoramente");
            buscarMovimentos.Add("Processo Desarquivado");
            buscarMovimentos.Add("Processo Desarquivado");
            buscarMovimentos.Add("Decisão interlocutória");
            buscarMovimentos.Add("Conclusos para decisão para");

            IWebElement divArquivos = _browserService.ElementVerify(navegador, "Id", "divTimeLine:divEventosTimeLine", "ElementIsVisible", new TimeSpan(0, 0, 5));
            if (divArquivos == null)
                return false;

            string path = "div";
            var linhas = divArquivos.FindElements(By.XPath(path));
            if (linhas == null)
                return false;

            foreach (var linha in linhas)
            {
                if (linha.GetAttribute("class").StartsWith("media interno tipo-"))
                {
                    var colunas = _commonService.LocalizaXPath(linha, "div[@class='media-body box']");
                    if (colunas != null)
                    {
                        string textoMovimento = colunas.Text.Trim();
                        string[] textosMovimento = null;

                        if (textoMovimento.IndexOf("\r\n") > 0)
                            textosMovimento = colunas.Text.Trim().Replace("\r\n", "#").Split('#');
                        else
                            textosMovimento[0] = textoMovimento;

                        for (int i = 0; i < textosMovimento.Count() - 1; i += 1)
                        {
                            if (textosMovimento[i].StartsWith("MOV. ["))
                                textosMovimento[i] = textosMovimento[i].Trim().Replace("] - ", "#").Split('#')[1];

                            foreach (var buscarMovimento in buscarMovimentos)
                            {
                                if (buscarMovimento.Trim() != "")
                                    if (textosMovimento[i].ToUpper().StartsWith(buscarMovimento.ToUpper()))
                                    {
                                        dadosProcesso.Situacao = textosMovimento[i];
                                        break;
                                    }
                            }

                            if (!string.IsNullOrWhiteSpace(dadosProcesso.Situacao))
                                break;
                        }

                        if (!string.IsNullOrWhiteSpace(dadosProcesso.Situacao))
                            break;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(dadosProcesso.Situacao))
            {

            }

            return true;
        }

        private void ValidarAdvogado(List<ProcessoParteModel> partes, List<string> advogados)
        {
            foreach (var parte in partes)
            {
                parte.ClienteEscritorio = false;
                if (parte.Advogados != null)
                    foreach (var advogado in parte.Advogados)
                        if (advogados.Contains(advogado.Nome.ToUpper()))
                            parte.ClienteEscritorio = true;
            }
        }

        private bool DownloadProcesso(IWebDriver driver, WebDriverWait navegadorProcesso, string folderSolicitacao, string folderProcessamento, string nomeFinalArquivo)
        {
            bool retorno = false;
            string ultimoDocumento = "";
            try
            {
                IWebElement iconeDownload = _browserService.ElementVerify(navegadorProcesso, "ClassName", "btn-menu-abas", "ElementToBeClickable", new TimeSpan(0, 0, 15));
                if (iconeDownload == null)
                    return retorno;

                if (iconeDownload.Text != "Ícone de download")
                    return retorno;

                iconeDownload.Click();
                //===================================================================================================

                IWebElement cboCronologia = _browserService.ElementVerify(navegadorProcesso, "Id", "navbar:cbCronologia", "ElementToBeClickable", new TimeSpan(0, 0, 15));
                if (cboCronologia == null)
                    return retorno;

                var optionCronologia = _commonService.LocalizaXPath(cboCronologia, "//option[contains(text(),'Crescente')]");
                if (optionCronologia == null)
                    return retorno;

                optionCronologia.Click();
                //===================================================================================================



                //Verifica se já pode iniciar o Download
                IWebElement linkDownload = _browserService.ElementVerify(navegadorProcesso, "Id", "navbar:downloadProcesso", "ElementToBeClickable", new TimeSpan(0, 0, 15));
                if (linkDownload == null)
                {
                    linkDownload = _browserService.ElementVerify(navegadorProcesso, "Id", "navbar:botoesDownload", "ElementIsVisible", new TimeSpan(0, 0, 15));
                    if (linkDownload == null)
                        return retorno;

                    linkDownload = _commonService.LocalizaXPath(linkDownload, "input");
                    if (linkDownload == null)
                        return retorno;
                }

                //Verifica se a Pasta de Processamento possui arquivo e deleta
                if (!_gerenciarFisicoService.DeletarArquivo($"{folderProcessamento}", "*.*"))
                    return retorno;

                //Verifica se a Pasta de Download possui arquivo e deleta
                if (!_gerenciarFisicoService.DeletarArquivo($"{folderProcessamento}\\Download", "*.*"))
                    return retorno;

                linkDownload.Click();
                if (_browserService.FecharAlert(driver, navegadorProcesso))
                {
                    if (_gerenciarFisicoService.FinalizouDownload($"{folderProcessamento}\\Download", _commonService.ExtensoesArquivosExperadas("")))
                        if (_gerenciarFisicoService.TransferirArquivo($"{folderProcessamento}\\Download", "", folderProcessamento, "", ".pdf", nomeFinalArquivo))
                            retorno = true;

                    iconeDownload.Click();
                }
            }
            catch (Exception ex) { }

            return retorno;
        }

        private void fecharJanelaDownload(IWebDriver navegadorProcesso)
        {
            try
            {
                int numerotentativas = 0;
                while(numerotentativas <= 3)
                {
                    if (fecharJanela(navegadorProcesso))
                        numerotentativas = 10;

                    numerotentativas += 1;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private bool fecharJanela(IWebDriver navegadorProcesso)
        {
            bool retorno = true;
            try
            {
                navegadorProcesso.Close();
            }
            catch (Exception ex)
            {
                retorno = false;
            }

            return retorno;
        }
    }
}
