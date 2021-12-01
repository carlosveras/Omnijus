using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using System.Text;

namespace BaixarDejt
{
    public class ExecutarTeste13
    {
        public static void Capturar()
        {

            IWebDriver driver = ConfigFirefox.ConfigureFirefox();

            driver.Url = "https://www.tjpe.jus.br/poder-judiciario/comarcas-de-pernambuco";

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            System.Threading.Thread.Sleep(2000);

            if (driver.FindElement(By.ClassName("button-aceita")).Displayed)
            {
                IWebElement btnFechaCok = driver.FindElement(By.Id("aceita-cookies"));
                btnFechaCok.Click();
            }

            driver.SwitchTo().Frame(driver.FindElement(By.Id("_48_INSTANCE_cjMZHNi3f0K7_iframe")));

            System.Threading.Thread.Sleep(2000);
            RecuperarComarcas(driver);

            FechaAplicacao(driver);

        }

        private static void RecuperarComarcas(IWebDriver driver)
        {
            System.Threading.Thread.Sleep(2000);

            string[] letrasPesquisa = new string[26];
            int i = 0;

            IWebElement tabelaLetras = driver.FindElement(By.XPath("//span[@class='texto02']//following::table[1]/tbody"));

            var linhasLetras = tabelaLetras.FindElements(By.XPath("tr"));
            var todasLetras = tabelaLetras.FindElements(By.TagName("a"));

            foreach (var item in todasLetras)
            {
                letrasPesquisa[i] = item.Text;
                i++;
            }

            foreach (var item in letrasPesquisa)
            {
                string qLetra = item;
                if (!String.IsNullOrEmpty(qLetra))
                {
                    System.Threading.Thread.Sleep(2000);

                    IWebElement meulink = driver.FindElement(By.LinkText(qLetra));
                    meulink.Click();
                    PesquisarCidades(driver);
                }
            }
        }

        private static void PesquisarCidades(IWebDriver driver)
        {
            System.Threading.Thread.Sleep(2000);
            IWebElement tabelaCidades = driver.FindElement(By.XPath("//span[@class='texto02']//following::table[1]/tbody/following::table"));

            foreach (var cidade in tabelaCidades.Text.Split(new char[] {'\r','\n'}, StringSplitOptions.RemoveEmptyEntries))
            {
                if (!String.IsNullOrEmpty(cidade) && !cidade.Contains("Cidades"))
                {
                    bool cidadeOK = driver.FindElements(By.LinkText(cidade)).Count > 0;

                    if (cidadeOK)
                    {
                        IWebElement linkCidade = driver.FindElement(By.LinkText(cidade));
                        linkCidade.Click();
                        System.Threading.Thread.Sleep(2000);

                        RecuperarDadosAsync(driver);
                        driver.Navigate().Back();
                    }
                }
            }

        }

        private static async void RecuperarDadosAsync(IWebDriver driver)
        {
            System.Threading.Thread.Sleep(3000);

            IWebElement tabelaDados = driver.FindElement(By.XPath("//span[@class='texto02']//following::table[1]/tbody/following::table[3]"));

            var linhasDados = tabelaDados.FindElements(By.XPath("tbody/tr"));
            //string dadoLinha = string.Empty;
            string linhaParcial = string.Empty;
            string linhaCompleta = string.Empty;
            StringBuilder linhaC = new StringBuilder();

            foreach (var dado in linhasDados)
            {
                string dadoLinha = dado.Text; //.Replace(":", "|").Trim();
                linhaParcial =  dadoLinha.Trim() + "|";
                //linhaC.Append(linhaCompleta);
                linhaCompleta = string.Join("", linhaParcial);

                //using (StreamWriter file = new StreamWriter("c:\\lixo\\lixao.txt", append: true))
                //{
                //    await file.WriteLineAsync(linhaCompleta);
                //}
            }

            using (StreamWriter file = new StreamWriter("c:\\lixo\\lixao.txt", append: true))
            {
                await file.WriteLineAsync(linhaCompleta.ToString());
            }
        }

        private static void FechaAplicacao(IWebDriver driver)
        {
            driver.Close();
            driver.Dispose();
            Environment.Exit(-1);
        }

    }
}

