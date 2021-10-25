using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;

namespace CapturarComarcas
{
    class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new FirefoxDriver
            {
                Url = "https://www.tjpe.jus.br/poder-judiciario/comarcas-de-pernambuco"
            };

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            if (driver.FindElement(By.ClassName("button-aceita")).Displayed)
            {
                IWebElement btnFechaCok = driver.FindElement(By.Id("aceita-cookies"));
                btnFechaCok.Click();
            }

            driver.SwitchTo().Frame(driver.FindElement(By.Id("_48_INSTANCE_cjMZHNi3f0K7_iframe")));

            RecuperarComarcas(driver);

            FechaAplicacao(driver);
        }

        private static void RecuperarComarcas(IWebDriver driver)
        {
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
                    IWebElement meulink = driver.FindElement(By.LinkText(qLetra));
                    meulink.Click();
                    PesquisarCidades(driver);
                }
            }
        }

        private static void PesquisarCidades(IWebDriver driver)
        {
            IWebElement tabelaCidades = driver.FindElement(By.XPath("//span[@class='texto02']//following::table[1]/tbody/following::table"));

            foreach (var cidade in tabelaCidades.Text.Split("\r\n"))
            {
                if (!String.IsNullOrEmpty(cidade) && !cidade.Contains("Cidades"))
                {
                    bool cidadeOK = driver.FindElements(By.LinkText(cidade)).Count > 0; 

                    if (cidadeOK)
                    {
                        IWebElement linkCidade = driver.FindElement(By.LinkText(cidade));
                        linkCidade.Click();
                        RecuperarDadosAsync(driver);
                        driver.Navigate().Back();
                    }
                }
            }

        }

        private static async void RecuperarDadosAsync(IWebDriver driver)
        {
            IWebElement tabelaDados = driver.FindElement(By.XPath("//span[@class='texto02']//following::table[1]/tbody/following::table[3]"));

            var linhasDados = tabelaDados.FindElements(By.XPath("tbody/tr"));

            foreach (var dado in linhasDados)
            {
                string dadoLinha = dado.Text.Trim().Replace(":","|");

                using (StreamWriter file = new StreamWriter("D:\\lixo\\lixao.txt", append: true))
                {
                    await file.WriteLineAsync(dadoLinha);
                }

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
