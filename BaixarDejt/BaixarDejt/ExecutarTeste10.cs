using System;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BaixarDejt
{
    public class ExecutarTeste10
    {

        public static void Testar10()
        {
            #region Firefox
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.dir", "C:\\Pastas de Trabalho\\Projetos\\Captura Dados Processo\\DiarioOficialALer");
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.download.viewableInternally.enabledTypes", "");
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf;text/plain;application/text;text/xml;application/xml");
            options.SetPreference("pdfjs.disabled", true);
            options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            //options.SetPreference("debuggerAddress", "localhost:1234");
            #endregion

            TesteViaAgilitySelenium(options);

        }

        private static void TesteViaAgilitySelenium(FirefoxOptions options)
        {
            IWebDriver driver = new FirefoxDriver(options);

            driver.Url = "https://opensource-demo.orangehrmlive.com/index.php/auth/login";
            driver.Manage().Window.Maximize();

            IWebElement txtUser = driver.FindElement(By.Id("txtUsername"));
            txtUser.SendKeys("Admin");

            IWebElement txtPassword = driver.FindElement(By.Id("txtPassword"));
            txtPassword.SendKeys("admin123");

            IWebElement btnLogin = driver.FindElement(By.Id("btnLogin"));
            btnLogin.Click();

            System.Threading.Thread.Sleep(1000);

            IWebElement menupimviewPimModule = driver.FindElement(By.Id("menu_pim_viewPimModule"));
            menupimviewPimModule.Click();

            TimeSpan horaInicio = DateTime.Now.TimeOfDay;
            TimeSpan horaFim;

            var rows = driver.FindElements(By.XPath("//tbody//tr"));

            foreach (var row in rows)
            {
                var name = row.FindElement(By.XPath("./td[3]")).Text.Trim();
                
                Console.WriteLine("Nome.......: " + name);
                Console.WriteLine("...");
            }

            horaFim = DateTime.Now.TimeOfDay;
            var tempoDecorrido = (horaFim - horaInicio);

            Console.WriteLine("hora inicio.. " + horaInicio);
            Console.WriteLine("hora fim..... " + horaFim);
            Console.WriteLine("tempo total.. " + tempoDecorrido);

            Console.WriteLine("hora inicio" + horaInicio);
            Console.WriteLine("");


            #region Agilyti
            Console.WriteLine("------------- A G I L Y T I ----------");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("");

            horaInicio = DateTime.Now.TimeOfDay;
            Console.WriteLine("hora inicio" + horaInicio);

            IWebElement ie = driver.FindElement(By.Id("resultTable"));

            string innerHtml = ie.GetAttribute("innerHTML");
   
            HtmlAgilityPack.HtmlDocument htmlDocT = new HtmlAgilityPack.HtmlDocument();
            htmlDocT.OptionFixNestedTags = true;
            htmlDocT.LoadHtml(innerHtml);

            if (htmlDocT.DocumentNode != null)
            {
                var rowsAgt = htmlDocT.DocumentNode.SelectNodes("./tbody/tr");

                foreach (var row in rowsAgt)
                {
                    var name = HtmlEntity.DeEntitize(row.SelectSingleNode("./td[3]").InnerText.Trim());

                    Console.WriteLine("Nome.......: " + name);
                    Console.WriteLine("...");
                }

                horaFim = DateTime.Now.TimeOfDay;
                tempoDecorrido = (horaFim - horaInicio);
                Console.WriteLine("hora inicio.. " + horaInicio);
                Console.WriteLine("hora fim..... " + horaFim);
                Console.WriteLine("tempo total.. " + tempoDecorrido);

                Console.ReadKey();

                // driver.Quit();
            }

            #endregion

        }
    }
}
