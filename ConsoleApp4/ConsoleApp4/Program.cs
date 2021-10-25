using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            // Create a pattern for a word that starts with letter "M"  
            string pattern = @"\bSUL\b.{0,20}\bAMÉRICA\b";
            //string patternB = @"^[\d.-]+$";

            string patternB = @"^[0-9.-]+$";

            // Create a Regex  
            Regex rg = new Regex(pattern);

            // Create a Regex  
            Regex rgB = new Regex(patternB);


            Regex invalidCharsRegex = new Regex(@"\b^\d(\.\d)*$\b");

            #region SulAmerica
            //string authors = "SUL AMÉRICA CIA NACIONAL DE SEGUROS S/A, SUL AMÉRICA COMPANHIA DE SEGUROS SAUDE,SUL AMÉRICA SEGUROS DE PESSOAS E PREVIDÊNCIA S.A., SUL AMÉRICA TESTE, SUL AMERICA, TIM S.A.";

            //MatchCollection matchedAuthors = rg.Matches(authors);

            //for (int count = 0; count < matchedAuthors.Count; count++)
            //    Console.WriteLine(matchedAuthors[count].Value);
            #endregion


            #region ParaNumeros
            string[] numeros = { "  0100026-87.2018.5.01.0077", "0100000-82.2021.5.01.0207xxx",
                                 "0100000-02.2021.5.01.0072", "01000AAA01-57.2021.5.01.0081",
                                 "bgd0100028-89.2021.5.01.0000", "0100003-76.2021.5.01.0000",
                                 "0100003ss95.2021.5.01.0511", "0100006-50.2021.5.01.0511",
                                 "0100005-65.2021.5.01.0511" };


            foreach (string numeroAtual in numeros)
            {
                Match match = rgB.Match(numeroAtual);
                if (match.Success)
                    Console.WriteLine("valeu.....: " + match.Value);
                else
                    Console.WriteLine("nao valeu.: " + numeroAtual);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //MatchCollection matchedNumeros = rg.Matches(numeros.ToString());

            //for (int count = 0; count < matchedNumeros.Count; count++)
            //    Console.WriteLine(matchedNumeros[count].Value);



            #endregion

            Console.ReadKey();


        }
    }
}
