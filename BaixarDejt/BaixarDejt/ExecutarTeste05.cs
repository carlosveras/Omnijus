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

            //montaMovimentos();
            montarMovimentosNew();

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
            List<string> listVal = new List<string>()
            {"Tipo do Movimento: Juntada - Petição",
            "Data da juntada:",
            "20/09/2021",
            "Descrição da Juntada:",
            "Documento eletrônico juntado de forma automática.",
            "Tipo do Movimento: Digitação de Documentos",
            "Data da digitação:",
            "13/09/2021",
            "Tipo do Movimento: Distribuição Sorteio",
            "Data da Distribuição:",
            "13/09/2021",
            "Serventia:",
            "Cartório do II Juizado Especial Cível - II Juizado Especial Cível",
            "Tipo do Movimento: Envio Automático de Documento Eletrônico",
            "Data do movimento:",
            "15/09/2021",
            "Tipo do Movimento: Distribuição Sorteio",
            "Data da Distribuição:",
            "15/09/2021",
            "Serventia:",
            "Cartório do II Juizado Especial Cível - II Juizado Especial Cível",
            "Tipo do Movimento: Juntada - Petição",
            "Data da juntada:",
            "17/09/2021",
            "Descrição da Juntada:",
            "Documento eletrônico juntado de forma automática.",
            "Tipo do Movimento: Recebimento",
            "Data de Recebimento:",
            "16/09/2021",
            "Descrição",
            "Verifica-se pelo sistema informatizado do TJ/RJ a existência de petição pendente de juntada. Assim, JUNTE-SE aos autos. Após, voltem conclusos com brevidade.",
            "Ato Assinado",
            "Visualizar Ato Assinado Digitalmente",
            "Tipo do Movimento: Despacho - Proferido despacho de mero expediente",
            "Data Despacho:",
            "15/09/2021",
            "Tipo do Movimento: Conclusão ao Juiz",
            "Data da conclusão:",
            "15/09/2021",
            "Juiz:",
            "FERNANDO LUIS GONCALVES DE MORAES",
            "Tipo do Movimento: Ato Ordinatório Praticado",
            "Data:",
            "15/09/2021",
            "Descrição:",
            "CERTIDÃO DE AUTUAÇÃO Certifico e dou fé que o presente feito foi devidamente registrado sob o n.º de ordem epigrafado, sendo certo que suas peças encontram-se digitalizadas, haja vista sua distribuição como processo eletrônico. Eu, Mario Luis V. Cristino, Técnico Judiciário, mat. 01/1761 o autuei e o subscrevo. CERTIDÃO DE RECOLHIMENTO DE CUSTAS Certifico, quanto ao recolhimento de custas: ( ) Que consta à fl. ( ) pedido de Gratuidade de Justiça, bem como apresenta documentos relativos aos rendimentos à fl.(s)_____ e extratos de IRPF à fl.(s)______. ( ) Que trata-se de Carta Precatória com notícia de Gratuidade de Justiça à fl.(s) ( ). ( ) Que A parte autora é isenta de custas, por se tratar de ação proposta pelo MP (art. 18, IV da Lei 3350/99). ( ) A parte autora é isenta de custas, por se tratar de ente público ou autarquia (artigo 17, IX da Lei 3350/99). Entretanto, para que haja a isenção de taxa judiciária, a parte autora (União, Estado, DF e o Município) deverá comprovar a existência de igual isenção, na forma prevista no parágrafo único do artigo 115 do Decreto Lei 05/75. ( X ) DISTRIBUIÇÃO - A peça inicial está dirigida ao Juizado Especial Cível",
            "Tipo do Movimento: Distribuição Sorteio",
            "Data da Distribuição:",
            "14/09/2021",
            "Serventia:",
            "Cartório da 3ª Vara Cível - 3ª Vara Cível",
            "Tipo do Movimento: Juntada - Petição",
            "Data da juntada:",
            "07/10/2021",
            "Descrição da Juntada:",
            "Documento eletrônico juntado de forma automática.",
            "Tipo do Movimento: Juntada - Petição",
            "Data da juntada:",
            "30/09/2021",
            "Descrição da Juntada:",
            "Documento eletrônico juntado de forma automática.",
            "Tipo do Movimento: Envio de Documento Eletrônico",
            "Data da remessa:",
            "29/09/2021",
            "Tipo do Movimento: Publicado Despacho",
            "Data da publicação:",
            "06/10/2021",
            "Folhas do DJERJ.:",
            "380/397",
            "Tipo do Movimento: Enviado para publicação",
            "Data do expediente:",
            "29/09/2021",
            "Aguardando Publicação:",
            "06/10/2021",
            "Tipo do Movimento: Recebimento",
            "Data de Recebimento:",
            "20/09/2021",
            "Descrição",
            "...er elucidado com a respectiva prova, ciente de que o protesto genérico por produção de provas ou a omissão quanto à especificação de provas serão interpretados como anuência ao julgamento antecipado da lide. III) ...",
            "Ato Assinado",
            "Visualizar Ato Assinado Digitalmente",
            "Tipo do Movimento: Despacho - Proferido despacho de mero expediente",
            "Data Despacho:",
            "17/09/2021",
            "Tipo do Movimento: Conclusão ao Juiz",
            "Data da conclusão:",
            "16/09/2021",
            "Juiz:",
            "ALEXANDRE PIMENTEL CRUZ",
            "Tipo do Movimento: Digitação de Documentos",
            "Data da digitação:",
            "16/09/2021",
            "Tipo do Movimento: Distribuição Sorteio",
            "Data da Distribuição:",
            "16/09/2021",
            "Serventia:",
            "Cartório do 11º Juizado Especial Cível - 11º Juizado Especial Cível - Penha",
            "Tipo do Movimento: Distribuição Sorteio",
            "Data da Distribuição:",
            "19/10/2021",
            "Serventia:",
            "Cartório do 2º Juizado Especial Cível - 2º Juizado Especial Cível -",
            "Tipo do Movimento: Declínio de Competência",
            "Data da Decisão:",
            "18/10/2021",
            "Tipo do Movimento: Juntada - Documento",
            "Data da juntada:",
            "18/10/2021",
            "Tipo do Movimento: Juntada - Ciente",
            "Data da juntada:",
            "16/10/2021",
            "Descrição da Juntada:",
            "Documento eletrônico juntado de forma automática.",
            "Tipo do Movimento: Digitação de Documentos",
            "Data da digitação:",
            "14/10/2021",
            "Tipo do Movimento: Envio de Documento Eletrônico",
            "Data da remessa:",
            "14/10/2021",
            "Tipo do Movimento: Recebimento",
            "Data de Recebimento:",
            "14/10/2021",
            "Descrição",
            "Considerando o equívoco na distribuição do feito para este Juízo, uma vez que foi endereçado ao Juizado Especial Cível da Comarca de Niterói, dê-se baixa e encamimhe-se àquele Juizado.",
            "Ato Assinado",
            "Visualizar Ato Assinado Digitalmente",
            "Tipo do Movimento: Decisão - Declarada incompetência",
            "Data Decisão:",
            "13/10/2021",
            "Tipo do Movimento: Conclusão ao Juiz",
            "Data da conclusão:",
            "20/09/2021",
            "Juiz:",
            "GUILHERME RODRIGUES DE ANDRADE",
            "Tipo do Movimento: Ato Ordinatório Praticado",
            "Data:",
            "20/09/2021",
            "Descrição:",
            "Certifico que remeto os autos conclusos considerando que, por erro do fluxo automatizado do JEFAZ, os réus não foram citados e o MP não foi intimado no momento da distribuição. ",
            "Tipo do Movimento: Envio de Documento Eletrônico",
            "Data da remessa:",
            "19/10/2021",
            "Tipo do Movimento: Recebimento",
            "Data de Recebimento:",
            "15/10/2021",
            "Descrição",
            "...e as partes deverão aguardar o acesso do Juiz Leigo por até 20min após o horário designado da audiência; 6) como primeiro ato da audiência, os integrantes deverão exibir documento de identificação pessoal com fot...",
            "Ato Assinado",
            "Visualizar Ato Assinado Digitalmente",
            "Tipo do Movimento: Despacho - Proferido despacho de mero expediente",
            "Data Despacho:",
            "15/10/2021",
            "Tipo do Movimento: Conclusão ao Juiz",
            "Data da conclusão:",
            "15/10/2021",
            "Juiz:",
            "VALMAR GAMA DE AMORIM",
            "Tipo do Movimento: Juntada - Petição",
            "Data da juntada:",
            "21/09/2021",
            "Descrição da Juntada:",
            "Documento eletrônico juntado de forma automática.",
            "Tipo do Movimento: Envio Automático de Documento Eletrônico",
            "Data do movimento:",
            "16/09/2021",
            "Tipo do Movimento: Distribuição Sorteio",
            "Data da Distribuição:",
            "16/09/2021",
            "Serventia:",
            "Cartório do 1º Juizado Especial Cível - 1º Juizado Especial Cível",
            "Tipo do Movimento: Recebimento",
            "Data de Recebimento:",
            "15/10/2021",
            "Descrição",
            "...e as partes deverão aguardar o acesso do Juiz Leigo por até 20min após o horário designado da audiência; 6) como primeiro ato da audiência, os integrantes deverão exibir documento de identificação pessoal com fot...",
            "Ato Assinado",
            "Visualizar Ato Assinado Digitalmente",
            "Tipo do Movimento: Despacho - Proferido despacho de mero expediente",
            "Data Despacho:",
            "15/10/2021",
            "Tipo do Movimento: Conclusão ao Juiz",
            "Data da conclusão:",
            "15/10/2021",
            "Juiz:",
            "VALMAR GAMA DE AMORIM",
            "Tipo do Movimento: Juntada - Petição",
            "Data da juntada:",
            "23/09/2021",
            "Descrição da Juntada:",
            "Documento eletrônico juntado de forma automática.",
            "Tipo do Movimento: Envio Automático de Documento Eletrônico",
            "Data do movimento:",
            "17/09/2021",
            "Tipo do Movimento: Distribuição Sorteio",
            "Data da Distribuição:",
            "17/09/2021",
            "Serventia:",
            "Cartório do 1º Juizado Especial Cível - 1º Juizado Especial Cível",
            "Tipo do Movimento: Envio de Documento Eletrônico",
            "Data da remessa:",
            "28/09/2021",
            "Tipo do Movimento: Recebimento",
            "Data de Recebimento:",
            "27/09/2021",
            "Descrição",
            "Trata-se de processo que deveria ser encaminhado ao Juizado Especial Cível, conforme regularmente indicado no corpo da inicial. Este o sucinto relatório. DECIDO. Com efeito, não há como apenar a autora, que ao tentar...",
            "Ato Assinado",
            "Visualizar Ato Assinado Digitalmente",
            "Tipo do Movimento: Sentença - Extinto o processo por ausência de pressupostos processuais",
            "Data Sentença:",
            "27/09/2021",
            "Tipo do Movimento: Conclusão ao Juiz",
            "Data da conclusão:",
            "27/09/2021",
            "Juiz:",
            "JOSE MAURICIO HELAYEL ISMAEL",
            "Tipo do Movimento: Juntada - Petição",
            "Data da juntada:",
            "24/09/2021",
            "Descrição da Juntada:",
            "Documento eletrônico juntado de forma automática.",
            "Tipo do Movimento: Envio de Documento Eletrônico",
            "Data da remessa:",
            "23/09/2021",
            "Tipo do Movimento: Ato Ordinatório Praticado",
            "Data:",
            "23/09/2021",
            "Descrição:",
            "A petição inicial está endereçada ao Juizado Especial Cível. Esclareça a parte autora.",
            "Tipo do Movimento: Alteração de Classe Processual",
            "Data do movimento:",
            "23/09/2021",
            "Tipo do Movimento: Distribuição Sorteio",
            "Data da Distribuição:",
            "22/09/2021",
            "Serventia:",
            "Cartório da 20ª Vara Cível - 20 Vara Cível",
            "Tipo do Movimento: Envio de Documento Eletrônico",
            "Data da remessa:",
            "15/10/2021",
            "Tipo do Movimento: Envio de Documento Eletrônico",
            "Data da remessa:",
            "08/10/2021",
            "Tipo do Movimento: Publicado Decisão",
            "Data da publicação:",
            "18/10/2021",
            "Folhas do DJERJ.:",
            "1007/1095",
            "Tipo do Movimento: Enviado para publicação",
            "Data do expediente:",
            "13/10/2021",
            "Aguardando Publicação:",
            "18/10/2021",
            "Tipo do Movimento: Recebimento",
            "Data de Recebimento:",
            "08/10/2021",
            "Descrição",
            "...A autora não acostou a íntegra das faturas de julho, agosto e setembro. Ademais, não vislumbro risco de dano irreparável ou de difícil reparação em relação às medidas requeridas. Diante disto, indefiro o pleito ante...",
            "Ato Assinado",
            "Visualizar Ato Assinado Digitalmente",
            "Tipo do Movimento: Decisão - Não Concedida a Antecipação de tutela",
            "Data Decisão:",
            "07/10/2021",
            "Tipo do Movimento: Conclusão ao Juiz",
            "Data da conclusão:",
            "06/10/2021",
            "Juiz:",
            "VELEDA SUZETE SALDANHA CARVALHO",
            "Tipo do Movimento: Juntada - Petição",
            "Data da juntada:",
            "04/10/2021",
            "Descrição da Juntada:",
            "Documento eletrônico juntado de forma automática.",
            "Tipo do Movimento: Envio de Documento Eletrônico",
            "Data da remessa:",
            "01/10/2021",
            "Tipo do Movimento: Publicado Despacho",
            "Data da publicação:",
            "18/10/2021",
            "Folhas do DJERJ.:",
            "1007/1095",
            "Tipo do Movimento: Enviado para publicação",
            "Data do expediente:",
            "04/10/2021",
            "Aguardando Publicação:",
            "18/10/2021",
            "Tipo do Movimento: Recebimento",
            "Data de Recebimento:",
            "01/10/2021",
            "Descrição",
            "A parte autora, em derradeira oportunidade, para que cumpra adequadamente o despacho de fls. 25, juntando cópia da identidade do declarante. razo de 10 (dez) dias, sob pena de extinção.",
            "Ato Assinado",
            "Visualizar Ato Assinado Digitalmente",
            "Tipo do Movimento: Despacho - Proferido despacho de mero expediente",
            "Data Despacho:",
            "01/10/2021",
            "Tipo do Movimento: Conclusão ao Juiz",
            "Data da conclusão:",
            "30/09/2021",
            "Juiz:",
            "VELEDA SUZETE SALDANHA CARVALHO",
            "Tipo do Movimento: Juntada - Petição",
            "Data da juntada:",
            "24/09/2021",
            "Descrição da Juntada:",
            "Documento eletrônico juntado de forma automática.",
            "Tipo do Movimento: Envio de Documento Eletrônico",
            "Data da remessa:",
            "23/09/2021",
            "Tipo do Movimento: Publicado Despacho",
            "Data da publicação:",
            "18/10/2021",
            "Folhas do DJERJ.:",
            "1007/1095",
            "Tipo do Movimento: Enviado para publicação",
            "Data do expediente:",
            "24/09/2021",
            "Aguardando Publicação:",
            "18/10/2021",
            "Tipo do Movimento: Recebimento",
            "Data de Recebimento:",
            "23/09/2021",
            "Descrição",
            "Apresente a parte autora comprovante de residência atual e em seu nome (com data inferior a três meses da data de distribuição), oriundo de concessionária de serviço público (LIGHT, CEG, CEDAE, TELEMAR, TELEFONIAS MÓVEIS...",
            "Ato Assinado",
            "Visualizar Ato Assinado Digitalmente",
            "Tipo do Movimento: Despacho - Proferido despacho de mero expediente",
            "Data Despacho:",
            "23/09/2021",
            "Tipo do Movimento: Conclusão ao Juiz",
            "Data da conclusão:",
            "23/09/2021",
            "Juiz:",
            "VELEDA SUZETE SALDANHA CARVALHO",
            "Tipo do Movimento: Digitação de Documentos",
            "Data da digitação:",
            "22/09/2021",
            "Tipo do Movimento: Distribuição Sorteio",
            "Data da Distribuição:",
            "22/09/2021",
            "Serventia:",
            "Cartório do 25º Juizado Especial Cível - 25º Juizado Especial Cível"};
            #endregion

            listVal.Remove("Ato Assinado");
            listVal.Remove("Visualizar Ato Assinado Digitalmente");

            foreach (var item in listVal)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    if (item != "Ato Assinado" &&
                        item != "Visualizar Ato Assinado Digitalmente" && item != "1"
                        && item != "10" && item != "Movimentação")
                    {

                        if (item.Contains("Tipo do Movimento:"))
                        {
                            recuperaDados(listVal, listVal.IndexOf(item));
                        }

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



        private static void montarMovimentosNew()
        {
            int sequencia = 0;
            int posicao = 0;
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

            foreach (var item in listVal)
            {
                if (!String.IsNullOrEmpty(item))
                {
                    string conteudo = item;
                    //posicao = conteudo.IndexOf(":");
                    //analisar = conteudo.Substring(0, posicao + 1);

                    if (item == "Próxima Audiência")
                    {
                        int indiceAPegar = 0;
                        sequencia++;

                        //indiceAPegar = v + 2

                        var data = listVal.ElementAt(indiceAPegar+1);
                        data += " " + listVal.ElementAt(indiceAPegar + 3);
                        var descricao = listVal.ElementAt(indiceAPegar + 5);

                        //posicao = descricao.IndexOf(":");
                        //analisar = descricao.Substring(0, posicao + 1);

                        //if (descricao.Contains("Tipo do Movimento:") || descricao.Contains("Data da conclusão:") ||
                        //    descricao.Contains("Aguardando Publicação:") || descricao.Contains("Data da Distribuição:") ||
                        //    descricao.Contains("Data da juntada:") || descricao.Contains("Data Decisão:") || descricao.Contains("Data da remessa:"))
                        if (descricao.Contains("Tipo do Movimento:") || descricao.StartsWith("Data "))
                        {
                            descricao = "";
                        }


                    }
                }
            }


        }


    }
}
