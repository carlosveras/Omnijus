using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BaixarDejt
{
    public class ExecutarTeste01
    {
        public static void Capturar()
        {
            DateTime hoje = DateTime.Now;

            string diaDoMesI = DateTime.Now.Day.ToString();
            List<string> opcoesCombo = new List<string>();

            #region Firefox
            //FirefoxOptions options = new FirefoxOptions();
            //options.SetPreference("browser.download.folderList", 2);
            //options.SetPreference("browser.download.dir", "C:\\Pastas de Trabalho\\Projetos\\Captura Dados Processo\\DiarioOficialALer");
            //options.SetPreference("browser.download.useDownloadDir", true);
            //options.SetPreference("browser.download.viewableInternally.enabledTypes", "");
            //options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf;text/plain;application/text;text/xml;application/xml");
            //options.SetPreference("pdfjs.disabled", true);
            #endregion

            #region pegaIdsFirefoxAntes
            IEnumerable<int> pidsFfAntes = Process.GetProcessesByName("firefox").Select(p => p.Id);
            #endregion

            #region pegaIdsGekAntes
            IEnumerable<int> pidsGcAntes = Process.GetProcessesByName("geckodriver").Select(p => p.Id);
            #endregion

            IWebDriver driver = ConfigFirefox.ConfigureFirefox();


            //IWebDriver driver = new FirefoxDriver(options);

            driver.Url = "https://dejt.jt.jus.br/dejt/f/n/diariocon";

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            #region CalendarioInicio
            /////abre o calendarioinicio
            //IWebElement iconeCalendarioI = driver.FindElement(By.XPath("//.[@id='corpo:formulario:dataIni']//following::button[1]"));
            //iconeCalendarioI.Click();

            ////seleciona o dia no calendario
            //IWebElement inputDia = driver.FindElement(By.XPath($"//a[normalize-space()='{diaDoMesI}']"));
            //inputDia.Click();
            #endregion

            IWebElement dataInicio = driver.FindElement(By.Id("corpo:formulario:dataIni"));
            dataInicio.Click();
            dataInicio.SendKeys("01/11/2021");

            #region CalendarioFim
            /////abre o calendariofim
            //IWebElement iconeCalendarioF = driver.FindElement(By.XPath("//.[@id='corpo:formulario:dataFim']//following::button[1]"));
            //iconeCalendarioF.Click();

            ////seleciona o dia no calendario
            //IWebElement inputDiF = driver.FindElement(By.XPath($"//a[normalize-space()='{diaDoMesF}']"));
            //inputDiF.Click();
            #endregion

            IWebElement dataFim = driver.FindElement(By.Id("corpo:formulario:dataFim"));
            dataFim.Click();
            dataFim.SendKeys("05/11/2021");

            //pesquisa e seleciona o tipo de caderno
            IWebElement cbPesquisaTipoCaderno = driver.FindElement(By.Id("corpo:formulario:tipoCaderno"));

            var optionTc = cbPesquisaTipoCaderno.FindElement(By.XPath("//option[contains(text(),'Judiciário')]"));
            optionTc.Click();

            System.Threading.Thread.Sleep(2000);

            //Console.ReadKey();
            //System.Environment.Exit(1);

            //pesquisa e seleciona o orgao 
            IWebElement cbPesquisaOrgao = driver.FindElement(By.Id("corpo:formulario:tribunal"));

            foreach (var item in cbPesquisaOrgao.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                int trtAtual = 0;
                string numeroTrt = Regex.Replace(item, "[^0-9.+-]", "");

                if (!string.IsNullOrEmpty(numeroTrt))
                    trtAtual = Convert.ToInt16(numeroTrt);

                if (trtAtual > 0)
                {
                    var optionOrgao = driver.FindElement(By.XPath($"//option[contains(text(),'{item}')]"));
                    optionOrgao.Click();
                    PesquisaDiarios(driver, numeroTrt);
                }
            }

            RenomearAquivoParenteses();
            FecharAplicacao(driver);
        }

        private static void PesquisaDiarios(IWebDriver driver, string numeroTrt)
        {
            IWebElement pesquisaDiarios = driver.FindElement(By.Id("corpo:formulario:botaoAcaoPesquisar"));
            pesquisaDiarios.Click();

            if (driver.FindElements(By.XPath("//.[contains(text(),'Atendimento ao usuário do DEJT:')]")).Count > 0)
                FecharAplicacao(driver);

            if (driver.FindElements(By.XPath("//span[@class='ico iAlertaVermelho']")).Count == 0)
            {

                string textoLinhas = driver.FindElement(By.XPath("//select[@id='corpo:formulario:tribunal']//following::td[@class='celulaFormulario'][2]")).Text;

                int posicao = textoLinhas.LastIndexOf("de");
                int qtDiarios = Convert.ToInt16(textoLinhas.Substring(posicao).Replace("de ", ""));
                int qtPaginas = (qtDiarios / 30);

                if (qtPaginas <= 0)
                    qtPaginas = 1;

                BaixarArquivos(driver, qtPaginas, numeroTrt);
            }
        }

        private static void BaixarArquivos(IWebDriver driver, int qtPaginas, string numeroTrt)
        {

            for (int i = 0; i < qtPaginas; i++)
            {
                int linha = 0;
                IWebElement tableDiarios = null;
                IWebElement botaoProxPagina = null;

                if (qtPaginas == 1)
                    tableDiarios = driver.FindElement(By.XPath("//*[@id='diarioInferiorNav']/preceding::tbody[1]"));
                if (qtPaginas >= 2)
                    tableDiarios = driver.FindElement(By.XPath("//span[@class='ico iNavUltimo']//following::table[1]/tbody[1]"));

                var linhasDiario = tableDiarios.FindElements(By.XPath("tr"));

                foreach (var item in linhasDiario)
                {
                    linha++;
                    if (linha >= 2)
                    {
                        IWebElement colunaDiario = tableDiarios.FindElement(By.XPath($"//tbody/tr[{linha}]/td[3]/button"));

                        colunaDiario.Click();

                        //string nomeFinalArquivo = VerificarDowload(driver);
                        string nomeFinalArquivo = FinalizouDownload();
                        RenomearArquivo(numeroTrt, nomeFinalArquivo);
                    }
                }

                //avanca para a proxima pagina se houver
                if (driver.FindElements(By.XPath("//span[@class='ico iNavProximo']")).Count > 0)
                {
                    botaoProxPagina = driver.FindElement(By.XPath("//span[@class='ico iNavProximo']"));
                    botaoProxPagina.Click();
                }
            }

        }

        private static void RenomearArquivo(string numeroTrt, string nomeArq)
        {

            var ultArqBaixado = new DirectoryInfo("C:\\Pastas de Trabalho\\Projetos\\Captura Dados Processo\\DiarioOficialALer")
                                            .GetFiles()
                                            .OrderByDescending(f => f.LastWriteTime)
                                            .Select(x => x.FullName)
                                            .FirstOrDefault();

            //string ultArqBaixado = "C:\\Pastas de Trabalho\\Projetos\\Captura Dados Processo\\DiarioOficialALer\\" + nomeArq;

            //string nomeArquivo = Path.GetFileName(ultArqBaixado);
            //string caminhoArquivo = Path.GetDirectoryName(nomeArq);
            //string somenteNome = Path.GetFileName(nomeArq);
            //string nomeFinalArquivo = caminhoArquivo + "\\TRT" + numeroTrt + "_" + somenteNome;
            //string novoNome = ultArqBaixado;
            //int index1 = novoNome.LastIndexOf('\\') + 1;
            //novoNome = novoNome.Substring(0, index1) + "TRT_" + numeroTrt + "_" + novoNome.Substring(index1);

            string caminhoArquivo = Path.GetDirectoryName(ultArqBaixado);
            string somenteNome = Path.GetFileName(ultArqBaixado);
            string nomeFinalArquivo = caminhoArquivo + "\\TRT" + numeroTrt + "_" + somenteNome;

            System.IO.File.Move(ultArqBaixado, nomeFinalArquivo);
        }

        private static void RenomearAquivoParenteses()
        {
            DirectoryInfo dInfo = new DirectoryInfo("C:\\Pastas de Trabalho\\Projetos\\Captura Dados Processo\\DiarioOficialALer");
            FileInfo[] infos = dInfo.GetFiles();

            foreach (FileInfo f in infos)
            {
                File.Move(f.FullName, f.FullName.Replace("(1)", ""));
            }
        }

        private static void FecharAplicacao(IWebDriver driver)
        {
            driver.Close();
            driver.Quit();
            Environment.Exit(-1);
        }

        #region nova
        private static string FinalizouDownload()
        {
            string nomeArquivo = "";
            string folderDownload = "C:\\Pastas de Trabalho\\Projetos\\Captura Dados Processo\\DiarioOficialALer";
            string extensoesEsperadas = "pdf";

            try
            {
                //=================================================================================
                // Verifica se o Download Começou
                //=================================================================================
                bool comecouDownload = false;
                while (!comecouDownload)
                {
                    using (var watcher = new FileSystemWatcher(folderDownload))
                    {
                        var arquivoCriado = watcher.WaitForChanged(WatcherChangeTypes.All, 2000);
                        if (arquivoCriado.TimedOut)
                        {
                            string[] arquivosDiretorio = Directory.GetFiles(folderDownload, "*.*");
                            if (arquivosDiretorio.Length > 0)
                                comecouDownload = true;
                        }
                    }
                }
                //=================================================================================

                //=================================================================================
                // Verifica se o Download Acabou
                //=================================================================================
                bool acabouDownload = false;
                while (!acabouDownload)
                {
                    using (var watcher = new FileSystemWatcher(folderDownload))
                    {
                        var arquivoCriado = watcher.WaitForChanged(WatcherChangeTypes.All, 2000);
                        if (arquivoCriado.TimedOut)
                        {
                            acabouDownload = true;
                            string[] arquivosDiretorio = Directory.GetFiles(folderDownload, "*.*");
                            foreach (string arquivo in arquivosDiretorio)
                            {
                                nomeArquivo = arquivo.Replace(folderDownload, "");
                                string extensaoArquivo = "";
                                if (nomeArquivo.LastIndexOf(".") > 0)
                                    extensaoArquivo = nomeArquivo.Substring(nomeArquivo.LastIndexOf(".") + 1);

                                if (!extensoesEsperadas.Contains(extensaoArquivo.ToLower()))
                                    acabouDownload = false;
                            }
                        }
                    }
                }
                //=================================================================================

                //if (comecouDownload && acabouDownload)
                //    retorno = true;

                //if (comecouDownload && acabouDownload)
                //    retorno = true;


            }
            catch (Exception ex)
            {
            }

            return nomeArquivo;
        }
        #endregion

    }
}

