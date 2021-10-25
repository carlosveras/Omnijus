using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace BaixarDejt
{
    public class ExecutarTeste12
    {
        /// <summary>
        /// Para pegar novo lay-out do TJRJ-Proprio
        /// </summary>
        public static void Testar12()
        {
            Process proc = Process.GetCurrentProcess();
            int procWindows = proc.Id;

            #region TJR-Proprio
            IWebDriver driverFf = new FirefoxDriver();
            driverFf.Url = "https://www3.tjrj.jus.br/segweb/faces/login.jsp?indGet=true&SIGLASISTEMA=PORTALSERVICOS";

            string login = "41391654803";
            string pwd = "omnijus";
            string folder = "";
            string nomeArquivo = "";

            Thread.Sleep(5000);

            driverFf.Manage().Window.Maximize();
            driverFf.FindElement(By.Id("txtLogin")).SendKeys(login);
            driverFf.FindElement(By.Id("txtSenha")).SendKeys(pwd);

            Thread.Sleep(5000);
            driverFf.FindElement(By.Id("btnEnviar")).Click();

            Thread.Sleep(5000);

            IWebDriver janelaNova = TrocarJanela(driverFf);

            var comboTipoUsuario = janelaNova.FindElement(By.XPath("//.[@class='autocomplete-serventia focus ng-untouched ng-pristine ng-valid']"));
            comboTipoUsuario.Click();
            System.Threading.Thread.Sleep(2000);

            //clica na selecao aberta do advogado
            janelaNova.FindElement(By.XPath("//span[@class='color-def']")).Click();

            comboTipoUsuario.SendKeys(Keys.Enter);
            System.Threading.Thread.Sleep(2000);


            janelaNova.FindElement(By.XPath("//.[contains(text(),'Entrar')]")).Click();



            driverFf.FindElement(By.Id("txtSenha")).SendKeys(pwd);


            driverFf.SwitchTo().Frame(2);

            IWebElement imagemCaptcha = driverFf.FindElement(By.Id("rc-imageselect"));
            bool imageOk = true;

            do
            {
                imagemCaptcha = driverFf.FindElement(By.Id("rc-imageselect"));
                Point location = imagemCaptcha.Location;

                var x = 767;
                var y = 190;
                var w = 400;
                var h = 582;

                string pathNomeImagem = @"D:\lixo\" + "lixao" + procWindows + ".jpg";
                folder = @"D:\lixo\";
                nomeArquivo = "lixao" + procWindows + ".jpg";

                ITakesScreenshot screenShot = driverFf as ITakesScreenshot;

                SalvarImagem(screenShot, imagemCaptcha, y, x, w, h, pathNomeImagem);

                string envioCaptcha = Enviar2CaptchaOld(pathNomeImagem);
                string retornoCaptcha = AguardarRetornoCaptcha(envioCaptcha);

                if (retornoCaptcha.StartsWith("OK|"))
                {
                    bool sucesso = ClickImagens(retornoCaptcha, driverFf, imagemCaptcha);
                    if (sucesso)
                    {
                        driverFf.FindElement(By.XPath("//.[@class='primary-controls']/child::div[2]")).Click();
                        Thread.Sleep(2000);
                    }
                }

                try
                {
                    IWebElement textoProcesso = driverFf.FindElement(By.Id("//*[@id='j_id142_header']"));
                    if (textoProcesso != null)
                        imageOk = false;
                }
                catch (Exception)
                {
                    imageOk = true;
                }

                DeletarArquivo(folder, nomeArquivo);

            } while (imageOk);

            #endregion

            #region TesteTrataCoordenadasFuncionando-OK
            //string coordenadas = "OK|coordinates:x=90,y=408;x=323,y=437;x=341,y=291";
            //string trataCoordenadas = coordenadas.Remove(0, 15);
            //string[] coordenadasAclicar = trataCoordenadas.Split(';');

            //foreach (var item in coordenadasAclicar)
            //{
            //    string[] posicoes = item.Split(',');

            //    string x = posicoes[0].ToString().Remove(0,2);
            //    string y = posicoes[1].ToString().Remove(0,2);

            //}
            #endregion

        }


        private static string AguardarRetornoCaptcha(string envioCaptcha)
        {
            string retornoCaptcha = "";

            try
            {
                for (int i = 0; i <= 50; i++)
                {
                    retornoCaptcha = Retornar2Captcha(envioCaptcha.Substring(3, envioCaptcha.Length - 3));
                    if (retornoCaptcha.StartsWith("OK|"))
                        break;

                    if (retornoCaptcha.StartsWith("ERROR_CAPTCHA_UNSOLVABLE"))
                        break;

                    System.Threading.Thread.Sleep(5000);
                }

            }
            catch (Exception ex) { }

            return retornoCaptcha;
        }

        private static string Retornar2Captcha(string envioCaptcha)
        {
            string retorno = "";
            try
            {
                var parametroKey = "e51159450fab3dbef0d2ec4f8eac5256";
                var parametroURL2Captcha = "http://2captcha.com/res.php";

                System.Net.WebClient oWeb = new System.Net.WebClient();
                NameValueCollection parameters = new NameValueCollection();
                parameters.Add("action", "get");
                parameters.Add("key", parametroKey);
                parameters.Add("id", envioCaptcha);
                parameters.Add("coordinatescaptcha", "1");
                oWeb.QueryString = parameters;
                retorno = oWeb.DownloadString(parametroURL2Captcha).Replace(" ", "");
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            Console.WriteLine(retorno);
            return retorno;

        }

        private static bool SalvarImagem(ITakesScreenshot screenShot, IWebElement imagemCaptcha, int y, int x, int w, int h, string pathNomeImagem)
        {
            bool retorno = false;

            try
            {
                Point point = imagemCaptcha.Location;
                point.Y += y;
                point.X += x;


                Rectangle dimensaoCaptcha = new Rectangle(point, new Size(w, h));
                System.Drawing.Bitmap bmpTela = new Bitmap(new MemoryStream(screenShot.GetScreenshot().AsByteArray));

                Bitmap bmpCaptcha = new Bitmap(dimensaoCaptcha.Width, dimensaoCaptcha.Height);
                Graphics graphic = Graphics.FromImage(bmpCaptcha);
                graphic.DrawImage(bmpTela, 0, 0, dimensaoCaptcha, GraphicsUnit.Pixel);

                bmpCaptcha.Save(@pathNomeImagem, ImageFormat.Jpeg);

                retorno = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retorno;
        }

        private static bool SalvarScreen(string pathNomeImagemSs, IWebDriver driverFf)
        {
            bool retorno = false;

            try
            {
                ((ITakesScreenshot)driverFf).GetScreenshot().SaveAsFile(pathNomeImagemSs, ScreenshotImageFormat.Jpeg);

                retorno = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return retorno;
        }

        private static string Enviar2CaptchaOld(string pathNomeImagem)
        {
            string retorno = "Não Processado";

            try
            {
                var parametroKey = "e51159450fab3dbef0d2ec4f8eac5256";
                var parametroURL2Captcha = "http://2captcha.com/in.php";

                System.Net.WebClient oWeb = new System.Net.WebClient();
                NameValueCollection parameters = new NameValueCollection();

                parameters.Add("key", parametroKey);
                parameters.Add("method", "post");
                parameters.Add("coordinatescaptcha", "1");


                oWeb.QueryString = parameters;
                var responseBytes = oWeb.UploadFile(parametroURL2Captcha, @pathNomeImagem);
                retorno = Encoding.ASCII.GetString(responseBytes);
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }

            return retorno;
        }

        private static bool ClickImagens(string retornoCaptcha, IWebDriver driverFf, IWebElement imagemCaptcha)
        {
            bool resolvido = false;

            try
            {
                string coordenadas = retornoCaptcha;
                string trataCoordenadas = coordenadas.Remove(0, 15);
                string[] clicarEm = trataCoordenadas.Split(';');

                int x = 0;
                int y = 0;

                foreach (var clique in clicarEm)
                {

                    string[] posicoes = clique.Split(',');

                    x = Convert.ToInt16(posicoes[0].ToString().Remove(0, 2));
                    y = Convert.ToInt16(posicoes[1].ToString().Remove(0, 2));

                    //Actions action = new Actions(driverFf);
                    //action.MoveToElement(driverFf.FindElement(By.Id(("rc-imageselect"))), imagemCaptcha.Location.X, imagemCaptcha.Location.Y).Perform();
                    //action.MoveByOffset(x, y).Click().Build().Perform();

                    Actions action = new Actions(driverFf);
                    //action.MoveByOffset(x, y);
                    action.MoveToElement(imagemCaptcha, x, y).Perform();
                    action.Click();
                    action.Perform();

                    Thread.Sleep(2000);
                    Console.WriteLine("clicou em  X..: " + x + "  e Y..:  " + y);
                }

                //-> clicar aqui para continuar ---> //.[@class='primary-controls']/child::div[2]
                resolvido = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao clicar no Captcha :" + ex.Message);
            }

            return resolvido;
        }

        private static bool DeletarArquivo(string folder, string nomeArquivo)
        {
            bool retorno = false;

            try
            {
                string[] arquivos = Directory.GetFiles(folder, nomeArquivo);

                foreach (string fileName in arquivos)
                    System.IO.File.Delete(@fileName);

                retorno = true;

            }
            catch (Exception ex) { }

            return retorno;
        }


         private static IWebDriver TrocarJanela(IWebDriver driver)
        {
            string inicialTitulo = "Portal de Serviços";
            int timerSleep = 5000;
            IWebDriver novaJanela = null;

            try
            {
                System.Threading.Thread.Sleep(timerSleep);

                foreach (var handle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(handle);
                    if (driver.Title.StartsWith(inicialTitulo))
                        novaJanela = driver;
                }
            }
            catch (Exception)
            { }

            return novaJanela;
        }




    }
}









