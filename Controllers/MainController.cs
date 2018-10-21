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
        private IQuestionRepository repository;

        public MainController(IQuestionRepository repo)
        {
            repository = repo;            
        }

        public ViewResult Quizzes()
        {
            return View(repository.Questions
                .Select(x => x.Category)
                .Distinct());
        }

        public ViewResult Play(string category)
        {
            var random = new Random();
            var questions = new List<Question>();
            for (int i = 0; i < 2; i++)
            {
                var index = random.Next(0, 4);
                questions.Add(repository.Questions.ElementAt(index));
            }
            return View(questions);
        }
    }
}