using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BaixarDejtCore
{

    class Program
    {
        static void Main(string[] args)
        {
            DateTime hoje = DateTime.Now;

            string diaDoMesI = DateTime.Now.Day.ToString();

            #region Firefox
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.dir", "D:\\lixo");
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.download.viewableInternally.enabledTypes", "");
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf;text/plain;application/text;text/xml;application/xml");
            options.SetPreference("pdfjs.disabled", true);
            #endregion

            IWebDriver driver = new FirefoxDriver(options);
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
            dataInicio.SendKeys("15/02/2020");

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
            dataFim.SendKeys("19/02/2021");

            //pesquisa e seleciona o tipo de caderno
            IWebElement cbPesquisaTipoCaderno = driver.FindElement(By.Id("corpo:formulario:tipoCaderno"));

            var optionTc = cbPesquisaTipoCaderno.FindElement(By.XPath("//option[contains(text(),'Judiciário')]"));
            optionTc.Click();

            //pesquisa e seleciona o orgao 
            IWebElement cbPesquisaOrgao = driver.FindElement(By.Id("corpo:formulario:tribunal"));

            foreach (var item in cbPesquisaOrgao.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                string numeroTrt = Regex.Replace(item, "[^0-9.+-]", "");

                if (numeroTrt == "4")
                //if (!string.IsNullOrWhiteSpace(numeroTrt))
                {
                    var optionOrgao = cbPesquisaOrgao.FindElement(By.XPath($"//option[contains(text(),'{item}')]"));
                    optionOrgao.Click();
                    PesquisaDiarios(driver, numeroTrt);
                }
            }

            FecharAplicacao(driver);
        }

        private static void FecharAplicacao(IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
            Environment.Exit(-1);
        }

        private static void PesquisaDiarios(IWebDriver driver, string numeroTrt)
        {
            IWebElement pesquisaDiarios = driver.FindElement(By.Id("corpo:formulario:botaoAcaoPesquisar"));
            pesquisaDiarios.Click();

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

                IWebElement tableDiarios = driver.FindElement(By.XPath("//*[@id='diarioInferiorNav']/preceding::tbody[1]"));

                var linhasDiario = tableDiarios.FindElements(By.XPath("tr"));

                foreach (var item in linhasDiario)
                {
                    linha++;
                    if (linha >= 2)
                    {
                        IWebElement colunaDiario = tableDiarios.FindElement(By.XPath($"//tbody/tr[{linha}]/td[3]/button"));

                        colunaDiario.Click();
                        System.Threading.Thread.Sleep(8000);

                        RenomearArquivo(numeroTrt);
                    }
                }

                //avanca para a proxima pagina
                IWebElement botaoProxPagina = driver.FindElement(By.XPath("//span[@class='ico iNavProximo']"));
                botaoProxPagina.Click();
            }

        }

        private static void RenomearArquivo(string numeroTrt)
        {

            var ultArqBaixado = new DirectoryInfo("D:\\lixo")
                                                            .GetFiles()
                                                            .OrderByDescending(f => f.LastWriteTime)
                                                            .Select(x => x.FullName)
                                                            .FirstOrDefault();

            string nomeArquivo = Path.GetFileName(ultArqBaixado);
            string caminhoArquivo = Path.GetDirectoryName(ultArqBaixado);
            string nomeFinalArquivo = caminhoArquivo + "\\TRT" + numeroTrt + "_" + nomeArquivo;

            System.IO.File.Move(ultArqBaixado, nomeFinalArquivo);
        }
    }
}
