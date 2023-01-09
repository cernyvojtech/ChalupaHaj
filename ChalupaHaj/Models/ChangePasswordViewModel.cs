using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ChalupaHaj.Models
{
    //changes users password
    public class ChangePasswordViewModel
    {
        //user - old password
        [Required(ErrorMessage = "Zadejte Vaše současné heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Aktuální heslo")]
        public string OldPassword { get; set; }


        //user - new password
        [Display(Name = "Nové heslo")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Zadejte Vaše nové heslo")]
        [StringLength(100, ErrorMessage = "Heslo musí být alespoň 8 znaků dlouhé", MinimumLength = 8)]
        public string NewPassword { get; set; }


        //confirmation password
        [Display(Name = "Potvrzení nového hesla")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Zadaná hesla se neshodují")]
        public string ConfirmPassword { get; set; } 
    }
}
