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

        public void SaveCategory(Category category)
        {
            if (category.CategoryID == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                var dbEntry = context.Categories.Find(category.CategoryID);
                if(dbEntry != null)
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
            foreach(var question in questionsToRemove)
            {
                DeleteQuestionEntry(question.QuestionID);
            }

            var dbEntry = context.Categories.Find(categoryId);
            if (dbEntry != null)
            {
                context.Categories.Remove(dbEntry);
                context.SaveChanges();
            }
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