using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace progettoSettimanale_mvc2_backend.Models
{
    public class Prenotazione
    {
        public int IdPrenotazione { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int CaparraConfirmatoria { get; set; }
        public int TariffaApplicata { get; set; }
        public int IdCliente { get; set; }
        public int IdCamera { get; set; }
        public Prenotazione() { }

        public Prenotazione(DateTime dataPrenotazione, DateTime checkIn, DateTime checkOut, int caparraConfirmatoria, int tariffaApplicata, int idCliente, int idCamera)
        {

            DataPrenotazione = dataPrenotazione;
            CheckIn = checkIn;
            CheckOut = checkOut;
            CaparraConfirmatoria = caparraConfirmatoria;
            TariffaApplicata = tariffaApplicata;
            IdCliente = idCliente;
            IdCamera = idCamera;
        }
    }
}