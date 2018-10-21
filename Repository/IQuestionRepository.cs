using Quiz_Zone.Models;
using System.Collections.Generic;

namespace Quiz_Zone.Repository
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> Questions { get; }
    }
}
