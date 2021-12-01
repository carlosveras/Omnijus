using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaixarDejt
{
    public class ExecutarTeste14
    {

        public static void Testar14()
        {
            TratarOrgaoJulgador();
        }

        private static void TratarOrgaoJulgador()
        {
            string path = @"C:\Lixo\Todos.txt";
            string pathSaida = @"C:\Lixo\DadosSelecionados.txt";

            int contaFrase = 0;
            int comecoFrase = 0;
            int fraseVara = 0;

            string frase = string.Empty;
            string fraseTratar = string.Empty;
            string fraseParcial = string.Empty;
            string nomeComarca = string.Empty;
            string nomeVara = string.Empty;

            using (StreamReader sr = new StreamReader(path))
            {
                using (var writer = new StreamWriter(pathSaida))
                {
                    while (sr.Peek() >= 0)
                    {
                        frase = sr.ReadLine();
                        fraseTratar = frase.ToUpper().Replace("DE COMARCA DE ", "DA COMARCA DE");

                        if (fraseTratar.Contains("COMARCA DE "))
                        {
                            Console.WriteLine(frase);

                            comecoFrase = fraseTratar.IndexOf("COMARCA DE ");

                            fraseVara = fraseTratar.LastIndexOf("DA COMARCA DE");
                            if (fraseVara == -1)
                                fraseVara = 7;

                            nomeVara = fraseTratar.Substring(0, fraseVara).Trim();

                            fraseParcial = fraseTratar.Substring(comecoFrase);
                            nomeComarca = fraseParcial.Replace("COMARCA DE", "").Trim();

                            //nomeComarca = converterPrimeira(nomeComarca);
                            //nomeVara = converterPrimeira(nomeVara);

                            writer.WriteLine(frase + "|" + nomeComarca + "|" + nomeVara);
                            contaFrase++;
                        }

                        else if (fraseTratar.Contains("VARA") && fraseTratar.Contains(" - ") || fraseTratar.Contains(" – "))
                        {
                            if (fraseTratar.Contains(" – "))
                                fraseVara = fraseTratar.LastIndexOf(" – ") + 1;

                            if (fraseTratar.Contains(" - "))
                                fraseVara = fraseTratar.LastIndexOf(" - ") + 1;

                            nomeVara = fraseTratar.Substring(fraseVara + 2).Trim();

                            fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
                            nomeComarca = fraseParcial;

                            //nomeComarca = converterPrimeira(nomeComarca);
                            //nomeVara = converterPrimeira(nomeVara);

                            writer.WriteLine(frase + "|" + nomeVara + "|" + nomeComarca);
                            contaFrase++;
                        }

                        else if (fraseTratar.Contains("VARA") && fraseTratar.Contains(" DE "))
                        {
                            if (fraseTratar.Contains(" DE "))
                                fraseVara = fraseTratar.LastIndexOf(" DE ") + 2;

                            nomeVara = fraseTratar.Substring(fraseVara + 2).Trim();

                            fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
                            nomeComarca = fraseParcial;

                            //nomeComarca = converterPrimeira(nomeComarca);
                            //nomeVara = converterPrimeira(nomeVara);

                            writer.WriteLine(frase + "|" + nomeVara + "|" + nomeComarca);
                            contaFrase++;
                        }

                        else if (fraseTratar.Contains(" DE "))
                        {
                            if (fraseTratar.Contains(" DE "))
                                fraseVara = fraseTratar.LastIndexOf(" DE ") + 2;

                            nomeVara = fraseTratar.Substring(fraseVara + 2).Trim();

                            fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
                            nomeComarca = fraseParcial;

                            //nomeComarca = converterPrimeira(nomeComarca);
                            //nomeVara = converterPrimeira(nomeVara);

                            writer.WriteLine(frase + "|" + nomeVara + "|" + nomeComarca);
                            contaFrase++;
                        }

                        else if (fraseTratar.Contains(" DO "))
                        {
                            if (fraseTratar.Contains(" DO "))
                                fraseVara = fraseTratar.LastIndexOf(" DO ") + 2;

                            nomeVara = fraseTratar.Substring(fraseVara + 2).Trim();

                            fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
                            nomeComarca = fraseParcial;

                            //nomeComarca = converterPrimeira(nomeComarca);
                            //nomeVara = converterPrimeira(nomeVara);

                            writer.WriteLine(frase + "|" + nomeVara + "|" + nomeComarca);
                            contaFrase++;
                        }

                        else if (fraseTratar.Contains(" - "))
                        {
                            if (fraseTratar.Contains(" - "))
                                fraseVara = fraseTratar.LastIndexOf(" - ") + 1;

                            nomeVara = fraseTratar.Substring(fraseVara + 1).Trim();

                            fraseParcial = fraseTratar.Substring(0, fraseVara - 1).Replace(nomeVara, "");
                            nomeComarca = fraseParcial;

                            //nomeComarca = converterPrimeira(nomeComarca);
                            //nomeVara = converterPrimeira(nomeVara);

                            writer.WriteLine(frase + "|" + nomeComarca + "|" + nomeVara);
                            contaFrase++;
                        }

                        else
                        {
                            writer.WriteLine(fraseTratar + "|" + "NAO TRATADA" + "|" + "NAO TRATADA");
                        }
                    }
                }

                Console.WriteLine("total de frases --> " + contaFrase);
                Console.ReadKey();
            }


        }
    }
}
