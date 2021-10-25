using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Net;

namespace BaixarDejt
{
    public class ExecutarTeste09
    {


        public static void Testar09()
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

            ViaAgility();
            ViaSeleniumFirefox(options);
            //ViaSeleniumChrome();

            //TesteParaConverter(options);
        }

        private static void TesteParaConverter(FirefoxOptions options)
        {
            IWebDriver driver = new FirefoxDriver(options);

            DateTime horaInicio = DateTime.Now;
            DateTime horaFim = DateTime.Now;

            Console.WriteLine("hora inicio.. " + horaInicio);

            driver.Url = "https://www.mtggoldfish.com/index/modern#online";
            driver.Manage().Window.Maximize();

            System.Threading.Thread.Sleep(10000);

            IJavaScriptExecutor exe = (IJavaScriptExecutor)driver;
            string fx = exe.ExecuteScript("return window.length").ToString();

            //var qFrame = exe.ExecuteScript("return document.getElementById('iframe');");
            //exe.ExecuteScript("document.getElementById('iframe').contentWindow.document.getElementById('assets').click;");


            var f = driver.FindElements(By.TagName("iframe"));
            int frameNr = 0;

            foreach (var item in f)
            {

                //driver.SwitchTo().Frame(frameNr);
                try
                {
                    Console.WriteLine("frame numero...: " + " " + frameNr);
                    Console.WriteLine(item.FindElement(By.Id("assets")));
                }
                catch (Exception)
                {
                    Console.WriteLine("NAO ENCONTROU");
                    continue;
                }
                frameNr++;
            }

            //Console.ReadKey();

            //IWebElement linkMkt = driver.FindElement(By.Id("assets"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("arguments[0].scrollIntoView();", element);

            //driver.SwitchTo().Frame(1);

            //js.ExecuteScript("document.getElementById('assets').focus();");
            js.ExecuteScript("document.getElementById('assets').click;");

            //js.ExecuteScript("arguments[0].click;");

            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //var lixo = js.ExecuteScript("document.getElementById('assets');");
            //var innerTextlixo = js.ExecuteScript(" return document.getElementById('assets');").ToString();
            //"http://www4.tjrj.jus.br/consultaProcessoWebV2/consultaProc.do?v=2&FLAGNOME=&back=1&tipoConsulta=publica&numProcesso=0000006-13.2021.8.19.0213";

            Console.WriteLine("\nDisplaying Data :\n");

            var uriString = "https://www.mtggoldfish.com/index/modern#online";

            WebClient myWebClient = new WebClient();
            // Download home page data. 
            Console.WriteLine("Accessing {0} ...", uriString);
            // Open a stream to point to the data stream coming from the Web resource.
            Stream myStream = myWebClient.OpenRead(uriString);

            Console.WriteLine("\nDisplaying Data :\n");
            StreamReader stream = new StreamReader(myStream);
            var allData = stream.ReadToEnd();

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            // There are various options, set as needed
            htmlDoc.OptionFixNestedTags = true;

            htmlDoc.LoadHtml(allData);  //to load from a string (was htmlDoc.LoadXML(xmlString)

            if (htmlDoc.DocumentNode != null)
            {
                var rows = htmlDoc.DocumentNode.SelectNodes("//div[@class='index-price-table-online']//tbody//tr");

                foreach (var row in rows)
                {
                    var name = HtmlEntity.DeEntitize(row.SelectSingleNode(".//span[@class='card_name']/a").InnerText.Trim());
                    var price = row.SelectSingleNode("./td[4]").InnerText.Trim();

                    Console.WriteLine(name + ": " + price);
                    Console.WriteLine("...");
                }
            }

            IWebElement linkCard = driver.FindElement(By.XPath("//div[@class='index-price-table-online']//tbody//tr[1]//td[1]"));
            //IWebElement linkCardR = driver.FindElement(By.Id("Ruin Crab[ZNR]"));


            //Actions action = new Actions(driver);
            //action.Click(linkCard);
            //action.Perform();

            //ActionChains(driver).move_to_element(element).click().perform()

            linkCard.Click();

            Console.ReadKey();
        }

        private static void ViaSeleniumChrome()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.mtggoldfish.com/index/modern#online");

            DateTime horaInicio = DateTime.Now;
            DateTime horaFim;

            Console.WriteLine("hora inicio.. " + horaInicio);

            driver.Manage().Window.Maximize();
            Console.WriteLine("\nDisplaying Data :\n");

            var rows = driver.FindElements(By.XPath("//div[@class='index-price-table-online']//tbody//tr"));

            foreach (var row in rows)
            {
                var name = row.FindElement(By.XPath(".//span[@class='card_name']/a")).Text.Trim();
                var price = row.FindElement(By.XPath("./td[4]")).Text.Trim();

                Console.WriteLine(name + ": " + price);
                Console.WriteLine("...");
            }

            horaFim = DateTime.Now;
            var tempoDecorrido = (horaFim - horaInicio);
            Console.WriteLine("hora inicio.. " + horaInicio);
            Console.WriteLine("hora fim..... " + horaFim);
            Console.WriteLine("tempo total.. " + tempoDecorrido);

            Console.ReadKey();
            driver.Close();
        }

        private static void ViaSeleniumFirefox(FirefoxOptions options)
        {
            IWebDriver driver = new FirefoxDriver(options);

            DateTime horaInicio = DateTime.Now;
            DateTime horaFim;

            Console.WriteLine("hora inicio.. " + horaInicio);

            driver.Url = "https://www.mtggoldfish.com/index/modern#online";


            driver.Manage().Window.Maximize();
            Console.WriteLine("\nDisplaying Data :\n");

            var rows = driver.FindElements(By.XPath("//div[@class='index-price-table-online']//tbody//tr"));

            foreach (var row in rows)
            {
                var name = row.FindElement(By.XPath(".//span[@class='card_name']/a")).Text.Trim();
                var price = row.FindElement(By.XPath("./td[4]")).Text.Trim();

                Console.WriteLine(name + ": " + price);
                Console.WriteLine("...");
            }

            horaFim = DateTime.Now;
            var tempoDecorrido = (horaFim - horaInicio);
            Console.WriteLine("hora inicio.. " + horaInicio);
            Console.WriteLine("hora fim..... " + horaFim);
            Console.WriteLine("tempo total.. " + tempoDecorrido);

            Console.ReadKey();
            driver.Close();
        }

        private static void ViaAgility()
        {
            DateTime horaInicio = DateTime.Now;
            DateTime horaFim;

            Console.WriteLine("hora inicio" + horaInicio);

            var uriString = "https://www.mtggoldfish.com/index/modern#online";

            WebClient myWebClient = new WebClient();
            // Download home page data. 
            Console.WriteLine("Accessing {0} ...", uriString);
            // Open a stream to point to the data stream coming from the Web resource.
            Stream myStream = myWebClient.OpenRead(uriString);

            Console.WriteLine("\nDisplaying Data :\n");
            StreamReader stream = new StreamReader(myStream);
            var allData = stream.ReadToEnd();

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            // There are various options, set as needed
            htmlDoc.OptionFixNestedTags = true;

            htmlDoc.LoadHtml(allData);  //to load from a string (was htmlDoc.LoadXML(xmlString)

            if (htmlDoc.DocumentNode != null)
            {
                var rows = htmlDoc.DocumentNode.SelectNodes("//div[@class='index-price-table-online']//tbody//tr");

                foreach (var row in rows)
                {
                    var name = HtmlEntity.DeEntitize(row.SelectSingleNode(".//span[@class='card_name']/a").InnerText.Trim());
                    var price = row.SelectSingleNode("./td[4]").InnerText.Trim();
                    var nameb = HtmlEntity.DeEntitize(row.SelectSingleNode(".//span[@class='card_name']/a").InnerText.Trim());

                    Console.WriteLine(name + ": " + price);
                    Console.WriteLine("...");
                }

                horaFim = DateTime.Now;
                var tempoDecorrido = (horaFim - horaInicio);
                Console.WriteLine("hora inicio.. " + horaInicio);
                Console.WriteLine("hora fim..... " + horaFim);
                Console.WriteLine("tempo total.. " + tempoDecorrido);

                Console.ReadKey();
            }


        }
    }
}

