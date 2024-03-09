using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace progettoSettimanale_mvc2_backend.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CognomeCliente { get; set; }
        public string CittaCliente { get; set; }
        public string ProvinciaCliente { get; set; }
        public string MailCliente { get; set; }

        public Cliente() { }
        public Cliente(string nomeCliente, string cognomeCliente, string cittaCliente, string provinciaCliente, string mailCliente)
        {

            this.NomeCliente = nomeCliente;
            this.CognomeCliente = cognomeCliente;
            this.CittaCliente = cittaCliente;
            this.ProvinciaCliente = provinciaCliente;
            this.MailCliente = mailCliente;

        }
    }
}