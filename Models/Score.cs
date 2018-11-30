namespace Quiz_Zone.Models
{
    public class Score
    {
        public int ScoreID { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public int Value { get; set; }
    }
}