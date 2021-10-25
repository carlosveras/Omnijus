using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerPDF
{
    public class DiarioOficial
    {

        protected DiarioOficial() { }

        private IList<DiarioOficialProcesso> _processos;

        public DiarioOficial(DateTime criadoEm, string numeroDiario, string tribunal, string dataDisponibilizacao, string nomeArquivo, DateTime inicioLeitura, DateTime fimLeitura, DateTime dataDisp)
        {

            if (string.IsNullOrWhiteSpace(numeroDiario))
                throw new ArgumentNullException(nameof(numeroDiario));

            if (string.IsNullOrWhiteSpace(dataDisponibilizacao))
                throw new ArgumentNullException(nameof(dataDisponibilizacao));

            if (string.IsNullOrWhiteSpace(nomeArquivo))
                throw new ArgumentNullException(nameof(nomeArquivo));


            CriadoEm = criadoEm;
            NumeroDiario = numeroDiario;
            DataDisponibilizacao = dataDisponibilizacao;
            NomeArquivo = nomeArquivo;
            Tribunal = tribunal;
            InicioLeitura = inicioLeitura;
            FimLeitura = fimLeitura;
            DataDisp = dataDisp;
        }

        public virtual void AlterarDiarioOficial(string numeroDiario, DateTime fimLeitura)
        {
            NumeroDiario = numeroDiario;
            FimLeitura = fimLeitura;
        }

        public virtual void AdicionarProcesso(DiarioOficialProcesso processo)
        {
            if (processo == null)
                throw new ArgumentException(nameof(processo));

            if (_processos == null)
                _processos = new List<DiarioOficialProcesso>();

            _processos.Add(processo);
        }


        public virtual void AdicionarListaProcesso(List<DiarioOficialProcesso> processo)
        {
            if (processo == null)
                throw new ArgumentException(nameof(processo));

            foreach (var item in processo)
            {
                _processos.Add(new DiarioOficialProcesso(item.DiarioOficial, item.Numero, item.CriadoEm, item.IdStatus));
            }
            
        }



        public virtual int Id { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }
        public virtual string Tribunal { get; protected set; }
        public virtual string NumeroDiario { get; protected set; }
        public virtual string DataDisponibilizacao { get; protected set; }
        public virtual string NomeArquivo { get; protected set; }
        public virtual DateTime DataDisp { get; protected set; }
        public virtual DateTime InicioLeitura { get; protected set; }
        public virtual DateTime FimLeitura { get; protected set; }

        public virtual IEnumerable<DiarioOficialProcesso> Processos => _processos;

    }
}

