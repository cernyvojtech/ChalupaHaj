using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChalupaHaj.Models
{
    //News - manages articles in news section on main page
    public class News
    {
        //primary key
        [Key]
        public int Id { get; set; }


        //Title of article in news section
        [Required(ErrorMessage = "Zadejte prosím název novinky")]
        [Display(Name = "Název")]
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }


        //Description of article in news section
        [Display(Name = "Popis")]
        public string Description { get; set; }


        //Price of last minute in article
        [Display(Name = "Cena")]
        [StringLength(maximumLength: 10)]
        public string Price { get; set; } 
    }
}
