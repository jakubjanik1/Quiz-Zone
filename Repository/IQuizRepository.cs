using Quiz_Zone.Models;
using System.Collections.Generic;

namespace Quiz_Zone.Repository
{
    public interface IQuizRepository
    {
        IEnumerable<Question> Questions { get; }

        IEnumerable<Category> Categories { get; }
    }
}
