using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerPDF
{
    public class DiarioOficialProcesso
    {
        private IEnumerable<DiarioOficialProcesso> result;

        protected DiarioOficialProcesso() { }

        public DiarioOficialProcesso(DiarioOficial diarioOficial, string numero, DateTime criadoEm, int idStatus)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentNullException(nameof(numero));

            DiarioOficial = diarioOficial;
            Numero = numero;
            CriadoEm = criadoEm;
            IdStatus = idStatus;

        }

        public DiarioOficialProcesso(IEnumerable<DiarioOficialProcesso> result)
        {
            this.result = result;
        }

        public virtual DiarioOficial DiarioOficial { get; protected set; }
        public virtual int Id { get; protected set; }
        public virtual int IdDiarioOficial { get; protected set; }
        public virtual DateTime CriadoEm { get; protected set; }
        public virtual string Numero { get; protected set; }
        public virtual int IdStatus { get; protected set; }

    }
}
