using System.ComponentModel.DataAnnotations;

namespace ChalupaHaj.Models
{

    //contact form model for main and contact us page
    public class ReservationForm
    {
        //primary key
        public int Id { get; set; }


        //Name of sender
        [Display(Name = "Jméno")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Zadejte prosím Vaše jméno")]
        public string Name { get; set; } = "";


        //Surname of sender
        [Display(Name = "Příjmení")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Zadejte prosím Vaše příjmení")]
        public string Surname { get; set; } = "";


        //Email of sender
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Zadejte prosím Vaši emailovou adresu")]
        [RegularExpression("[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}", ErrorMessage = "Neplatná emailová adresa")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = "";


        //Phone number of sender
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Zadejte prosím Vaše telefonní číslo")]
        public string Phone { get; set; } = "";


        //Date of arrival
        [Display(Name = "Datum příjezdu")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Zadejte prosím datum příjezdu")]
        public string Arrival { get; set; } = "";


        //Date of departure
        [Display(Name = "Datum odjezdu")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Zadejte prosím datum odjezdu")]
        public string Departure { get; set; } = "";


        //Number of persons
        [Display(Name = "Počet osob")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Zadejte prosím počet osob")]
        public string NumberOfPersons { get; set; } = "";


        //Message field
        [Display(Name = "Zpráva")]
        [Required(ErrorMessage = "Zadejte prosím Vaši zprávu")]
        [DataType(DataType.Text)]
        public string Message { get; set; } = "";
    }
}
