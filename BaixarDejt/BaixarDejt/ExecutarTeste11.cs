using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace BaixarDejt
{
    public class ExecutarTeste11
    {

        public static void Testar11()
        {
            #region Firefox
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.dir", "C:\\Pastas de Trabalho\\Projetos\\Captura Dados Processo\\DiarioOficialALer");
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.download.viewableInternally.enabledTypes", "");
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf;text/plain;application/text;text/xml;application/xml");
            options.SetPreference("pdfjs.disabled", true);
            //options.AddArgument("--headless");
            //options.AddArgument("--disable-gpu");
            //options.SetPreference("debuggerAddress", "localhost:1234");
            #endregion

            TesteViaAgilitySelenium(options);

        }

        private static void TesteViaAgilitySelenium(FirefoxOptions options)
        {
            IWebDriver driver = new FirefoxDriver(options);

            driver.Url = "http://google.com";
            driver.Manage().Window.Maximize();

            IWebElement txtPesquisar = driver.FindElement(By.Name("q"));
            txtPesquisar.SendKeys("Webmotors");

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement btnPesquisar = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]"));
            btnPesquisar.Click();
            

        }


    }
}
