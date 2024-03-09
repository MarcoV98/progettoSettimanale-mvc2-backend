using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace progettoSettimanale_mvc2_backend.Models
{
    public class Servizi
    {
        public int IdServizi { get; set; }
        public bool ColazioneInCamera { get; set; }
        public bool FoodBar { get; set; }
        public bool InternetCamera { get; set; }
        public bool LettoAggiuntivo { get; set; }
        public bool CullaCamera { get; set; }
        public int IdPrenotazione { get; set; }
        public int Quantita { get; set; }
        public int Prezzo { get; set; }
        public Servizi() { }
        public Servizi(bool colazioneInCamera, bool foodBar, bool internetCamera, bool lettoAggiuntivo, bool cullaCamera, int idPrenotazione, int quantita, int prezzo)
        {

            ColazioneInCamera = colazioneInCamera;
            FoodBar = foodBar;
            InternetCamera = internetCamera;
            LettoAggiuntivo = lettoAggiuntivo;
            CullaCamera = cullaCamera;
            IdPrenotazione = idPrenotazione;
            Quantita = quantita;
            Prezzo = prezzo;
        }
    }
}