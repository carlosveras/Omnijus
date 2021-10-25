using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BaixarDejt
{
    public class ExecutarTeste06
    {

        public static void Testar06()
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

            MataProcessoEFilhos(service.ProcessId, service.ProcessId);
        }

        private static void MataProcessoEFilhos(int processId, int idProcessoGeeck)
        {

            ManagementObjectSearcher searcher = new ManagementObjectSearcher
                    ("Select * From Win32_Process Where ParentProcessID=" + processId);
            ManagementObjectCollection moc = searcher.Get();

            try
            {
                foreach (ManagementObject mo in moc)
                {

                    if (moc.Count > 0)
                    {
                        Process proc = Process.GetProcessById(Convert.ToInt32(mo["ProcessID"]));
                        proc.Kill();
                    }

                    MataProcessoEFilhos(Convert.ToInt32(mo["ProcessID"]), idProcessoGeeck);
                }

                Process procGk = Process.GetProcessById(idProcessoGeeck);
                procGk.Kill();

            }
            catch (ArgumentException ex)
            {
                
            }
        }
    }
}
