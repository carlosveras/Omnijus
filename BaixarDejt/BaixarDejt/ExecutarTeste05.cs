using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaixarDejt
{
    public class ExecutarTeste05
    {


        public static String[] qPersonagem = new String[2];
        public static String[] qMovimento = new String[40];

        public static void Testar05()
        {
            //string caminhoCorreto = string.Empty;
            //string caminho = @"C:\Pastas de Trabalho\Projetos\Processos\Processamento\782BCBED96BD\3448\102266";

            //int aPartir = caminho.LastIndexOf("\\");

            //if (aPartir > 0)
            //    caminhoCorreto = caminho.Substring(0, aPartir);

            //Console.WriteLine("caminho correto ---> " + caminhoCorreto);
            //Console.ReadKey();

            //pegaParcial(); 

            string lixo = "Tipo do Movimento: Conclusão ao Juiz";
            int position = lixo.IndexOf(":");
            String substring = lixo.Substring(0, position + 1);

            montaMovimentos();
            //montarAudiencia();

        }

        private static void montarAudiencia()
        {
           
            String analisar = string.Empty;

            #region arraylist
            List<string> listVal = new List<string>()
            {"Próxima Audiência",
             "11/11/2021",
             "Hora da Audiência",
             "12:10",
             "Tipo da audiencia",
             "Conciliação"};
            #endregion

            var data = listVal.ElementAt(1);
            data += " " + listVal.ElementAt(3);
            var descricao = listVal.ElementAt(5);
        }

        private static void montaMovimentos()
        {
            #region mstring
            qMovimento[1] = "Movimentação";
            qMovimento[2] = "Tipo do Movimento: Juntada - Petição";
            qMovimento[3] = "Data da juntada:";
            qMovimento[4] = "17/09/2021";
            qMovimento[5] = "Descrição da Juntada:";
            qMovimento[6] = "Documento eletrônico juntado de forma automática.";
            qMovimento[7] = "Tipo do Movimento: Recebimento";
            qMovimento[8] = "Data de Recebimento:";
            qMovimento[9] = "16/09/2021";
            qMovimento[10] = "Descrição";
            qMovimento[11] = "Verifica-se pelo sistema informatizado do TJ/RJ a existência de petição pendente de juntada. Assim, JUNTE-SE aos autos. Após, voltem conclusos com brevidade.";
            qMovimento[12] = "Ato Assinado";
            qMovimento[13] = "Visualizar Ato Assinado Digitalmente";
            qMovimento[14] = "Tipo do Movimento: Despacho - Proferido despacho de mero expediente";
            qMovimento[15] = "Data Despacho:";
            qMovimento[16] = "15/09/2021";
            qMovimento[17] = "Tipo do Movimento: Conclusão ao Juiz";
            qMovimento[18] = "Data da conclusão:";
            qMovimento[19] = "15/09/2021";
            qMovimento[20] = "Juiz:";
            qMovimento[21] = "FERNANDO LUIS GONCALVES DE MORAES";
            qMovimento[22] = "Tipo do Movimento: Ato Ordinatório Praticado";
            qMovimento[23] = "Data:";
            qMovimento[24] = "15/09/2021";
            qMovimento[25] = "Descrição:";
            qMovimento[26] = "CERTIDÃO DE AUTUAÇÃO Certifico e dou fé que o presente feito foi devidamente registrado sob o n.º de ordem epigrafado, sendo certo que suas peças encontram-se digitalizadas, haja vista sua distribuição como processo eletrônico. Eu, Mario Luis V. Cristino, Técnico Judiciário, mat. 01/1761 o autuei e o subscrevo. CERTIDÃO DE RECOLHIMENTO DE CUSTAS Certifico, quanto ao recolhimento de custas: ( ) Que consta à fl. ( ) pedido de Gratuidade de Justiça, bem como apresenta documentos relativos aos rendimentos à fl.(s)_____ e extratos de IRPF à fl.(s)______. ( ) Que trata-se de Carta Precatória com notícia de Gratuidade de Justiça à fl.(s) ( ). ( ) Que A parte autora é isenta de custas, por se tratar de ação proposta pelo MP (art. 18, IV da Lei 3350/99). ( ) A parte autora é isenta de custas, por se tratar de ente público ou autarquia (artigo 17, IX da Lei 3350/99). Entretanto, para que haja a isenção de taxa judiciária, a parte autora (União, Estado, DF e o Município) deverá comprovar a existência de igual isenção, na forma prevista no parágrafo único do artigo 115 do Decreto Lei 05/75. ( X ) DISTRIBUIÇÃO - A peça inicial está dirigida ao Juizado Especial Cível";
            qMovimento[27] = "Tipo do Movimento: Distribuição Sorteio";
            qMovimento[28] = "Data da Distribuição:";
            qMovimento[29] = "14/09/2021";
            qMovimento[30] = "Serventia:";
            qMovimento[31] = "Cartório da 3ª Vara Cível - 3ª Vara Cível";
            qMovimento[32] = "1";
            qMovimento[33] = "10";
            qMovimento[34] = "Os autos de processos findos terão como destinação final a guarda permanente ou a eliminação, depois de cumpridos os respectivos prazos de guarda definidos na Tabela de Temporalidade de Documentos do PJERJ.";
            #endregion

            #region arraylist
            List<string> listVal = new List<string>(){
                "Tipo do Movimento: Digitação de Documentos",
                "Data da digitação:",
                "15/10/2021",
                "Tipo do Movimento: Ato Ordinatório Praticado",
                "Data:",
                "15/10/2021",
                "Descrição:",
                "Em cumprimento à determinação de fls. 54 e 69, certifico que deixo de citar o Banco Itaú, uma vez que já citado eletronicamente às fls. 55/56. Passo o feito à citação postal do segundo réu: WAGNER BARROS MALAQUIAS",
                "Tipo do Movimento: Envio de Documento Eletrônico",
                "Data da remessa:",
                "07/10/2021",
                "Tipo do Movimento: Recebimento",
                "Data de Recebimento:",
                "06/10/2021",
                "Descrição",
                "Cumpra-se o despacho de fl. 54.",
                "Ato Assinado",
                "Visualizar Ato Assinado Digitalmente",
                "Tipo do Movimento: Despacho - Proferido despacho de mero expediente",
                "Data Despacho:",
                "04/10/2021",
                "Tipo do Movimento: Conclusão ao Juiz",
                "Data da conclusão:",
                "04/10/2021",
                "Juiz:",
                "GABRIEL ALMEIDA MATOS DE CARVALHO",
                "Tipo do Movimento: Juntada - Petição",
                "Data da juntada:",
                "04/10/2021",
                "Tipo do Movimento: Envio de Documento Eletrônico",
                "Data da remessa:",
                "01/10/2021",
                "Tipo do Movimento: Recebimento",
                "Data de Recebimento:",
                "29/09/2021",
                "Descrição",
                "Recebo os embargos de declaração de fls. 58/60, já que tempestivos. No mérito, deixo de acolhê-los, por não estarem configuradas na decisão de fl. 54, as hipóteses descritas no art. 1.022 do CPC. Cumpre destacar que ...",
                "Ver Íntegra Do(a) Decisão",
                "Ato Assinado",
                "Visualizar Ato Assinado Digitalmente",
                "Tipo do Movimento: Decisão - Não Concedida a Antecipação de tutela",
                "Data Decisão:",
                "29/09/2021",
                "Tipo do Movimento: Conclusão ao Juiz",
                "Data da conclusão:",
                "29/09/2021",
                "Juiz:",
                "GABRIEL ALMEIDA MATOS DE CARVALHO",
                "Tipo do Movimento: Juntada - Petição",
                "Data da juntada:",
                "29/09/2021",
                "Tipo do Movimento: Envio de Documento Eletrônico",
                "Data da remessa:",
                "27/09/2021",
                "Tipo do Movimento: Recebimento",
                "Data de Recebimento:",
                "24/09/2021",
                "Descrição",
                "Custas devidamente recolhidas. 1. Relego a apreciação do pedido de tutela de urgência para momento posterior ao exercício do contraditório, tendo em vista que não há qualquer risco de perecimento do direito invocado d...",
                "Ver Íntegra Do(a) Despacho",
                "Ato Assinado",
                "Visualizar Ato Assinado Digitalmente",
                "Tipo do Movimento: Despacho - Proferido despacho de mero expediente",
                "Data Despacho:",
                "23/09/2021",
                "Tipo do Movimento: Conclusão ao Juiz",
                "Data da conclusão:",
                "22/09/2021",
                "Juiz:",
                "GABRIEL ALMEIDA MATOS DE CARVALHO",
                "Tipo do Movimento: Juntada - Extrato da GRERJ",
                "Data da juntada:",
                "22/09/2021",
                "Tipo do Movimento: Juntada - Petição",
                "Data da juntada:",
                "21/09/2021",
                "Descrição da Juntada:",
                "Documento eletrônico juntado de forma automática.",
                "Tipo do Movimento: Envio de Documento Eletrônico",
                "Data da remessa:",
                "20/09/2021",
                "Tipo do Movimento: Ato Ordinatório Praticado",
                "Data:",
                "20/09/2021",
                "Descrição:",
                "Ao autor para que complemente as custas iniciais: Atos dos Escrivães - 1102-3 - R$ 407,47 (*) CAARJ - 2001-6 - R$ 40,74 Distribuidor (registro/baixa) - 2102-2 - R$ 1,04 20% (FETJ) - 6246-0088009-4 - R$ 0,20 2%(DISTRIB)L6370/12 - 2701-1 - R$ 0,02 FUNPERJ - 6898-0000208-9 - R$ 20,42 FUNDPERJ - 6898-0000215-1 - R$ 20,42 Taxa Judiciária - 2101-4 - R$ 170,20 (**) Diversos - 2212-9 - R$ 21,12 (***) (*) Duas naturezas jurídicas diversas (obrigacional e indenizatória + 1 litisconsórcio excedente) (**) 10% honorários + 1 taxa mínima pelo pedido Obrigacional. (***) Citação eletrônica do 1º réu.",
                "Tipo do Movimento: Juntada - Extrato da GRERJ",
                "Data da juntada:",
                "20/09/2021",
                "Tipo do Movimento: Alteração de Classe Processual",
                "Data do movimento:",
                "20/09/2021",
                "Tipo do Movimento: Distribuição Sorteio",
                "Data da Distribuição:",
                "17/09/2021",
                "Serventia:",
                "Cartório da 4ª Vara Cível - 4ª Vara Cível",
                "1",
                "500",
                "Os autos de processos findos terão como destinação final a guarda permanente ou a eliminação, depois de cumpridos os respectivos prazos de guarda definidos na Tabela de Temporalidade de Documentos do PJERJ."
            };

            #endregion

            listVal.Remove("Ato Assinado");
            listVal.Remove("Visualizar Ato Assinado Digitalmente");
            listVal.Remove("1");
            listVal.Remove("500");
            listVal.Remove("10");

            int sequencia = 0;
            int posicao = 0;
            String analisar = string.Empty;

            foreach (var item in listVal)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    string conteudo = item;
                    posicao = conteudo.IndexOf(":");
                    analisar = conteudo.Substring(0, posicao + 1);

                    if (analisar == "Tipo do Movimento:")
                    {
                        int indiceAPegar = 0;
                        sequencia++;

                        indiceAPegar = listVal.IndexOf(item) + 2;

                        var data = listVal.ElementAt(indiceAPegar);
                        var descricao = listVal.ElementAt(indiceAPegar + 2);

                        //posicao = descricao.IndexOf(":");
                        //analisar = descricao.Substring(0, posicao + 1);

                        //if (descricao.Contains("Tipo do Movimento:") || descricao.Contains("Data da conclusão:") ||
                        //    descricao.Contains("Aguardando Publicação:") || descricao.Contains("Data da Distribuição:") ||
                        //    descricao.Contains("Data da juntada:") || descricao.Contains("Data Decisão:") || descricao.Contains("Data da remessa:"))
                        if (descricao.Contains("Tipo do Movimento:") || descricao.StartsWith("Data ") || descricao.StartsWith("Data:"))
                        {
                            descricao = listVal.ElementAt(indiceAPegar - 2).Replace("Tipo do Movimento:", "").TrimStart();
                        }

                        Console.WriteLine("Data .....: " + data);
                        Console.WriteLine("Descricao : " + descricao);

                        Console.WriteLine();
                        Console.WriteLine();

                    }
                }
            }

            Console.ReadKey();

        }

        private static void recuperaDados(List<string> listVal, int v)
        {
            int indiceAPegar = v + 2;

            var data = listVal.ElementAt(indiceAPegar);
            var descricao = listVal.ElementAt(indiceAPegar + 2);

            if (descricao.Contains("Tipo do Movimento:") ||
                descricao.Contains("Data da conclusão:") ||
                descricao.Contains("Aguardando Publicação:") ||
                descricao.Contains("Data da publicação:") ||
                descricao.Contains("Data da Distribuição:") ||
                descricao.Contains("Data da juntada:"))
            {
                descricao = "";
            }

            Console.WriteLine("valor pego...: " + data);
            Console.WriteLine("valor pego...: " + descricao);
            Console.WriteLine();


            // Console.ReadKey();
        }

        private static void pegaParcial()
        {
            //string nomeCompleto = "RJ060094 - DEWETT CATRAMBY FILHO";
            string oabCorreto = string.Empty;
            string nomeCorreto = string.Empty;
            string[] dadosAdv;
            //string a = 
            //string b = 

            qPersonagem[0] = "RJ060094 - DEWETT CATRAMBY FILHO";
            qPersonagem[1] = "SP103137 - ANTONIO CARLOS FARDIN ";

            foreach (var persUnico in qPersonagem)
            {
                dadosAdv = persUnico.Split('-');
                Console.WriteLine("  oab " + dadosAdv[0].ToString());
                Console.WriteLine("   nome " + dadosAdv[1].ToString());

            }





            //string[] dadosAdv = nomeCompleto.Split('-');

            //int aPartir = nomeCompleto.LastIndexOf("-");

            //if (aPartir > 0)
            //    oabCorreto = nomeCompleto.Substring(0, aPartir);

            ////dadosAdv


            //Console.WriteLine("  nome " + dadosAdv[0]);
            //Console.WriteLine("  oab " + dadosAdv[1]);
            Console.ReadKey();
        }

    }
}