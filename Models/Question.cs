using System.ComponentModel.DataAnnotations;

namespace Quiz_Zone.Models
{
    public class Question
    {
        public int QuestionID { get; set; }

        [Required(ErrorMessage = "Podaj treść pytania")]
        [Display(Name = "Treść")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Podaj odpowiedź A")]
        [Display(Name = "Odpowiedź A")]
        public string AnswerA { get; set; }

        [Required(ErrorMessage = "Podaj odpowiedź B")]
        [Display(Name = "Odpowiedź B")]
        public string AnswerB { get; set; }

        [Required(ErrorMessage = "Podaj odpowiedź C")]
        [Display(Name = "Odpowiedź C")]
        public string AnswerC { get; set; }

        [Required(ErrorMessage = "Podaj odpowiedź D")]
        [Display(Name = "Odpowiedź D")]
        public string AnswerD { get; set; }

        [Required(ErrorMessage = "Podaj poprawną odpowiedź")]
        [RegularExpression("[A-D]", ErrorMessage = "Podaj literę A, B, C lub D")]
        [Display(Name = "Poprawna odpowiedź")]
        public string GoodAnswer { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}