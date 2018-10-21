namespace Quiz_Zone.Models
{
    public class Question
    {
        public int QuestionID { get; set; }

        public string Content { get; set; }

        public string AnswerA { get; set; }

        public string AnswerB { get; set; }

        public string AnswerC { get; set; }

        public string AnswerD { get; set; }

        public char GoodAnswer { get; set; }

        public string Category { get; set; }
    }
}