using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ChalupaHaj.Models
{
    //register new user
    public class RegisterViewModel
    {

        //user email
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Zadejte emailovou adresu")]
        public string Email { get; set; }


        //user password
        [Display(Name = "Heslo")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Zadejte heslo")]
        [StringLength(100, ErrorMessage = "Heslo musí být alespoň 8 znaků dlouhé", MinimumLength = 8)]
        public string Password { get; set; }


        //confirmation of password
        [Display(Name = "Potvrzení hesla")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Zadejte heslo pro ověření")]
        [Compare("Password", ErrorMessage = "Zadaná hesla se neshodují")]
        public string ConfirmPassword { get; set; }
    }
}
