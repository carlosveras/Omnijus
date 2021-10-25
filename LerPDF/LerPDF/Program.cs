using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LerPDF
{
    class Program
    {

        private static DiarioOficial diarioOficial;
        private static List<string> processos = new List<string>();

        static void Main(string[] args)
        {
            DateTime criadoEm = DateTime.Now;
            DateTime inicioLeitura = DateTime.Now;
            DateTime fimLeitura = DateTime.Now;
            DateTime horaInicio = DateTime.Now;

            string tribunal = "";
            string numeroProcesso = "";
            string numeroDiario = "";
            string dataDisponibilizacao = "";
            string nomeArquivo = "Diario_3142__14_1_2021.pdf";

            int contador = 0;

            //ConverterParaTexto();

            try
            {


                using (PdfReader pdfLido = new PdfReader("d:\\lixo\\D_3151__27_1_2021.pdf"))
                {
                    processos = new List<string>();

                    for (int page = 1; page <= pdfLido.NumberOfPages; page++)
                    {
                        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
                        string currentText = PdfTextExtractor.GetTextFromPage(pdfLido, page, strategy).Replace("\n", "#");

                        var linhas = currentText.Split('#');

                        if (page == 1)
                        {
                            //Console.WriteLine(linhas[1]);  //Nome do Diario
                            //Console.WriteLine(linhas[5]);  //Edição
                            //Console.WriteLine(linhas[6]);  //Data
                            //Console.WriteLine(DateTime.Now); //InicioLeitura

                            tribunal = linhas[1]; //.Replace("Caderno Judiciário do", "").Trim().ToString();
                            numeroDiario = linhas[5].Replace("Nº", "").Trim().ToString();
                            dataDisponibilizacao = linhas[6].Trim().Replace("Data da disponibilização:", "").Replace(".", "").Replace(",", "").Trim().ToString();
                            //nomeArquivo = diarios[intArray].ToString();

                            DateTime dataTradata = TratarData(dataDisponibilizacao);

                            inicioLeitura = DateTime.Now;
                            fimLeitura = DateTime.Now;

                            Console.WriteLine(tribunal);
                            Console.WriteLine();
                            Console.WriteLine();

                            diarioOficial = new DiarioOficial(criadoEm, numeroDiario, tribunal, dataDisponibilizacao, nomeArquivo, inicioLeitura, fimLeitura, dataTradata);

                            RenomearArquivo(tribunal, nomeArquivo);
                        }

                        foreach (var linha in linhas)
                        {
                            numeroProcesso = "";

                            string texto = linha.Trim().ToUpper();

                            #region novaLogica
                            if (texto.Trim().Contains("PROCESSO"))
                            {
                                numeroProcesso = TratarNumProcesso(texto);

                                if (!string.IsNullOrEmpty(numeroProcesso))
                                    numeroProcesso = AdicionarNaLista(numeroProcesso);

                                if (!string.IsNullOrEmpty(numeroProcesso))
                                {
                                    contador++;
                                    Console.WriteLine(numeroProcesso);

                                    DiarioOficialProcesso diarioOficialProcesso = new DiarioOficialProcesso(diarioOficial, numeroProcesso, criadoEm, 1);
                                    diarioOficial.AdicionarProcesso(diarioOficialProcesso);
                                }
                            }
                            #endregion
                        }
                    }

                }


                fimLeitura = DateTime.Now;
                Console.WriteLine("inicio leitura ..: " + inicioLeitura);
                Console.WriteLine("fim leitura .....: " + fimLeitura);
                Console.WriteLine(contador);


                Console.ReadKey();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private static void RenomearArquivo(string tribunal, string nomeArquivo)
        {
            tribunal = Regex.Replace(tribunal, "[^0-9.+-]", "");

            string inicialNovoNome = "TRT" + tribunal + "_";
            string nomeFinalArquivo = inicialNovoNome + nomeArquivo;
        }

        private static string TratarNumProcesso(string texto)
        {
            texto = texto.Replace(" ", "");

            string numeroProcesso = Regex.Replace(texto, "[^0-9.+-]", "");

            if (!string.IsNullOrEmpty(numeroProcesso))
                numeroProcesso = Regex.Replace(numeroProcesso, @"[^\d]", "");

            if (numeroProcesso.Length == 20)
            {
                numeroProcesso = numeroProcesso.Insert(7, "-").Insert(10, ".")
                                .Insert(15, ".").Insert(17, ".").Insert(20, ".");

                if (!numeroProcesso.Contains(".2021."))
                    numeroProcesso = string.Empty;
            }
            else
                numeroProcesso = string.Empty;

            return numeroProcesso;
        }

        private static DateTime TratarData(string dataDisponibilizacao)
        {
            DateTime dataTradada;
            var cultureInfo = new CultureInfo("pt-BR");

            dataTradada = DateTime.Parse(dataDisponibilizacao, cultureInfo);

            return dataTradada;
        }

        #region ConverterParaTexto
        private static void ConverterParaTexto()
        {
            using (var file = new StreamWriter(@"d:\lixo\Diario.txt"))
            {
                using (PdfReader reader = new PdfReader("d:\\lixo\\DiarioTeste.pdf"))
                {
                    StringBuilder text = new StringBuilder();

                    for (int i = 1; i <= reader.NumberOfPages; i++)
                    {
                        StringBuilder lines = text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                        file.WriteLine(lines);
                    }
                }

                file.Close();
            }

        }
        #endregion

        private static string AdicionarNaLista(string numeroProcesso)
        {
            if (!processos.Contains(numeroProcesso))
                processos.Add(numeroProcesso);
            else
                numeroProcesso = "";

            return numeroProcesso;
        }

    }
}
