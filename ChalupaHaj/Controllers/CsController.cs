using Microsoft.AspNetCore.Mvc;
using ChalupaHaj.Models;
using ChalupaHaj.Data;
using System.Net.Mail;
using System.Text;

namespace ChalupaHaj.Controllers
{
    //main controller for cs language
    public class CsController : Controller
    {
        //creates database context
        private readonly ApplicationDbContext _context;

        public CsController(ApplicationDbContext context)
        {
            _context = context;

        }


        //returns home page
        public IActionResult Index()
        {
            return View();
        }
       

        //returns page with points of interest
        public IActionResult Okoli()
        {
            return View();
        }


        //returns page with galery
        public IActionResult Galerie()
        {
            return View();
        }


        //returns page with pricelist
        public IActionResult Cenik()
        {
            return View();
        }


        //returns page with contact form
        public IActionResult Kontakt()
        {
            return View();
        }


        //CONTACT US FORM
        //on post saves contact us form to the database and sends it to email
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Email,Phone,Message")] Form contactUsForm)
        {
            //check if form inputs are valid
            if (ModelState.IsValid)
            {
                //saves form to database
                _context.Add(contactUsForm);
                await _context.SaveChangesAsync();


                //creates new mail with sender and reciever
                string to = "cernyvo4@chalupa-haj.cz";
                string from = "cernyvo4@chalupa-haj.cz";
                MailMessage mail = new MailMessage(from, to);


                //creates mailbody
                string mailbody = "<h1>Chalupa Háj | Nový dotaz</h1><br><hr><br>" + contactUsForm.Message + "<br><br>" + "<hr><br>" + contactUsForm.Name + " " + contactUsForm.Surname + "<br>" + contactUsForm.Email + "<br>" + contactUsForm.Phone;
                mail.Subject = "Chalupa Háj | Nový dotaz";
                mail.Body = mailbody;
                mail.BodyEncoding = Encoding.UTF8;


                //smpt server settings
                mail.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.forpsi.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("cernyvo4@chalupa-haj.cz", "Apollo11!");
                client.Credentials = basicCredential1;


                //tries to send email
                try
                {
                    client.Send(mail);
                    ViewBag.SendedFormType = "Děkujeme! Vaše zpráva byla úspěšně odeslána.";
                    return View("Odeslano");
                }


                //throws exception if send was unsuccessfull
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return View("Index");
        }


        //returns page with reservation form
        public IActionResult Rezervace()
        {
            return View();
        }


        //RESERVATION FORM
        //on post reservation form to the database and sends it to email
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rezervace([Bind("Id,Name,Surname,Email,Phone,Arrival,Departure,NumberOfPersons,Message")] ReservationForm reservationForm)
        {
            if (ModelState.IsValid)
            {
                //saves form to database
                _context.Add(reservationForm);
                await _context.SaveChangesAsync();


                //creates new mail with sender and reciever
                string to = "cernyvo4@chalupa-haj.cz";
                string from = "cernyvo4@chalupa-haj.cz";
                MailMessage mail = new MailMessage(from, to);


                //creates mail body
                string mailbody = "<h1>Chalupa Háj | Nová rezervace</h1><br><hr><br>" + reservationForm.Name + " " + reservationForm.Surname + "<br>" + reservationForm.Email + "<br>" + reservationForm.Phone + "<br><br><hr><br>Datum příjezdu: " + reservationForm.Arrival + "<br>Datum odjezdu: " + reservationForm.Departure + "<br>Počet osob: " + reservationForm.NumberOfPersons + "<br><br><hr><br>" + reservationForm.Message;
                mail.Subject = "Chalupa Háj | Nová rezervace";
                mail.Body = mailbody;
                mail.BodyEncoding = Encoding.UTF8;


                //smpt server settings
                mail.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.forpsi.com", 587);
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                System.Net.NetworkCredential basicCredential1 = new
                System.Net.NetworkCredential("cernyvo4@chalupa-haj.cz", "Apollo11!");
                client.Credentials = basicCredential1;


                //tries to send email
                try
                {
                    client.Send(mail);
                    ViewBag.SendedFormType = "Děkujeme! Vaše nezávazná poptávka byla úspěšna přijata. Brzy Vás kontaktujeme s potvrzením a cenovou kalkulací.";
                    return View("Odeslano");
                }


                //throws exception if send was unsuccessfull
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            //returns page after successfully sended
            return View("Odeslano");
        }     
    }
}
