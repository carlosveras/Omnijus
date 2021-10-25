using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BaixarDejt
{
    public class ExecutarTeste08
    {


        public static void Testar08()
        {

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

            IWebDriver driver = new FirefoxDriver(service, options);
            driver.Url = "https://google.com";

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            #endregion

            //string texto = "<td>o texto tem caracteres não especiais</td>";
            string pageSource = driver.PageSource;
            //Console.WriteLine("Page source: " + pageSource);

            WebClient client = new WebClient();
            Uri ur = new Uri($"https://google.com");
            client.Headers["Content-Type"] = "application/json";
            //string reply = client.UploadString(ur, "Post");
            string teste = client.DownloadString(ur);

            var html = teste;

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//input");

            foreach (var node in htmlNodes)
            {
                Console.WriteLine(node.XPath);
                Console.WriteLine();
            }

            Console.ReadKey();

            //using (var client = new WebClient())
            //{
            //    var xml = client.DownloadString("https://google.com");
            //    using (var strReader = new StringReader(xml))
            //    using (var reader = XmlReader.Create(strReader))
            //    {
            //        using (TextReader textReader = new StreamReader(xml.ToString()))
            //        {
            //            string line;
            //            while ((line = textReader.ReadLine()) != null)
            //            {
            //                Console.WriteLine(line);
            //                //Console.ReadKey();
            //            }
            //        }
            //    }
            //}

            //byte[] data = File.ReadAllBytes(pageSource);
            //using (MemoryStream memoryStream = new MemoryStream(data))
            //{
            //using (TextReader textReader = new StreamReader(pageSource.ToString()))
            //{
            //    string line;
            //    while ((line = textReader.ReadLine()) != null)
            //    {
            //        Console.WriteLine(line);
            //        Console.ReadKey();
            //    }
            //}
            //}



            Console.ReadKey();
            driver.Quit();
        }

    }
}
