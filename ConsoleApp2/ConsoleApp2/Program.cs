using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp2
{
    class Program
    {
        /// <summary>
        /// fazer um programa para pegar os dados deste url : https://www.tjpe.jus.br/poder-judiciario/comarcas-de-pernambuco
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            string Nome = string.Empty;
            string Qualificacao = string.Empty;
            string Documento = string.Empty;
            string Oab = string.Empty;
            string atributoCpf = string.Empty;
            string cpfAdvogado = string.Empty;
            string cpfLimpo = string.Empty;

            #region testeAntigo
            ///System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\\Program Files (x86)\\Google\\Chrome\\Application");
            ///ChromeOptions chromeOptions = new ChromeOptions();
            ///chromeOptions.DebuggerAddress = "localhost:9014";

            ///IWebDriver webDriver = new ChromeDriver(chromeOptions);

            //var divGeral = webDriver.FindElements(By.ClassName("sem-padding"));
            //var divAdvogados = webDriver.FindElements(By.ClassName("partes-representante"));
            //var divCpfAdvogado = webDriver.FindElements(By.ClassName("mr-10"));
            //var divMessage = webDriver.FindElement(By.Id("cdk-describedby-message-container"));

            //foreach (var dadoAdvogado in divAdvogados)
            //{
            //    int posicaoInicial = dadoAdvogado.Text.IndexOf("(");
            //    if (posicaoInicial > 0)
            //    {
            //        atributoCpf = dadoAdvogado.FindElement(By.ClassName("mr-10")).GetAttribute("aria-describedby");
            //        cpfAdvogado = divMessage.FindElement(By.Id(atributoCpf)).GetAttribute("textContent");
            //        cpfLimpo = cpfAdvogado.Replace("CPF:", "").Replace(".", "").Replace("-", "");

            //        Nome = dadoAdvogado.Text.Substring(0, posicaoInicial);
            //        Qualificacao = dadoAdvogado.Text.Substring(posicaoInicial).Replace("(", "").Replace(")", "");
            //        Documento = cpfLimpo;
            //        Oab = null;
            //    }
            //    else
            //    {
            //        Nome = dadoAdvogado.Text;
            //        Qualificacao = "Advogado";
            //    }
            //}
            ///https://pje.trt1.jus.br/consultaprocessual/detalhe-processo/0100691-09.2020.5.01.0021
            #endregion

            //System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"C:\\Program Files\\Mozilla Firefox");

            //FirefoxOptions firefoxOptions = new FirefoxOptions();
            //firefoxOptions.BrowserExecutableLocation = "localhost:9222";
            //IWebDriver driverOne = new FirefoxDriver();

            //driverOne.Url = "https://pje.trt1.jus.br/consultaprocessual/detalhe-processo/0100721-12.2020.5.01.0064";
            //driverOne.Navigate().GoToUrl("https://pje.trt1.jus.br/consultaprocessual/detalhe-processo/0100721-12.2020.5.01.0064");


            //driverOne.Url = "http://globo.com";
            //driverOne.Navigate().GoToUrl("http://globo.com");


            #region testeAntigo01
            //var divGeral = webDriver.FindElements(By.ClassName("sem-padding"));
            //var divAdvogados = webDriver.FindElements(By.ClassName("partes-representante"));
            //var divCpfAdvogados = webDriver.FindElements(By.ClassName("mr-10"));
            //var divMessage = webDriver.FindElement(By.Id("cdk-describedby-message-container"));

            //var divTeste = webDriver.FindElements(By.XPath(".//small[@class='partes-representante']"));

            //foreach (var dadoAdvogado in divTeste) // divAdvogados)
            //{
            //    int posicaoInicial = dadoAdvogado.Text.IndexOf("(");
            //    if (posicaoInicial > 0)
            //    {
            //        //var atributoCpft = dadoAdvogado.FindElement(By.ClassName("fa.fa-user-mr-10")).GetAttribute("aria-describedby");
            //        //var atributoCpfd = dadoAdvogado.FindElement(By.CssSelector("fa.fa-user-mr-10")).GetAttribute("aria-describedby");
            //        //var atributoCpfz = dadoAdvogado.FindElement(By.XPath("[@id='cdk-describedby-message-container']")).GetAttribute("aria-describedby");

            //        atributoCpf = dadoAdvogado.FindElement(By.ClassName("mr-10")).GetAttribute("aria-describedby");
            //        cpfAdvogado = divMessage.FindElement(By.Id(atributoCpf)).GetAttribute("textContent");
            //        cpfLimpo = cpfAdvogado.Replace("CPF:", "").Replace(".", "").Replace("-", "");

            //        Nome = dadoAdvogado.Text.Substring(0, posicaoInicial);
            //        Qualificacao = dadoAdvogado.Text.Substring(posicaoInicial).Replace("(", "").Replace(")", "");
            //        Documento = cpfLimpo;
            //        Oab = null;
            //    }
            //    else
            //    {
            //        Nome = dadoAdvogado.Text;
            //        Qualificacao = "Advogado";
            //    }
            //}

            //        var objetoAdvogado = webDriver.FindElements(By.XPath(".//ul[@class='partes-hierarquia']"));


            //        IWebElement teste =  webDriver.FindElement(By.LinkText(""));


            //        if (objetoAdvogado != null)
            //        {
            //            //var dadosAdvogados = objetoAdvogado.FindElements(By.XPath("li//small[@class='partes-representante']//span")); //original funcionando
            //            //var dadosAdvogados = objetoAdvogado.FindElements(By.XPath("//small[@class='partes-representante']"));

            //            var dadosAdvogados = webDriver.FindElements(By.XPath(".//small[@class='partes-representante']"));

            //            foreach (var dadoAdvogado in dadosAdvogados)
            //            {
            //                //string cpfAdvogado = string.Empty;

            //                var elementoNomeAdv = dadoAdvogado.FindElement(By.XPath("span"));

            //                if (elementoNomeAdv != null)
            //                {
            //                    int posicaoInicial = elementoNomeAdv.Text.IndexOf("(");

            //                    if (posicaoInicial > 0)
            //                    {
            //                        Nome = elementoNomeAdv.Text.Substring(0, posicaoInicial);
            //                        Qualificacao = elementoNomeAdv.Text.Substring(posicaoInicial).Replace("(", "").Replace(")", "");
            //                    }
            //                    else
            //                    {
            //                        Nome = elementoNomeAdv.Text;
            //                        Qualificacao = "Advogado";
            //                    }

            //                    Oab = null;
            //                }

            //                var elementoCpf = dadoAdvogado.FindElement(By.XPath("i[@class='mr-10']"));

            //                if (elementoCpf != null)
            //                {
            //                    atributoCpf = elementoCpf.GetAttribute("aria-describedby");

            //                    if (!string.IsNullOrEmpty(atributoCpf))
            //                    {
            //                        cpfAdvogado = divMessage.FindElement(By.Id(atributoCpf)).GetAttribute("textContent");

            //                        if (cpfAdvogado.Trim().ToUpper().StartsWith("CPF") || cpfAdvogado.Trim().ToUpper().StartsWith("CNPJ") || cpfAdvogado.Trim().ToUpper().StartsWith("CPJ"))
            //                        {
            //                            Documento = cpfAdvogado;
            //                        }
            //                    }
            //                }

            //            }
            //        }
            #endregion

            #region paraInspecionarElementos

            ///comando a executar antes de rodar esta aplicacao
            ///chrome.exe -remote-debugging-port=9014 --user-data-dir="D:\Selenium\Chrome_Test_Profile"
            /// trecho de rotina para executar o teste usando o Chrome
            //System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", @"C:\\Program Files\\Google\\Chrome\\Application");

            //ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.DebuggerAddress = "localhost:9014";

            //IWebDriver webDriver = new ChromeDriver(chromeOptions);

            ///comando a executar antes de rodar esta aplicacao
            ///firefox.exe -start-debugger-server 9222
            /// trecho de rotina para executar o teste usando o Chrome

            //System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", @"C:\\Program Files\\Mozilla Firefox");

            //FirefoxOptions firefoxOptions = new FirefoxOptions();
            //firefoxOptions.BrowserExecutableLocation = "localhost:9222";
            //IWebDriver webDriver = new FirefoxDriver();

            //webDriver.Url = "https://pje.tjmg.jus.br/pje/login.seam";



            //string numeroProcesso = "5013834-66.2020.8.13.0027";

            //var menuPrincipal = webDriver.FindElement(By.LinkText("Abrir menu"));
            //if (menuPrincipal != null)
            //    menuPrincipal.Click();

            //IWebElement menuProcesso = webDriver.FindElement(By.LinkText("Processo"));
            //if (menuProcesso != null)
            //    menuProcesso.Click();

            //IWebElement menuPesquisar = webDriver.FindElement(By.LinkText("Pesquisar"));
            //if (menuPesquisar != null)
            //    menuPesquisar.Click();

            //IWebElement pesquisarProcessoC = webDriver.FindElement(By.XPath("//li[4]/div/ul/li/a"));
            //if (pesquisarProcessoC != null)
            //    pesquisarProcessoC.Click();

            //if (pesquisarProcessoC == null)
            //{
            //    IWebElement pesquisarProcesso = webDriver.FindElement(By.XPath("[@id='menu']/div[2]/ul/li[2]/div/ul/li[4]/div/ul/li/a"));
            //    if (pesquisarProcesso != null)
            //        pesquisarProcesso.Click();
            //}

            //IWebElement botaoPesquisar = webDriver.FindElement(By.Id("fPP:searchProcessos"));

            //IWebElement numeroSequencial = webDriver.FindElement(By.Id("fPP:numeroProcesso:numeroSequencial"));
            //if (numeroSequencial != null)
            //    numeroSequencial.Clear();

            //IWebElement numeroDigitoVerificador = webDriver.FindElement(By.Id("fPP:numeroProcesso:numeroDigitoVerificador"));
            //if (numeroDigitoVerificador != null)
            //    numeroDigitoVerificador.Clear();

            //IWebElement ano = webDriver.FindElement(By.Id("fPP:numeroProcesso:ano"));
            //if (ano != null)
            //    ano.Clear();

            //IWebElement ramoJustica = webDriver.FindElement(By.Id("fPP:numeroProcesso:ramoJustica"));
            //if (ramoJustica != null)
            //    ramoJustica.Clear();

            //IWebElement respectivoTribunal = webDriver.FindElement(By.Id("fPP:numeroProcesso:respectivoTribunal"));
            //if (respectivoTribunal != null)
            //    respectivoTribunal.Clear();

            //IWebElement numeroOrgaoJustica = webDriver.FindElement(By.Id("fPP:numeroProcesso:numeroOrgaoJustica"));
            //if (numeroOrgaoJustica != null)
            //    numeroOrgaoJustica.Clear();

            ////tratar o numero do processo
            //string grupo1 = numeroProcesso.Substring(0, 7);
            //string grupo2 = numeroProcesso.Substring(8, 2);
            //string grupo3 = numeroProcesso.Substring(11, 4);
            //string grupo4 = numeroProcesso.Substring(16, 1);
            //string grupo5 = numeroProcesso.Substring(18, 2);
            //string grupo6 = numeroProcesso.Substring(21, 4);

            //numeroSequencial.SendKeys(grupo1);
            //numeroDigitoVerificador.SendKeys(grupo2);
            //ano.SendKeys(grupo3);
            //ramoJustica.SendKeys(grupo4);
            //respectivoTribunal.SendKeys(grupo5);
            //numeroOrgaoJustica.SendKeys(grupo6);

            //botaoPesquisar.Click();


            //IWebElement linkProcesso = webDriver.FindElement(By.XPath("//tbody[@id='fPP:processosTable:tb']//tr//a"));
            //if (linkProcesso != null)
            //    linkProcesso.Click();

            //IAlert al = webDriver.SwitchTo().Alert();
            //al.Accept();

            //string orgaoJulgador = "";
            //string classeJudicial = "";
            //string assunto = "";
            //string jurisdicao = "";



            //IWebElement objetoDetalhes = webDriver.FindElement(By.XPath("//[@id='maisDetalhes']"));

            //var objClasseJudicial = objetoDetalhes.FindElement(By.XPath("div//dl//dt[.='Classe judicial']//following::dd"));
            //if (objClasseJudicial != null)
            //    classeJudicial = objClasseJudicial.Text;

            //var objAssunto = objetoDetalhes.FindElement(By.XPath("div//dl//dt[.='Assunto']//following::dd"));
            //if (objAssunto != null)
            //    assunto = objAssunto.Text;

            //var objJurisdicao = objetoDetalhes.FindElement(By.XPath("div//dl//dt[.='Jurisdição']//following::dd"));
            //if (objJurisdicao != null)
            //    jurisdicao = objJurisdicao.Text;

            //var objOrgaoJulgador = objetoDetalhes.FindElement(By.XPath("div//dl//dt[.='Órgão Julgador']//following::dd"));
            //if (objOrgaoJulgador != null)
            //    orgaoJulgador = objOrgaoJulgador.Text;

            #endregion

            #region testeWhile
            int tentativas = 10;
            int atual = 1;

            while (atual <= tentativas)
            {
                Console.WriteLine("tentativa atual : " + atual);
                atual  = ContaValores(atual);
                if (atual >= 3)
                    return; 
            }
            #endregion

            Console.WriteLine("saiu do loop com o valor atual : " + atual);
            Console.ReadKey();

        }

        private static int ContaValores(int atual)
        {
            
            atual++;
            
            return atual;
        }
    }
}

