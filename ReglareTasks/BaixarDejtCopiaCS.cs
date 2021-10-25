using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaixarDejt
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime hoje = DateTime.Now;

            string diaDoMesI = DateTime.Now.Day.ToString();
            diaDoMesI = "7";
            string diaDoMesF = "7";

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

            ///abre o calendarioinicio
            IWebElement iconeCalendarioI = driver.FindElement(By.XPath("//.[@id='corpo:formulario:dataIni']//following::button[1]"));
            iconeCalendarioI.Click();

            //seleciona o dia no calendario
            IWebElement inputDia = driver.FindElement(By.XPath($"//a[normalize-space()='{diaDoMesI}']"));
            inputDia.Click();


            ///abre o calendariofim
            IWebElement iconeCalendarioF = driver.FindElement(By.XPath("//.[@id='corpo:formulario:dataFim']//following::button[1]"));
            iconeCalendarioF.Click();

            //seleciona o dia no calendario
            IWebElement inputDiF = driver.FindElement(By.XPath($"//a[normalize-space()='{diaDoMesF}']"));
            inputDiF.Click();

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
                    PesquisaDiarios(driver);
                }
            }

            driver.Close();
            driver.Dispose();
        }

        private static void PesquisaDiarios(IWebDriver driver)
        {
            IWebElement pesquisaDiarios = driver.FindElement(By.Id("corpo:formulario:botaoAcaoPesquisar"));
            pesquisaDiarios.Click();

            IWebElement semResultados = driver.FindElement(By.XPath("//span[@class='ico iAlertaVermelho']"));

            if (!semResultados.Displayed && !semResultados.Enabled) //rever isvisible
            {
                string textoLinhas = driver.FindElement(By.XPath("//select[@id='corpo:formulario:tribunal']//following::td[@class='celulaFormulario'][2]")).Text;

                int posicao = textoLinhas.LastIndexOf("de");
                int qtDiarios = Convert.ToInt16(textoLinhas.Substring(posicao).Replace("de ", ""));
                int qtPaginas = (qtDiarios / 30);

                if (qtPaginas <= 0)
                    qtPaginas = 1;

                BaixarArquivos(driver, qtPaginas);
            }
        }

        private static void BaixarArquivos(IWebDriver driver, int qtPaginas)
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
                        System.Threading.Thread.Sleep(3000);
                    }
                }

            }



        }

        ///////// //*[@id="diarioInferiorNav"]
        ///////// //.[@class='ico iNavProximo'] -- a partir da segunda pagina
        //////// //.[@class='botao_menu ui-state-default plc-botao']
        //////// //select[@id='corpo:formulario:tribunal']//following::button[@class='botao_menu ui-state-default plc-botao']
        /////// //tbody/tr[2]/td[3]/button[1] <-- comeca sempre na 2
        ////// //div[@id='diarioCon']//fieldset[@class='plc-fieldset']
        /////fieldset[@class='plc-fieldset']//table[@class='plc-table-tabsel delimitador tabelaSelecao']
        ///plcLogicaItens:0:j_id131




    }
}
