using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opgave_7
{
    internal class Medlem
    {
        public ushort MedlemsNummer { get; set; }
        public String Fornavn { get; set; }
        public String Efternavn { get; set; }
        public String Adresselinie1 { get; set; }
        public String Adresselinie2 { get; set; } = null;
        public String PostNr { get; set; }
        public String ByNavn { get; set; }
        public String MailAdresse { get; set; }
        public bool ErPrivat { get; set; }
        public bool ErAktiv { get; set; }
        public bool HarBetaltKontingent { get; set; }
        public bool ErTilmeldtNyhedsbrev { get; set; } = false;
        public DateTime DatoBrev { get; set; }
    }
}
