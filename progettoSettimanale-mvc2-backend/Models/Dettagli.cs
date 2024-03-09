using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace progettoSettimanale_mvc2_backend.Models
{
    public class Dettagli
    {
        public int IdDettagli { get; set; }
        public bool MezzaPensione { get; set; }
        public bool PensioneCompleta { get; set; }
        public bool PrimaColazione { get; set; }
        public int IdPrenotazione { get; set; }
        public Dettagli() { }
        public Dettagli(bool mezzaPensione, bool pensioneCompleta, bool primaColazione, int idPrenotazione)
        {

            MezzaPensione = mezzaPensione;
            PensioneCompleta = pensioneCompleta;
            PrimaColazione = primaColazione;
            IdPrenotazione = idPrenotazione;
        }
    }
}