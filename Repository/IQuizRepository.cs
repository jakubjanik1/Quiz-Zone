using Quiz_Zone.Models;
using System.Collections.Generic;

namespace Quiz_Zone.Repository
{
    public interface IQuizRepository
    {
        IEnumerable<Question> Questions { get; }

        IEnumerable<Category> Categories { get; }

        IEnumerable<Account> Accounts { get; }

        Account FindAccount(Account account);

        void UpdateScore(int accountId, int categoryId, int newScore);

        void SaveAccount(Account account);

        void SaveCategory(Category category);

        void DeleteCategory(int categoryId);

        void SaveQuestion(Question question);

        Question DeleteQuestion(int questionId);
    }
}
