using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaixarDejt
{
    public class ExecutarTeste04
    {
        /// <summary>
        /// conceito de tupla - metodo que retorna mais de um objeto
        /// </summary>
        public static void Testar04()
        {
            var result = MontaFirefox();
            IWebDriver myDriver = result.Item1;
            int processId = result.Item2;
            myDriver.Navigate().GoToUrl("http://uol.com");
        }

        
        private static  Tuple<IWebDriver, int> MontaFirefox()
        {
            IWebDriver driver = null;

            #region FirefoxDriverService
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Projetos\BaixarDejt\BaixarDejt\bin\Debug");
            #endregion

            #region Firefox
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.dir", "C:\\Pastas de Trabalho\\Projetos\\Captura Dados Processo\\DiarioOficialALer");
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.download.viewableInternally.enabledTypes", "");
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf;text/plain;application/text;text/xml;application/xml");
            options.SetPreference("pdfjs.disabled", true);

            driver = new FirefoxDriver(service, options);
            driver.Url = "https://google.com";

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            #endregion

            #region Funcionou
            int processId = service.ProcessId;
            #endregion

            var result = Tuple.Create(driver, processId);
            return result;
        }

    }
}
