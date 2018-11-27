using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiz_Zone.Models
{
    public class Account
    {
        public int AccountID { get; set; }

        [Required(ErrorMessage = "Podaj login!")]
        public string Login { get; set; }

        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "Podaj hasło!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Wiek")]
        [Range(1, 100, ErrorMessage = "Podaj poprawny wiek!")]
        [RegularExpression("[0-9]+", ErrorMessage = "Podaj proprawny wiek!")]
        public int? Age { get; set; }

        public virtual ICollection<Score> Scores { get; set; }
    }
}