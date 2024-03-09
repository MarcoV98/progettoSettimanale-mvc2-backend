using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;

namespace progettoSettimanale_mvc2_backend.Models
{
    public static class DB
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["ConDB"].ConnectionString;
        }

        private static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public static void AddCliente(string nomeCliente, string cognomeCliente, string cittaCliente, string provinciaCliente, string mailCliente)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO clienti (nomeCliente, cognomeCliente, cittaCliente, provinciaCliente, mailCliente) VALUES(@nomeCliente, @cognomeCliente, @cittaCliente, @provinciaCliente, @mailCliente)", conn);
                cmd.Parameters.AddWithValue("nomeCliente", nomeCliente);
                cmd.Parameters.AddWithValue("cognomeCliente", cognomeCliente);
                cmd.Parameters.AddWithValue("cittaCliente", cittaCliente);
                cmd.Parameters.AddWithValue("provinciaCliente", provinciaCliente);
                cmd.Parameters.AddWithValue("mailCliente", mailCliente);
                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }

        public static void AddCamera(int numeroCamera, bool cameraSingola, bool cameraDoppia, string descrizioneCamera, int idCliente)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO camera (numeroCamera, cameraSingola, cameraDoppia, descrizioneCamera, idCliente) VALUES(@numeroCamera, @cameraSingola, @cameraDoppia, @descrizioneCamera, @idCliente)", conn);
                cmd.Parameters.AddWithValue("numeroCamera", numeroCamera);
                cmd.Parameters.AddWithValue("cameraSingola", cameraSingola);
                cmd.Parameters.AddWithValue("cameraDoppia", cameraDoppia);
                cmd.Parameters.AddWithValue("descrizioneCamera", descrizioneCamera);
                cmd.Parameters.AddWithValue("idCliente", idCliente);
                int rowsAffected = cmd.ExecuteNonQuery();
            }
        }

        public static void AddPrenotazione(DateTime dataPrenotazione, DateTime checkIn, DateTime checkOut, int caparraConfirmatoria, int tariffaApplicata, int idCliente, int idCamera)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO prenotazione (dataPrenotazione, checkIn, checkOut, caparraConfirmatoria, tariffaApplicata, idCliente, idCamera) VALUES (@dataPrenotazione, @checkIn, @checkOut, @caparraConfirmatoria, @tariffaApplicata, @idCliente, @idCamera)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("dataPrenotazione", dataPrenotazione);
                    cmd.Parameters.AddWithValue("checkIn", checkIn);
                    cmd.Parameters.AddWithValue("checkOut", checkOut);
                    cmd.Parameters.AddWithValue("caparraConfirmatoria", caparraConfirmatoria);
                    cmd.Parameters.AddWithValue("tariffaApplicata", tariffaApplicata);
                    cmd.Parameters.AddWithValue("idCliente", idCliente);
                    cmd.Parameters.AddWithValue("idCamera", idCamera);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddDettagli(bool mezzaPensione, bool pensioneCompleta, bool primaColazione, int idPrenotazione)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO dettagli (mezzaPensione, pensioneCompleta, primaColazione, idPrenotazione) VALUES (@mezzaPensione, @pensioneCompleta, @primaColazione, @idPrenotazione)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("mezzaPensione", mezzaPensione);
                    cmd.Parameters.AddWithValue("pensioneCompleta", pensioneCompleta);
                    cmd.Parameters.AddWithValue("primaColazione", primaColazione);
                    cmd.Parameters.AddWithValue("idPrenotazione", idPrenotazione);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }

        public static void AddServizi(bool colazioneInCamera, bool foodBar, bool internetCamera, bool lettoAggiuntivo, bool cullaCamera, int idPrenotazione, int quantita, int prezzo)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                string query = "INSERT INTO servizi (colazioneCamera, foodBar, internetCamera, lettoAggiuntivo, cullaCamera, idPrenotazione, quantita, prezzo) VALUES (@colazioneCamera, @foodBar, @internetCamera, @lettoAggiuntivo, @cullaCamera, @idPrenotazione, @quantita, @prezzo)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("colazioneCamera", colazioneInCamera);
                    cmd.Parameters.AddWithValue("foodBar", foodBar);
                    cmd.Parameters.AddWithValue("internetCamera", internetCamera);
                    cmd.Parameters.AddWithValue("lettoAggiuntivo", lettoAggiuntivo);
                    cmd.Parameters.AddWithValue("cullaCamera", cullaCamera);
                    cmd.Parameters.AddWithValue("idPrenotazione", idPrenotazione);
                    cmd.Parameters.AddWithValue("quantita", quantita);
                    cmd.Parameters.AddWithValue("prezzo", prezzo);

                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Cliente> AllClienti()
        {
            List<Cliente> clienti = new List<Cliente>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM clienti", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cliente c = new Cliente
                    {
                        NomeCliente = reader["NomeCliente"].ToString(),
                        CognomeCliente = reader["CognomeCliente"].ToString(),
                        CittaCliente = reader["CittaCliente"].ToString(),
                        ProvinciaCliente = reader["ProvinciaCliente"].ToString(),
                        MailCliente = reader["MailCliente"].ToString()
                    };
                    clienti.Add(c);
                }
            }
            return clienti;
        }

        public static List<Prenotazione> AllPrenotazioni()
        {
            List<Prenotazione> prenotazioni = new List<Prenotazione>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM prenotazione", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Prenotazione p = new Prenotazione
                    {
                        CheckIn = Convert.ToDateTime(reader["checkIn"]),
                        CheckOut = Convert.ToDateTime(reader["checkOut"]),
                        CaparraConfirmatoria = Convert.ToInt32(reader["caparraConfirmatoria"]),
                        TariffaApplicata = Convert.ToInt32(reader["tariffaApplicata"]),
                        IdCliente = Convert.ToInt32(reader["idCliente"]),
                        IdCamera = Convert.ToInt32(reader["idCamera"])
                    };
                    prenotazioni.Add(p);
                }
            }
            return prenotazioni;
        }

        public static List<Servizi> AllServizi(int id)
        {
            List<Servizi> servizi = new List<Servizi>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM servizi WHERE idPrenotazione = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Servizi s = new Servizi
                    {
                        ColazioneInCamera = Convert.ToBoolean(reader["colazioneInCamera"]),
                        FoodBar = Convert.ToBoolean(reader["foodBar"]),
                        InternetCamera = Convert.ToBoolean(reader["internetCamera"]),
                        LettoAggiuntivo = Convert.ToBoolean(reader["lettoAggiuntivo"]),
                        CullaCamera = Convert.ToBoolean(reader["cullaCamera"]),
                        IdPrenotazione = Convert.ToInt32(reader["idPrenotazione"]),
                        Quantita = Convert.ToInt32(reader["quantita"]),
                        Prezzo = Convert.ToInt32(reader["prezzo"])
                    };
                    servizi.Add(s);
                }
            }
            return servizi;
        }

        public static List<Camera> AllCamera()
        {
            List<Camera> camere = new List<Camera>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM camera", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Camera r = new Camera
                    {
                        NumeroCamera = Convert.ToInt32(reader["numeroCamera"]),
                        CameraSingola = Convert.ToBoolean(reader["cameraSingola"]),
                        CameraDoppia = Convert.ToBoolean(reader["cameraDoppia"]),
                        DescrizioneCamera = reader["descrizioneCamera"].ToString(),
                        IdCliente = Convert.ToInt32(reader["idCliente"])
                    };
                    camere.Add(r);
                }
            }
            return camere;
        }

        public static List<Dettagli> AllDettagli()
        {
            List<Dettagli> dettagli = new List<Dettagli>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dettagli", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dettagli d = new Dettagli
                    {
                        MezzaPensione = Convert.ToBoolean(reader["mezzaPensione"]),
                        PensioneCompleta = Convert.ToBoolean(reader["pensioneCompleta"]),
                        PrimaColazione = Convert.ToBoolean(reader["primaColazione"]),
                        IdPrenotazione = Convert.ToInt32(reader["idPrenotazione"])
                    };
                    dettagli.Add(d);
                }
            }
            return dettagli;
        }

        public static Cliente GetClientiById(int id)
        {
            Cliente c = new Cliente();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM clienti WHERE idCliente = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c.IdCliente = Convert.ToInt32(reader["IdCliente"]);
                    c.NomeCliente = reader["NomeCliente"].ToString();
                    c.CognomeCliente = reader["CognomeCliente"].ToString();
                    c.CittaCliente = reader["CittaCliente"].ToString();
                    c.ProvinciaCliente = reader["ProvinciaCliente"].ToString();
                    c.MailCliente = reader["MailCliente"].ToString();
                }
            }
            return c;
        }

        public static Prenotazione GetPrenotazioniById(int id)
        {
            Prenotazione p = new Prenotazione();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM prenotazione WHERE idPrenotazione = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    p.IdPrenotazione = Convert.ToInt32(reader["idPrenotazione"]);
                    p.CheckIn = Convert.ToDateTime(reader["checkIn"]);
                    p.CheckOut = Convert.ToDateTime(reader["checkOut"]);
                    p.CaparraConfirmatoria = Convert.ToInt32(reader["caparraConfirmatoria"]);
                    p.TariffaApplicata = Convert.ToInt32(reader["tariffaApplicata"]);
                    p.IdCliente = Convert.ToInt32(reader["idCliente"]);
                    p.IdCamera = Convert.ToInt32(reader["idCamera"]);
                }
            }
            return p;
        }

        public static Admin GetAdmin(Admin a)
        {
            if (a.Username == "admin" && a.Password == "admin")
            {
                FormsAuthentication.SetAuthCookie(a.Username, false);
                return a;
            }

            return null;
        }
    }
}