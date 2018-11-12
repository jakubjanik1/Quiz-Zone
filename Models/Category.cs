using System.ComponentModel.DataAnnotations;

namespace Quiz_Zone.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Podaj nazwę!")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj opis!")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        public byte[] IconData { get; set; }

        public string IconMimeType { get; set; }

        public string IconName { get; set; }
    }
}