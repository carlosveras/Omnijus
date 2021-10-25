using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaixarDejt
{
    public class ExecutarTeste03
    {
        public static void Testar()
        {
            string[] palavra = { "sofá", "crachá", "parabéns", "jacarés", "açaí", "Piauí",  "cipós", "dominó", "baú", "Grajaú", "álbum", "fácil", "réptil", "éden", "ímpar", "vírus", "sótão", "tórax", "túnel", "júri", "facção", "cocô" };


            foreach (var item in palavra)
            
            {
                var corrige = RemoverAcentos(item.ToString());

                Console.WriteLine("palavra corrigida -->" + corrige.ToString());
            }



            Console.ReadKey();

        }

        private static string RemoverAcentos(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }



    }
}
