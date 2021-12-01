using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace BaixarDejt
{
    public class ConfigFirefox
    {
        public static IWebDriver ConfigureFirefox()
        {
            IWebDriver driver = null;

            #region optionsFirefox
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("browser.download.folderList", 2);
            options.SetPreference("browser.download.dir", "C:\\Pastas de Trabalho\\Projetos\\Captura Dados Processo\\DiarioOficialALer");
            options.SetPreference("browser.download.useDownloadDir", true);
            options.SetPreference("browser.download.viewableInternally.enabledTypes", "");
            options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf;text/plain;application/text;text/xml;application/xml");
            options.SetPreference("pdfjs.disabled", true);
            options.SetPreference("assume_untrusted_issuer", false);
            options.SetPreference("secure_ssl", true);
            options.AcceptInsecureCertificates = true;
            #endregion

            #region perfilFirefox
            FirefoxProfile perfil = new FirefoxProfile();
            perfil.AssumeUntrustedCertificateIssuer = true;
            perfil.AcceptUntrustedCertificates = true;
            options.Profile = perfil;
            #endregion

            driver = new FirefoxDriver(options);
            return driver;
        }

    }
}
