using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quiz_Zone.DAL;
using Quiz_Zone.Models;

namespace Quiz_Zone.Repository
{
    public class DbQuizRepository : IQuizRepository
    {
        private QuizDbContext context = new QuizDbContext();

        public IEnumerable<Question> Questions
        {
            get { return context.Questions; }
        }

        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }

        public IEnumerable<Account> Accounts
        {
            get { return context.Accounts; }
        }

        public void SaveAccount(Account account)
        {
            account.Scores = new List<Score>();       
            foreach(var category in context.Categories)
            {               
                account.Scores.Add(new Score { Value = 0, CategoryID = category.CategoryID });
            }
            context.Accounts.Add(account);
            context.SaveChanges();
        }

        public void UpdateScore(int accountId, int categoryId, int newScore)
        {
            var activeAccount = context.Accounts.Where(a => a.AccountID == accountId).FirstOrDefault();
            var oldScore = activeAccount.Scores.Where(c => c.CategoryID == categoryId).FirstOrDefault();
            var dbEntry = context.Scores.Find(oldScore.ScoreID);

            dbEntry.Value += newScore;

            context.SaveChanges();
        }

        public Account FindAccount(Account account)
        {
            var foundAccount = context.Accounts.Where(a => a.Login == account.Login).FirstOrDefault();
            if (foundAccount != null)
            {
                return (foundAccount.Password == account.Password) ? foundAccount : null;
            }
            return null;
        }

        public void SaveCategory(Category category)
        {
            if (category.CategoryID == 0)
            {
                context.Categories.Add(category);

                foreach (var account in context.Accounts)
                {
                    account.Scores.Add(new Score { Value = 0, CategoryID = category.CategoryID });
                }
            }
            else
            {              
                var dbEntry = context.Categories.Find(category.CategoryID);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                    dbEntry.Description = category.Description;
                    dbEntry.IconData = category.IconData;
                    dbEntry.IconMimeType = category.IconMimeType;
                    dbEntry.IconName = category.IconName;
                }              
            }
            context.SaveChanges();
        }


        public void DeleteCategory(int categoryId)
        {
            var questionsToRemove = context.Questions.Where(q => q.CategoryID == categoryId);
            foreach (var question in questionsToRemove)
            {
                DeleteQuestionEntry(question.QuestionID);
            }           

            var dbEntry = context.Categories.Find(categoryId);
            if (dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
            }

            foreach (var account in context.Accounts)
            {
                var scoreToRemove = account.Scores.Where(s => s.CategoryID == dbEntry.CategoryID).FirstOrDefault();
                context.Scores.Remove(scoreToRemove);
            }

            context.SaveChanges();
        }

        public void SaveQuestion(Question question)
        {
            if (question.QuestionID == 0)
            {
                context.Questions.Add(question);
            }
            else
            {
                var dbEntry = context.Questions.Find(question.QuestionID);
                if (dbEntry != null)
                {
                    dbEntry.Content = question.Content;
                    dbEntry.AnswerA = question.AnswerA;
                    dbEntry.AnswerB = question.AnswerB;
                    dbEntry.AnswerC = question.AnswerC;
                    dbEntry.AnswerD = question.AnswerD;
                    dbEntry.GoodAnswer = question.GoodAnswer;
                }
            }
            context.SaveChanges();
        }

        public Question DeleteQuestion(int questionId)
        {
            var dbEntry = DeleteQuestionEntry(questionId);
            context.SaveChanges();
            return dbEntry;
        }

        private Question DeleteQuestionEntry(int questionId)
        {
            var dbEntry = context.Questions.Find(questionId);
            if (dbEntry != null)
            {
                context.Questions.Remove(dbEntry);
            }
            return dbEntry;
        }
    }
}