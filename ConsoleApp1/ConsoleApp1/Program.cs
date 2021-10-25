using System;
using System.IO;
//using BCrypt.Net;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        private const string KEY = "L$E*1iF";

        static void Main(string[] args)
        {
            #region testX
            //Console.WriteLine("Hello World!");

            //string myPassword = "2020";
            //string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
            //string myHash = BCrypt.Net.BCrypt.HashPassword(myPassword, mySalt);
            //bool doesPasswordMatch = BCrypt.Net.BCrypt.Verify(myPassword, myHash);

            //String Senha = BCrypt.Net.BCrypt.HashPassword(myPassword + KEY, BCrypt.Net.BCrypt.GenerateSalt());

            //Console.WriteLine();
            //Console.WriteLine("Password is         : " + myPassword);
            //Console.WriteLine("Encoded Password is : " + myHash);
            //Console.WriteLine();

            //bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(myPassword, myHash);
            //Console.WriteLine("Password : " + myPassword + "   isPasswordMatch    : " + isPasswordMatch);

            //myPassword = "123456789";
            //isPasswordMatch = BCrypt.Net.BCrypt.Verify(myPassword, myHash);
            //Console.WriteLine("Password : " + myPassword + "           isPasswordMatch    : " + isPasswordMatch);
            //Console.ReadKey();

            //string folderAtual = $"c:\\lixo";
            //Directory.SetCurrentDirectory(folderAtual);

            //string folderprofile = $"c:\\lixo\\123";

            //try
            //{
            //    if (Directory.Exists($"{folderprofile}"))
            //        Directory.Delete($"{folderprofile}", true);
            //}
            //catch (Exception ex) 
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //Console.ReadKey();

            /////https://pje.trt1.jus.br/consultaprocessual/detalhe-processo/0100721-12.2020.5.01.0064

            //IWebDriver driverOne = new FirefoxDriver();

            //driverOne.Url = "https://pje.trt1.jus.br/consultaprocessual/detalhe-processo/0100721-12.2020.5.01.0064";
            ////driverOne.Url = "http://globo.com";
            //driverOne.Navigate().GoToUrl("https://pje.trt1.jus.br/consultaprocessual/detalhe-processo/0100721-12.2020.5.01.0064");

            //var objetoAdvogado = driverOne.FindElement(By.XPath("ul[@class='partes-hierarquia']"));

            //var lixo = objetoAdvogado;

            //StringBuilder sbTexto = new StringBuilder();

            //string aQuebrar = " MARIANGELA DERETTI   (738.697.249-00)  - Pessoa Física\r\n\r\n          CLEBERSON JUNCKES   SC033723    \r\n          LOUISE KARINA ZIMATH   SC031990    ";

            //string[] juntando = aQuebrar.Split("\r\n");
            //string nomeEValor = "";
            //string nomeAdvogado = "";
            //string documentoAdvogado = "";
            ////string lastWord = juntando.Split(" ").Last();

            //int contador = 0;

            //foreach (var item in juntando)
            //{
            //    if (contador >= 2)
            //    {
            //        nomeEValor = item.Trim();
            //        int posicaoNomeCorreto = nomeEValor.LastIndexOf(" ");
            //        nomeAdvogado = nomeEValor.Substring(0, posicaoNomeCorreto);
            //        documentoAdvogado = nomeEValor.Substring(nomeEValor.LastIndexOf(" ") + 1);
            //    }

            //    contador++;
            //}


            //terceiro teste
            //string soVara = string.Empty;
            //int tamFrase = 0;
            //int tamFraseSComarca = 0;
            //string nomeVara = string.Empty;
            //string nomeComarca = string.Empty;

            ////Juízo da Vara Única da Comarca de Itapiranga
            ////Juízo da Vara Cível da Comarca de Brusque

            //foreach (var item in frases)
            //{
            //    soVara = item.Replace("Juízo da ", "").Replace("Juízo do ", "").Replace("Juízo", "");


            //    if (soVara.Contains("Cível") || soVara.Contains("Criminal"))
            //    {
            //        tamFrase = soVara.LastIndexOf("Cível") + 5;
            //        if (soVara.Contains("Criminal"))
            //            tamFrase = soVara.LastIndexOf("Criminal") + 8;
            //    }
            //    if (!soVara.Contains("Cível") && !soVara.Contains("Criminal") && soVara.Contains("Vara"))
            //        tamFrase = soVara.LastIndexOf("Vara") + 4;

            //    if (soVara.Contains("Comarca"))
            //        nomeComarca = soVara.Substring(tamFrase).Replace("da Comarca de", "").Trim();
            //    else
            //    {
            //        tamFraseSComarca = soVara.LastIndexOf("Cível") + 8;
            //        if (soVara.Contains("Criminal"))
            //            tamFraseSComarca = soVara.LastIndexOf("Criminal") + 11;

            //        nomeComarca = soVara.Substring(tamFraseSComarca).Trim();
            //    }

            //    nomeVara = soVara.Substring(0, tamFrase).Trim();

            //    Console.WriteLine(item);
            //    Console.WriteLine("vara ----> " + nomeVara);
            //    Console.WriteLine("comarca -> " + nomeComarca);
            //    Console.ReadKey();
            //    Console.WriteLine();
            //}
            //fim terceiro teste

            //quarto teste
            //string numeroProcesso = "5022690-57.2020.8.13.0079";
            //string grupo1 = numeroProcesso.Substring(0, 7);
            //string grupo2 = numeroProcesso.Substring(8, 2);
            //string grupo3 = numeroProcesso.Substring(11, 4);
            //string grupo4 = numeroProcesso.Substring(16, 1);
            //string grupo5 = numeroProcesso.Substring(18, 2);
            //string grupo6 = numeroProcesso.Substring(21, 4);

            //Console.WriteLine("grupo 1 ----> " + grupo1);
            //Console.WriteLine("grupo 2 ----> " + grupo2);
            //Console.WriteLine("grupo 3 ----> " + grupo3);
            //Console.WriteLine("grupo 4 ----> " + grupo4);
            //Console.WriteLine("grupo 5 ----> " + grupo5);
            //Console.WriteLine("grupo 6 ----> " + grupo6);

            //Console.ReadKey();
            //Console.WriteLine();
            #endregion

            #region teste01TratarForumVaraComarcaTodos-NaoAconselhavel
            //string path = @"D:\Projetos\ConsoleApp1\ConsoleApp1\Todos.txt";
            //string pathSaida = @"D:\Lixo\DadosSelecionados.txt";

            //int contaFrase = 0;
            //int comecoFrase = 0;
            //int fraseVara = 0;

            //string frase = string.Empty;
            //string fraseTratar = string.Empty;
            //string fraseParcial = string.Empty;
            //string nomeComarca = string.Empty;
            //string nomeVara = string.Empty;

            //using (StreamReader sr = new StreamReader(path))
            //{
            //    using (var writer = new StreamWriter(pathSaida))
            //    {
            //        while (sr.Peek() >= 0)
            //        {
            //            frase = sr.ReadLine();
            //            fraseTratar = frase.Replace("[Pré-processual]", "").Replace("de Comarca de ", "da Comarca de").ToUpper();

            //            if (fraseTratar.Contains("COMARCA DE "))
            //            {
            //                Console.WriteLine(frase);

            //                comecoFrase = fraseTratar.IndexOf("COMARCA DE ");

            //                fraseVara = fraseTratar.LastIndexOf("DA COMARCA DE");
            //                nomeVara = fraseTratar.Substring(0, fraseVara).Trim();

            //                fraseParcial = fraseTratar.Substring(comecoFrase);
            //                nomeComarca = fraseParcial.Replace("COMARCA DE", "").Trim();

            //                writer.WriteLine(frase + "|" + nomeComarca + "|" + nomeVara);
            //                contaFrase++;
            //            }
            //            else if (!fraseTratar.Contains("COMARCA DE "))
            //            {
            //                fraseVara = 0;

            //                if (fraseTratar.Contains(" DE "))
            //                    fraseVara = fraseTratar.LastIndexOf(" DE ")+2;

            //                if (!fraseTratar.Contains(" DE ") && fraseTratar.Contains(" JD "))
            //                    fraseVara = fraseTratar.LastIndexOf("JD ");

            //                if (!fraseTratar.Contains(" DE ") && !fraseTratar.Contains(" JD "))
            //                    fraseVara = fraseTratar.LastIndexOf(" DO ");

            //                nomeVara = fraseTratar.Substring(fraseVara + 2).Trim();

            //                fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
            //                nomeComarca = fraseParcial;

            //                writer.WriteLine(frase + "|" + nomeVara + "|" + nomeComarca);
            //            }
            //        }
            //    }

            //    Console.WriteLine("total de frases --> " + contaFrase);
            //    Console.ReadKey();
            //}
            #endregion

            #region teste01TratarForumVaraComarcaCeara-ConvertendoTudoParaMaiusculo-FuncionandoEImplantadonaSolucao-tudo-OK
            //string path = @"D:\Projetos\ConsoleApp1\ConsoleApp1\Todos.txt";
            //string pathSaida = @"D:\Lixo\DadosSelecionados.txt";

            //int contaFrase = 0;
            //int comecoFrase = 0;
            //int fraseVara = 0;

            //string frase = string.Empty;
            //string fraseTratar = string.Empty;
            //string fraseParcial = string.Empty;
            //string nomeComarca = string.Empty;
            //string nomeVara = string.Empty;

            //using (StreamReader sr = new StreamReader(path))
            //{
            //    using (var writer = new StreamWriter(pathSaida))
            //    {
            //        while (sr.Peek() >= 0)
            //        {
            //            frase = sr.ReadLine();
            //            fraseTratar = frase.ToUpper().Replace("DE COMARCA DE ", "DA COMARCA DE");

            //            if (fraseTratar.Contains("COMARCA DE "))
            //            {
            //                Console.WriteLine(frase);

            //                comecoFrase = fraseTratar.IndexOf("COMARCA DE ");

            //                fraseVara = fraseTratar.LastIndexOf("DA COMARCA DE");
            //                if (fraseVara == -1)
            //                    fraseVara = 7;

            //                nomeVara = fraseTratar.Substring(0, fraseVara).Trim();

            //                fraseParcial = fraseTratar.Substring(comecoFrase);
            //                nomeComarca = fraseParcial.Replace("COMARCA DE", "").Trim();

            //                //nomeComarca = converterPrimeira(nomeComarca);
            //                //nomeVara = converterPrimeira(nomeVara);

            //                writer.WriteLine(frase + "|" + nomeComarca + "|" + nomeVara);
            //                contaFrase++;
            //            }

            //            else if (fraseTratar.Contains("VARA") && fraseTratar.Contains(" - ") || fraseTratar.Contains(" – "))
            //            {
            //                if (fraseTratar.Contains(" – "))
            //                    fraseVara = fraseTratar.LastIndexOf(" – ") + 1;

            //                if (fraseTratar.Contains(" - "))
            //                    fraseVara = fraseTratar.LastIndexOf(" - ") + 1;

            //                nomeVara = fraseTratar.Substring(fraseVara + 2).Trim();

            //                fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
            //                nomeComarca = fraseParcial;

            //                //nomeComarca = converterPrimeira(nomeComarca);
            //                //nomeVara = converterPrimeira(nomeVara);

            //                writer.WriteLine(frase + "|" + nomeVara + "|" + nomeComarca);
            //                contaFrase++;
            //            }

            //            else if (fraseTratar.Contains("VARA") && fraseTratar.Contains(" DE "))
            //            {
            //                if (fraseTratar.Contains(" DE "))
            //                    fraseVara = fraseTratar.LastIndexOf(" DE ") + 2;

            //                nomeVara = fraseTratar.Substring(fraseVara + 2).Trim();

            //                fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
            //                nomeComarca = fraseParcial;

            //                //nomeComarca = converterPrimeira(nomeComarca);
            //                //nomeVara = converterPrimeira(nomeVara);

            //                writer.WriteLine(frase + "|" + nomeVara + "|" + nomeComarca);
            //                contaFrase++;
            //            }

            //            else if (fraseTratar.Contains(" DE "))
            //            {
            //                if (fraseTratar.Contains(" DE "))
            //                    fraseVara = fraseTratar.LastIndexOf(" DE ") + 2;

            //                nomeVara = fraseTratar.Substring(fraseVara + 2).Trim();

            //                fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
            //                nomeComarca = fraseParcial;

            //                //nomeComarca = converterPrimeira(nomeComarca);
            //                //nomeVara = converterPrimeira(nomeVara);

            //                writer.WriteLine(frase + "|" + nomeVara + "|" + nomeComarca);
            //                contaFrase++;
            //            }

            //            else if (fraseTratar.Contains(" DO "))
            //            {
            //                if (fraseTratar.Contains(" DO "))
            //                    fraseVara = fraseTratar.LastIndexOf(" DO ") + 2;

            //                nomeVara = fraseTratar.Substring(fraseVara + 2).Trim();

            //                fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
            //                nomeComarca = fraseParcial;

            //                //nomeComarca = converterPrimeira(nomeComarca);
            //                //nomeVara = converterPrimeira(nomeVara);

            //                writer.WriteLine(frase + "|" + nomeVara + "|" + nomeComarca);
            //                contaFrase++;
            //            }

            //            else if (fraseTratar.Contains(" - "))
            //            {
            //                if (fraseTratar.Contains(" - "))
            //                    fraseVara = fraseTratar.LastIndexOf(" - ") + 1;

            //                nomeVara = fraseTratar.Substring(fraseVara + 1).Trim();

            //                fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
            //                nomeComarca = fraseParcial;

            //                //nomeComarca = converterPrimeira(nomeComarca);
            //                //nomeVara = converterPrimeira(nomeVara);

            //                writer.WriteLine(frase + "|" + nomeComarca + "|" + nomeVara);
            //                contaFrase++;
            //            }

            //            else
            //            {
            //                writer.WriteLine(fraseTratar + "|" + "NAO TRATADA" + "|" + "NAO TRATADA");
            //            }
            //        }
            //    }

            //    Console.WriteLine("total de frases --> " + contaFrase);
            //    Console.ReadKey();
            //}
            #endregion

            #region TratarAdvogado
            //string frase = "OAB 93219N-PR - RENATA DE OLIVEIRA RIBEIRO";
            //string nome = "";
            //string oab = "";

            //if (frase.IndexOf(" - ") > 0)
            //{
            //    nome = frase.Replace(" - ", "#").Split('#')[1].Trim();
            //}

            //int numero = frase.LastIndexOf(" - ");
            //oab = frase.Substring(0, numero).Replace("OAB", "").Trim();

            //Console.WriteLine(nome + " --- " + oab);
            //Console.ReadKey();
            #endregion

            #region ExcluirPastaSubPastaeArquivosFuncionandoOK
            //string folderOrigem = @"C:\Users\VERAS\AppData\Roaming\Mozilla\Firefox\Profiles\jqs349uk.default-release";
            //string folderDestino = @"D:\Lixo\Mozilla\PlacaDeRede\585";
            //string folderRaiz = @"D:\Lixo\naoexiste";

            ////foreach (string dirPath in Directory.GetDirectories(folderOrigem, "*",
            ////       SearchOption.AllDirectories))
            ////    Directory.CreateDirectory(dirPath.Replace(folderOrigem, folderDestino));

            ////foreach (string newPath in Directory.GetFiles(folderOrigem, "*.*",
            ////       SearchOption.AllDirectories))
            ////    File.Copy(newPath, newPath.Replace(folderOrigem, folderDestino), true);

            //try
            //{
            //    DirectoryInfo directory = new DirectoryInfo(folderRaiz);

            //    if (directory.Exists)
            //    {
            //        foreach (DirectoryInfo dir in directory.GetDirectories())
            //        {
            //            if (dir.Exists)
            //                dir.Delete(true);
            //        }
            //    }

            //    if (directory.Exists)
            //        directory.Delete();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            #endregion

            #region RemoveUltimaOcorrenciaString
            string value = @"D:\Projetos\ReglareSolution\capturadadosprocesso\src\domain\Facade\Services\TecnologiaTjRjService.cs";
            //
            // Find the last occurrence of N.
            int index1 = value.LastIndexOf("\\");
            if (index1 != -1)
            {
                Console.WriteLine(index1);
                Console.WriteLine(value.Substring(index1).Replace("\\",""));
                Console.ReadLine();
            }
            #endregion


        }


        #region ConverterFraseParaMaiusculo-FuncionamentoOK
        /// <summary>
        /// Converter frase com somente primeira letra em Maíusculo
        /// </summary>
        /// <param name="frase"></param>
        /// <returns></returns>
        //static string converterPrimeira(string frase)
        //{
        //    char[] array = frase.ToLower().ToCharArray();
        //    if (array.Length >= 1)
        //    {
        //        if (char.IsLower(array[0]))
        //        {
        //            array[0] = char.ToUpper(array[0]);
        //        }
        //    }

        //    for (int i = 1; i < array.Length; i++)
        //    {
        //        if (array[i - 1] == ' ')
        //        {
        //            if (char.IsLower(array[i]))
        //            {
        //                array[i] = char.ToUpper(array[i]);
        //            }
        //        }
        //    }

        //    return new string(array);
        //}
        #endregion
    }
}
