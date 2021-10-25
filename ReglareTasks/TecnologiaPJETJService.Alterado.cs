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
using CapturaDadosProcesso.Facade.Models.SolicitacaoLocalizacao;

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
        private readonly ISolicitacaoLocalizacaoService _solicitacaoLocalizacaoService;

        public TecnologiaPJETJService(ISession session,
                                      IMapper mapper,
                                      IEmailService emailService,
                                      ICertificadoDigitalService certificadoDigitalService,
                                      IGerenciarFisicoService gerenciarFisicoService,
                                      IBrowserService browserService,
                                      ILoginCertificadoDigitalService loginCertificadoDigital,
                                      ICommonService commonService,
                                      IParametrosService parametrosService,
                                      ISolicitacaoLocalizacaoService solicitacaoLocalizacaoService)
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
            _solicitacaoLocalizacaoService = solicitacaoLocalizacaoService;
        }

        public DadosLoginModel LogarSite(EquipamentoProcessamentoTribunal configuracao, string folderBase, string macAddr, int taskId, bool baixarCopia, String numeroProcesso)
        {
            DadosLoginModel retorno = new DadosLoginModel();

            try
            {
                string usuarioInstancia = "";
                string pwdInstancia = "";
                bool recaptchaLogin = true;
                retorno.Sucesso = true;


                //============================================================================
                // Identifica a Pagina de Login
                //============================================================================
                Console.WriteLine("Pagina Login");
                var paginaLogin = _commonService.PaginaLogin(configuracao, null);
                if (paginaLogin == null)
                    throw new ApplicationException("Pagina LogIn não localizada");
                //============================================================================

                //============================================================================
                // Identifica a Primeira Instancia
                //============================================================================
                Console.WriteLine("Identifica a Primeira Instancia");
                var primeiraInstancia = _commonService.PrimeiraInstanciaTribunal(configuracao);
                if (primeiraInstancia == null)
                    throw new ApplicationException("Primeira Instancia não localizada");
                retorno.PrimeiraInstancia = primeiraInstancia;
                //============================================================================

                //============================================================================
                // Identifica se Precisa criar a Pasta Base para Baixa Copias
                //============================================================================
                Console.WriteLine("Pasta Base para Baixa Copias");
                string folderProcessamento = _gerenciarFisicoService.CriarDiretorioProcessamento(folderBase, macAddr, System.Convert.ToInt32(taskId));
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

                //===============================================================================
                // Identifica se o Navegador é FireFox e Cria Cópia do Profile
                //===============================================================================
                string folderProfileProcessamento = "";
                if (primeiraInstancia.NavegadorWeb == TipoNavegadorWeb.FireFox)
                {
                    string pathProfile = _commonService.PathProfile(configuracao.EquipamentoProcessamento.Id, primeiraInstancia.VersaoNavegadorWeb);
                    if (!string.IsNullOrWhiteSpace(pathProfile))
                    {
                        folderProfileProcessamento = _gerenciarFisicoService.CriarDiretorioProfileFireFox(folderBase, macAddr, System.Convert.ToInt32(taskId));
                        var listaArquivos = _gerenciarFisicoService.ListarArquivos(folderProfileProcessamento, "*.*");
                        bool copiou = true;
                        if (listaArquivos == null || listaArquivos.Count() > 0)
                        {
                            copiou = _gerenciarFisicoService.CopiarDiretorio(pathProfile, folderProfileProcessamento);
                        }
                        if (!copiou)
                        {
                            retorno.Sucesso = false;
                            retorno.MenssagemErro = "Não foi possível copiar o diretório de profle.";
                            return retorno;
                        }
                    }
                }

                //============================================================================
                // Abre a Pagina Inicial do Tribunal no Firefox
                //============================================================================
                Console.WriteLine("Abre a Pagina Inicial do Tribunal no Firefox");
                IWebDriver driver = _commonService.AbrePaginaInicial(paginaLogin.URL, folderProcessamento, primeiraInstancia.NavegadorWeb, configuracao.EquipamentoProcessamento.Id, primeiraInstancia.VersaoNavegadorWeb, folderProfileProcessamento, exibirNavegador);
                if (driver == null)
                {
                    retorno.Sucesso = false;
                    retorno.MenssagemErro = "Não foi possível abrir a pagina inicial.";
                    return retorno;
                }
                WebDriverWait navegador = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                retorno.Driver = driver;
                //============================================================================

                //===============================================================================
                // Verifica se montou tela do ReCaptcha V2
                //===============================================================================
                //List<WebElementModel> objetosCaptcha = new List<WebElementModel>();
                //objetosCaptcha.Add(new WebElementModel() { identificador = "ClassName", idElemento = "g-recaptcha", action = "ElementIsVisible", tipoObjeto = "Frame", timeout = new TimeSpan(0, 0, 15) });

                //====================================================================================
                // Precisa carregar a pagina de login se o TRT não carregou
                //====================================================================================
                IWebElement carregouUsuario = _browserService.ElementVerify(navegador, "Name", "usuario", "ElementToBeClickable", new TimeSpan(0, 0, 10));
                if (carregouUsuario == null)
                {
                    driver.Navigate().GoToUrl(paginaLogin.URL);
                    navegador = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                    retorno.Driver = driver;
                }
                //====================================================================================

                //============================================================================
                //Identifica o Usuario de Acesso a Instancia do Site
                //============================================================================
                UsuarioAcesso usuarioAcesso = _commonService.UsuarioAcesso(configuracao.Tribunal.Id, primeiraInstancia.Id, 0);
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
                objetosLogin.Add(new WebElementModel() { identificador = "Name", idElemento = "txtNumProcessoPesquisaRapida", action = "ElementToBeClickable", tipoObjeto = "InputNumeroProcesso", timeout = new TimeSpan(0, 0, 15) });
                if (!_commonService.Login(driver, navegador, usuarioInstancia, pwdInstancia, objetosLogin, false, true))
                {
                    retorno.Sucesso = false;
                    retorno.MenssagemErro = "Não foi possível logar no Tribunal.";

                    driver.Close();
                    driver.Dispose();
                    return retorno;
                }

                System.Threading.Thread.Sleep(200);

                //===============================================================================
                // Verifica se montou tela do ReCaptcha V2
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

                //    if (!_commonService.ResolverReCaptchaV2(driver, navegador, objetosCaptcha, paginaLogin.URL))
                //    {
                //        retorno.Sucesso = false;
                //        retorno.MenssagemErro = "Não foi possível resolver o Recaptcha.";

                //        driver.Close();
                //        driver.Dispose();
                //        return retorno;
                //    }
                //}

                Console.Write("Tecle ENTER");
                Console.ReadKey();

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
            try
            {
                bool atualizar = false;
                bool orgJulgadorTratado = false;
                bool exibirNavegador = true;

                TipoNomeExterno tipoNomeExterno = TipoNomeExterno.NumeroProcesso;

                var parametroExibirNavegador = _commonService.ParametroEquipamento("Exibir Navegador", configuracao.EquipamentoProcessamento.Id);
                if (!string.IsNullOrWhiteSpace(parametroExibirNavegador) && parametroExibirNavegador.ToUpper() == "NÃO")
                    exibirNavegador = false;

                if (dadosLoginModel.Driver == null)
                {
                    bool baixarCopia = false;
                    if (processos.Where(p => p.BaixarCopia).Count() > 0 || processos.Where(p => p.ProcessoDistribuido).Count() > 0)
                        baixarCopia = true;

                    dadosLoginModel = LogarSite(configuracao, folderBase, macAddr, taskId, baixarCopia, processos.FirstOrDefault().Numero);
                    dadosLoginModel.FecharBrowser = true;
                }

                if (!dadosLoginModel.Sucesso)
                {
                    dadosLoginModel.Sucesso = false;
                    dadosLoginModel.MenssagemErro = "Não foi possível logar no Tribunal.";
                    return dadosLoginModel;
                }

                var solicitacoesProcessar = processos.Where(p => p.IdTecnologiaSite == configuracao.Tecnologia.Id &&
                                                           (p.Status == StatusProcesso.EmProcessamento || p.Status == StatusProcesso.Pendente)).Select(p => p.IdSolicitacao).Distinct();

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

                    List<TermoExpressaoRegularModel> expressoes = new List<TermoExpressaoRegularModel>();
                    if (solicitacao.CapturarDistribuicao)
                        expressoes = _solicitacaoLocalizacaoService.ListarExpressaoPorTribunal(configuracao.Tribunal.Id, configuracao.Tecnologia.Id);

                    var processosAProcessar = _mapper.Map<List<ProcessoModel>>(processos.Where(p => p.IdSolicitacao == solicitacaoProcessar && !p.Numero.StartsWith("9999999-") && p.IdTecnologiaSite == configuracao.Tecnologia.Id && (p.Status == StatusProcesso.EmProcessamento || p.Status == StatusProcesso.Pendente)).ToList());

                    var equipamentoProcessamento = _session.Query<EquipamentoProcessamento>().FirstOrDefault(x => x.Id == configuracao.EquipamentoProcessamento.Id);

                    int quantidadeNaoLocalizado = 0;
                    if (dadosLoginModel.Sucesso)
                    {
                        foreach (var processoAProcessar in processosAProcessar)
                        {
                            Console.WriteLine($"Capturando Processo {processoAProcessar.Numero}");

                            if (quantidadeMaxinaNaoLocalizado != 0 && quantidadeMaxinaNaoLocalizado < quantidadeNaoLocalizado)
                                break;

                            atualizar = _commonService.AtualizarSituacaoProcesso(processoAProcessar.Id, login, dadosLoginModel.PrimeiraInstancia, StatusProcesso.EmProcessamento, "", true);

                            ProcessoModel processoProcessado = ProcessarInstancia(dadosLoginModel.Driver, processoAProcessar, $"{dadosLoginModel.PrimeiraInstancia.URL}", login, folderBase, dadosLoginModel.FolderProcessamento, dadosLoginModel.PrimeiraInstancia.Descricao, tipoNomeExterno, configuracao.EquipamentoProcessamento.Id, configuracao.CopiaDocumentoUnico, configuracao.Tribunal.UF.Sigla, expressoes);

                            if (processoProcessado.Status == StatusProcesso.EmProcessamento || processoProcessado.Status == StatusProcesso.Pendente)
                                quantidadeNaoLocalizado = quantidadeNaoLocalizado + 1;
                            else
                                quantidadeNaoLocalizado = 0;

                            if (processoProcessado.Status != StatusProcesso.EmProcessamento && processoProcessado.Status != StatusProcesso.Pendente)
                            {
                                if (processoProcessado.Status != StatusProcesso.Capturado)
                                {
                                    atualizar = _commonService.AtualizarSituacaoProcesso(processoProcessado.Id, login, dadosLoginModel.PrimeiraInstancia, processoProcessado.Status, processoProcessado.Inconsistencia, processoProcessado.Eletronico);
                                }

                                if (processoProcessado.Status == StatusProcesso.Capturado)
                                {
                                    if (!string.IsNullOrWhiteSpace(processoProcessado.DadosProcesso.OrgaoJulgador))
                                        orgJulgadorTratado = _commonService.TratarForumVaraComarca(processoProcessado, configuracao.Tribunal.UF.Sigla);

                                    atualizar = _commonService.AtualizarDadosProcesso(processoProcessado.Id, processoProcessado.DadosProcesso, processoProcessado.Partes, login, dadosLoginModel.PrimeiraInstancia, processoProcessado.PossuiDocumento, equipamentoProcessamento);
                                    atualizar = _commonService.AtualizarProcessoCapturado(0, login, processoProcessado.Numero, configuracao.Tribunal, processoProcessado.Instancia, processoProcessado.Inconsistencia, processoProcessado.Status, configuracao.Tecnologia, System.Convert.ToInt16(processoProcessado.idForumFaixaNumeroProcesso), processoProcessado.Documentos, solicitacao.CriadoPor);

                                    if (processoProcessado.CapturarMovimento)
                                    {
                                        atualizar = _commonService.AtualizarMovimentos(processoProcessado.Movimentos, processoProcessado.Numero, login);
                                        atualizar = _commonService.AtualizarEventoCapturado(processoProcessado.Id, processoProcessado);
                                    }

                                    if (processoProcessado.TermoProcesso != null && processoProcessado.TermoProcesso.IdTermoLocalizacao > 0)
                                    {
                                        atualizar = _commonService.AtualizarProcessoDistribuidoTermo(login, processoProcessado.TermoProcesso.IdTermoLocalizacao, configuracao.Tribunal.Id, processoProcessado.IdTecnologiaSite, processoProcessado.Numero, processoProcessado.TermoProcesso.TermoExpressao, processoProcessado.TermoProcesso.NomeParte, processoProcessado.TermoProcesso.Afirmacao, solicitacao);
                                    }

                                }

                                var processoModel = processos.FirstOrDefault(pm => pm.Id == processoAProcessar.Id);
                                if (processoModel != null)
                                    processoModel.Status = processoAProcessar.Status;
                            }

                            Console.WriteLine($"Processo {processoAProcessar.Status}");

                            if (processoProcessado.Inconsistencia == "Login Derrubado.")
                            {
                                if (solicitacao.CapturarDistribuicao)
                                {
                                    dadosLoginModel.Sucesso = false;
                                    dadosLoginModel.MenssagemErro = "Login Derrubado.";
                                    processoProcessado.Inconsistencia = "";
                                    break;
                                }

                                dadosLoginModel.Driver.Close();
                                dadosLoginModel.Driver.Dispose();

                                dadosLoginModel = LogarSite(configuracao, folderBase, macAddr, taskId, solicitacao.BaixarCopia, processoProcessado.Numero);
                                if (!dadosLoginModel.Sucesso)
                                {
                                    dadosLoginModel.MenssagemErro = "Login Derrubado.";
                                    processoProcessado.Inconsistencia = "";
                                    break;
                                }
                                dadosLoginModel.FecharBrowser = true;

                                ///vamos analisar depois com Renato!!!
                                //navegadorPaginaTerceiro = AbrePaginaPesquisaTerceiros(dadosLoginModel.Driver);
                                //if (navegadorPaginaTerceiro == null)
                                //{
                                //    dadosLoginModel.MenssagemErro = "Login Derrubado.";
                                //    processoProcessado.Inconsistencia = "";
                                //    break;
                                //}

                            }
                        }
                    }
                }

                if (dadosLoginModel.FecharBrowser)
                {
                    dadosLoginModel.Driver.Close();
                    dadosLoginModel.Driver.Dispose();
                }

                //====================================================================================
                // Atualiza os não localizados
                //====================================================================================
                if (dadosLoginModel.Sucesso || (!dadosLoginModel.Sucesso && dadosLoginModel.MenssagemErro != "Login Derrubado."))
                    foreach (var processo in processos.Where(p => p.Status == StatusProcesso.EmProcessamento))
                    {
                        atualizar = _commonService.AtualizarSituacaoProcesso(processo.Id, login, configuracao.Tribunal.Instancias.FirstOrDefault(), StatusProcesso.NaoLocalizado, "Processo não Localizado.", true);
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
            }
            catch (Exception ex)
            {
                dadosLoginModel.Sucesso = false;
                dadosLoginModel.MenssagemErro = ex.Message;
                Console.WriteLine(ex.Message);
            }

            return dadosLoginModel;
        }


        private ProcessoModel ProcessarInstancia(IWebDriver driver, ProcessoModel processo, string URL, Usuario login, string folderSolicitacao, string folderProcessamento, string instancia, TipoNomeExterno tipoNomeExterno, int idEquipamento, bool CopiaDocumentoUnico, string UfTribunal, List<TermoExpressaoRegularModel> expressoes)
        {
            IWebDriver janelaProcesso = PesquisarProcesso(driver, processo.Numero);

            WebDriverWait navegador = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            //if (janelaProcesso != null)
            //{
            //    IWebElement txtNumeroProcesso = _browserService.ElementVerify(navegador, "Id", "txtNumProcesso", "ElementIsVisible", new TimeSpan(0, 0, 15));
            //    if (txtNumeroProcesso != null)
            //    {
            //        string nomeFinalArquivo = "";
            //        bool buscouDadosProcesso = false;
            //        WebDriverWait navegadorExpandeInformacoes = ExpandirInformacoes(driver);

            //        buscouDadosProcesso = AcessarDadosProcesso(processo, navegador, driver, UfTribunal, folderSolicitacao, folderProcessamento, nomeFinalArquivo, idEquipamento, CopiaDocumentoUnico);

            //        processo.TermoProcesso = _commonService.IdentificarTermoParte(expressoes, processo.Partes);
            //        if (processo.TermoProcesso.IdTermoLocalizacao > 0)
            //        {
            //            processo.CapturarDado = processo.TermoProcesso.CapturarDado;
            //            if (processo.CapturarDado)
            //            {
            //                if (processo.TermoProcesso.BaixarCopia)
            //                    processo.BaixarCopia = true;

            //                if (processo.TermoProcesso.CapturarMovimento)
            //                    processo.CapturarMovimento = true;
            //            }
            //        }

            //        if (processo.CapturarDado && processo.CapturarMovimento)
            //        {
            //            processo.Movimentos = DadosMovimentacao(navegador);
            //        }

            //        // vamos analisar com Renato... nao remover !!!
            //        if (processo.BaixarCopia)
            //        {
            //            //        string folderProcesso = "";
            //            //        if (processo.BaixarCopia)
            //            //            folderProcesso = _gerenciarFisicoService.CriarDiretorioProcesso(folderSolicitacao, processo.EmailCriadoPor, processo.IdSolicitacao, processo.Numero.Replace("-", "").Replace(".", ""));

            //            //        if (!string.IsNullOrWhiteSpace(nomeFinalArquivo))
            //            //            nomeFinalArquivo += "_";

            //            //        nomeFinalArquivo = processo.Numero.Replace("-", "").Replace(".", "");

            //            //        var processamentoDownload = DownloadProcesso(navegadorProcesso, navegador, folderProcesso, folderProcessamento, nomeFinalArquivo, documentoUnico, idEquipamento);
            //            //        if (processamentoDownload.Sucesso)
            //            //        {
            //            //            processamentoDownload.IdentificacaoInstancia = nomeFinalArquivo;

            //            //            if (!_gerenciarFisicoService.DeletarArquivo($"{folderProcesso}", $"*{nomeFinalArquivo}.*"))
            //            //                return retorno;

            //            //            if (_gerenciarFisicoService.TransferirArquivo($"{folderProcessamento}", "", folderProcesso, "", "", ""))
            //            //            {
            //            //                retorno = true;
            //            //                processo.Status = StatusProcesso.Capturado;

            //            //                if (processo.Documentos == null)
            //            //                    processo.Documentos = new List<DownloadDocumentoModel>();

            //            //                processo.Documentos.Add(processamentoDownload);
            //            //                processo.PossuiDocumento = true;
            //            //            }
            //            //        }
            //        }
            //    }

            //}

            return processo;
        }


        private IWebDriver PesquisarProcesso(IWebDriver driver, string numeroProcesso)
        {
            //numeroProcesso = "50113651420208240036"; //"50148555720208240064"; //"50148555720208240064"; //"50037665420208240026"; /////"50148555720208240064"; ///---para testar 
            numeroProcesso = "5013818-15.2020.8.13.0027";

            IWebDriver janelaProcesso = null;
            WebDriverWait navegador = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            try
            {
                IWebElement menuPrincipal = _browserService.ElementVerify(navegador, "LinkText", "Abrir menu", "ElementToBeClickable", new TimeSpan(0, 0, 5));
                if (menuPrincipal == null)
                    return null;


                IWebElement menuProcesso = _browserService.ElementVerify(navegador, "LinkText", "Processo", "ElementToBeClickable", new TimeSpan(0, 0, 5));
                if (menuProcesso == null)
                    return null;

                IWebElement menuPesquisar = _browserService.ElementVerify(navegador, "LinkText", "Pesquisar", "ElementToBeClickable", new TimeSpan(0, 0, 5));
                if (menuPesquisar == null)
                    return null;

                menuPrincipal.Click();
                menuProcesso.Click();
                menuPesquisar.Click();

                IWebElement botaoPesquisar = _browserService.ElementVerify(navegador, "Id", "fPP:searchProcessos", "ElementToBeClickable", new TimeSpan(0, 0, 5));
                if (botaoPesquisar == null)
                    return null;

                IWebElement numeroSequencial = _browserService.ElementVerify(navegador, "Id", "fPP:numeroProcesso:numeroSequencial", "ElementExists", new TimeSpan(0, 0, 5));
                if (numeroSequencial == null)
                    return null;

                IWebElement numeroDigitoVerificador = _browserService.ElementVerify(navegador, "Id", "fPP:numeroProcesso:numeroDigitoVerificador", "ElementExists", new TimeSpan(0, 0, 5));
                if (numeroDigitoVerificador == null)
                    return null;

                IWebElement ano = _browserService.ElementVerify(navegador, "Id", "fPP:numeroProcesso:ano", "ElementExists", new TimeSpan(0, 0, 5));
                if (ano == null)
                    return null;

                IWebElement ramoJustica = _browserService.ElementVerify(navegador, "Id", "fPP:numeroProcesso:ramoJustica", "ElementExists", new TimeSpan(0, 0, 5));
                if (ramoJustica == null)
                    return null;

                IWebElement respectivoTribunal = _browserService.ElementVerify(navegador, "Id", "fPP:numeroProcesso:respectivoTribunal", "ElementExists", new TimeSpan(0, 0, 5));
                if (respectivoTribunal == null)
                    return null;

                IWebElement numeroOrgaoJustica = _browserService.ElementVerify(navegador, "Id", "fPP:numeroProcesso:numeroOrgaoJustica", "ElementExists", new TimeSpan(0, 0, 5));
                if (numeroOrgaoJustica == null)
                    return null;

                //tratar o numero do processo
                string grupo1 = numeroProcesso.Substring(0, 7);
                string grupo2 = numeroProcesso.Substring(8, 2);
                string grupo3 = numeroProcesso.Substring(11, 4);
                string grupo4 = numeroProcesso.Substring(16, 1);
                string grupo5 = numeroProcesso.Substring(18, 2);
                string grupo6 = numeroProcesso.Substring(21, 4);

                numeroSequencial.SendKeys(grupo1);
                numeroDigitoVerificador.SendKeys(grupo2);
                ano.SendKeys(grupo3);
                ramoJustica.SendKeys(grupo4);
                respectivoTribunal.SendKeys(grupo5);
                numeroOrgaoJustica.SendKeys(grupo6);

                botaoPesquisar.Click();

                //var lixo = driver.FindElement(By.XPath("//*[td[contains(.,'Assunto')]")).Text;

                //=====================================================================
                // Aguarda a Pesquisa ser Concluída
                //=====================================================================
                bool continuaLoop = true;
                while (continuaLoop)
                {
                    var pesquisandoProcesso = _browserService.ElementVerify(navegador, "ClassName", "infraImgNormal", "ElementIsVisible", new TimeSpan(0, 0, 10));
                    if (pesquisandoProcesso == null)
                        continuaLoop = false;
                }

                janelaProcesso = driver;
            }
            catch (Exception ex)
            {

            }

            return janelaProcesso;
        }







    }
}
