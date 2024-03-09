using progettoSettimanale_mvc2_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace progettoSettimanale_mvc2_backend.Controllers
{
    public class AdminController : Controller
    {
        public List<SelectListItem> AnCliente
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<Cliente> lista = DB.AllClienti();
                foreach (Cliente c in lista)
                {
                    SelectListItem item = new SelectListItem { Text = $"{c.CognomeCliente}, {c.NomeCliente}", Value = $"{c.IdCliente}" };
                    list.Add(item);
                }
                return list;
            }
        }

        public List<SelectListItem> ListaCamere
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<Camera> lista = DB.AllCamera();
                foreach (Camera r in lista)
                {
                    SelectListItem item = new SelectListItem { Text = $"{r.NumeroCamera}", Value = $"{r.IdCamera}" };
                    list.Add(item);
                }
                return list;
            }
        }

        public List<Cliente> c = DB.AllClienti();
        public List<Prenotazione> p = DB.AllPrenotazioni();

        public List<SelectListItem> Clienti
        {
            get
            {
                List<SelectListItem> listC = new List<SelectListItem>();
                foreach (Cliente cliente in c)
                {
                    SelectListItem item = new SelectListItem { Text = cliente.CognomeCliente + " " + cliente.NomeCliente, Value = cliente.IdCliente.ToString() };
                    listC.Add(item);
                }
                return listC;
            }
        }

        public List<SelectListItem> Prenotazioni
        {
            get
            {
                List<SelectListItem> listP = new List<SelectListItem>();
                foreach (Prenotazione prenotazione in p)
                {
                    SelectListItem item = new SelectListItem { Value = prenotazione.IdPrenotazione.ToString() };
                    listP.Add(item);
                }
                return listP;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddCliente()
        {
            ViewBag.ListaClienti = DB.AllClienti();
            return View();
        }

        [HttpPost]
        public ActionResult AddCliente(Cliente c)
        {
            if (ModelState.IsValid)
            {
                DB.AddCliente(c.NomeCliente, c.CognomeCliente, c.CittaCliente, c.ProvinciaCliente, c.MailCliente);
                return RedirectToAction("AddCamera");
            }
            else
            {
                ViewBag.ListaClienti = DB.AllClienti();
                return View();
            }
        }

        public ActionResult AddPrenotazione()
        {
            ViewBag.ListaClienti = AnCliente;
            ViewBag.ListaCamere = ListaCamere;
            return View();
        }

        [HttpPost]
        public ActionResult AddPrenotazione(Prenotazione p)
        {
            if (ModelState.IsValid)
            {
                DB.AddPrenotazione(p.DataPrenotazione, p.CheckIn, p.CheckOut, p.CaparraConfirmatoria, p.TariffaApplicata, p.IdCliente, p.IdCamera);
                return RedirectToAction("AllPrenotazioni");
            }
            else
            {
                ViewBag.ListaClienti = DB.AllPrenotazioni();
                return View();
            }
        }

        public ActionResult AddDettagli()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDettagli(Dettagli d)
        {
            if (ModelState.IsValid)
            {
                DB.AddDettagli(d.MezzaPensione, d.PensioneCompleta, d.PrimaColazione, d.IdPrenotazione);
                return RedirectToAction("AddServizi");
            }
            else
            {
                ViewBag.ListaClienti = DB.AllDettagli();
                return View();
            }
        }

        public ActionResult AddServizi()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddServizi(Servizi s)
        {
            if (ModelState.IsValid)
            {
                DB.AddServizi(s.ColazioneInCamera, s.FoodBar, s.InternetCamera, s.LettoAggiuntivo, s.CullaCamera, s.IdPrenotazione, s.Quantita, s.Prezzo);
                return RedirectToAction("AddCamera");
            }
            else
            {
                ViewBag.ListaClienti = DB.AllServizi(s.IdPrenotazione);
                return View();
            }
        }

        public ActionResult AllPrenotazioni()
        {
            List<Prenotazione> lista = DB.AllPrenotazioni();
            return View(lista);
        }

        public ActionResult GetServizi(int id)
        {
            List<Servizi> servizi = DB.AllServizi(id);
            return View(servizi);
        }

        public ActionResult AddCamera()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCamera(Camera r)
        {
            if (ModelState.IsValid)
            {
                DB.AddCamera(r.NumeroCamera, r.CameraSingola, r.CameraDoppia, r.DescrizioneCamera, r.IdCliente);
                return RedirectToAction("AddPrenotazione");
            }
            else
            {
                ViewBag.ListaClienti = DB.AllCamera();
                return View();
            }
        }

        public ActionResult TotaleTutto(int id)
        {
            List<Prenotazione> totale = DB.AllPrenotazioni();
            Prenotazione prenotazione = totale.FirstOrDefault(p => p.IdPrenotazione == id);

            ViewBag.Prenotazione = prenotazione;

            List<Servizi> servizi = DB.AllServizi(id);
            int Servizi = servizi.Sum(serv => serv.Prezzo);
            ViewBag.Servizi = Servizi;

            return View();
        }
    }
}