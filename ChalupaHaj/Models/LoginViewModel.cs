using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ChalupaHaj.Models
{
    //logs in user
    public class LoginViewModel
    {
        //user email
        [Required(ErrorMessage = "Zadejte Váš email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }


        //user password
        [Display(Name = "Heslo")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Zadejte Vaše heslo")]
        
        public string Password { get; set; }


        //remember me option
        [Display(Name = "Pamatuj si mě")]
        public bool RememberMe { get; set; }
    }
}
