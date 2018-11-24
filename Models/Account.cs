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

        public virtual ICollection<Score> Scores { get; set; }
    }
}