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
        private readonly int numberOfRounds = 2;

        public MainController(IQuizRepository repo)
        {
            repository = repo;            
        }

        public ViewResult Quizzes()
        {
            return View(repository.Categories);
        }

        public ViewResult Play(string category)
        {
            var questions = TakeRandomQuestions(category);
            return View(questions);
        }

        private IEnumerable<Question> TakeRandomQuestions(string category)
        {
            var repo = repository.Questions.Where(x => x.Category.Name == category);
            var random = new Random();
            for(int numOfQuestion = 1; numOfQuestion <= numberOfRounds; numOfQuestion++)
            {
                var index = random.Next(0, repo.Count());
                yield return repo.ElementAt(index);
            }
        }
    }
}