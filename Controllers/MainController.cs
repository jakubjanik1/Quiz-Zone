using Quiz_Zone.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz_Zone.Controllers
{
    public class MainController : Controller
    {
        private IQuestionRepository repository;

        public MainController(IQuestionRepository repo)
        {
            repository = repo;            
        }

        public ViewResult Index()
        {
            return View(repository.Questions);
        }
    }
}