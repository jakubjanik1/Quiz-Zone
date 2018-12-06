using Quiz_Zone.Repository;
using System.Web.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using Quiz_Zone.Models;

namespace Quiz_Zone.Controllers
{
    public class MainController : Controller
    {
        private IQuizRepository repository;
        private readonly int numberOfRounds = 1;

        public MainController(IQuizRepository repo)
        {
            repository = repo;            
        }

        public ViewResult Quizzes()
        {         
            return View( GetCategoriesWithQuestions() );
        }

        public ViewResult Play(int categoryId)
        {
            var questions = TakeRandomQuestions(categoryId);
            return View( questions );
        }
        
        public ViewResult Ranking(int categoryId = 1)
        {
            ViewBag.Categories = GetAllCategories();
            ViewBag.CurrentCategoryName = GetCurrentCategoryName(categoryId);

            return View( GetScores(categoryId) );
        }

        public ViewResult Informations()
        {
            return View();
        }

        [NonAction]
        private IEnumerable<Category> GetCategoriesWithQuestions()
        {
            foreach (var category in repository.Categories)
            {
                if (repository.Questions.Any(x => x.Category == category))
                {
                    yield return category;
                }
            }
        }

        [NonAction]
        private IEnumerable<Question> TakeRandomQuestions(int categoryId)
        {
            var repo = repository.Questions.Where(x => x.Category.CategoryID == categoryId);
            var random = new Random();
            for(int numOfQuestion = 1; numOfQuestion <= numberOfRounds; numOfQuestion++)
            {
                var index = random.Next(0, repo.Count());
                yield return repo.ElementAt(index);
            }
        }

        [NonAction]
        private IEnumerable<KeyValuePair<string, int>> GetScores(int categoryId)
        {
            var accountScores = new List<KeyValuePair<string, int>>();
            foreach (var account in repository.Accounts)
            {
                int score = account.Scores.Where(a => a.CategoryID == categoryId).FirstOrDefault().Value;
                accountScores.Add(new KeyValuePair<string, int>(account.Login, score));
            }
            return accountScores.OrderByDescending(a => a.Value);
        }

        [NonAction]
        private string GetCurrentCategoryName(int categoryId)
        {
            if (repository.Accounts.Any())
            {
                var randomAccount = repository.Accounts.ElementAt(0);
                var currrentCategory = randomAccount.Scores.Where(a => a.CategoryID == categoryId).First().Category;
                return currrentCategory.Name;
            }
            return null;
        }

        [NonAction]
        private IEnumerable<Category> GetAllCategories()
        {
            var randomAccount = repository.Accounts.ElementAt(0);
            return randomAccount.Scores.Select(c => c.Category).Distinct();
        } 
    }  
}