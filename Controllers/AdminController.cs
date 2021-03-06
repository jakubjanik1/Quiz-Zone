﻿using Quiz_Zone.Models;
using Quiz_Zone.Repository;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz_Zone.Controllers
{
    public class AdminController : Controller
    {
        private IQuizRepository repository;

        public AdminController(IQuizRepository repo)
        {
            repository = repo;
        }

        public ViewResult Accounts()
        {
            return View(repository.Accounts);
        }

        public ViewResult Categories()
        {
            return View(repository.Categories);
        }

        public ViewResult EditCategory(int categoryId)
        {
            var category = repository.Categories.FirstOrDefault(c => c.CategoryID == categoryId);
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category, HttpPostedFileBase icon = null)
        {
            if (ModelState.IsValid)
            {
                if (icon != null)
                {
                    category.IconMimeType = icon.ContentType;
                    category.IconName = icon.FileName;
                    category.IconData = new byte[icon.ContentLength];                 
                    icon.InputStream.Read(category.IconData, 0, icon.ContentLength);
                }
                repository.SaveCategory(category);
                return RedirectToAction("Categories");
            }
            else
            {
                return View(category);
            }
        }

        public FileContentResult GetCategoryIcon(int categoryId)
        {
            var category = repository.Categories.FirstOrDefault(c => c.CategoryID == categoryId);
            if (category != null)
            {
                return File(category.IconData, category.IconMimeType);
            }
            else
            {
                return null;
            }
        }

        public ViewResult CreateCategory()
        {
            return View("EditCategory", new Category());
        }

        public ActionResult DeleteCategory(int categoryId)
        {
            repository.DeleteCategory(categoryId);
            return RedirectToAction("Categories");
        }

        public ViewResult Questions(int categoryId)
        {           
            ViewBag.CategoryId = categoryId;
            ViewBag.CategoryName = repository.Categories.First(c => c.CategoryID == categoryId).Name;
            return View( repository.Questions.Where(q => q.CategoryID == categoryId) );
        }

        public ViewResult EditQuestion(int questionId)
        {
            var question = repository.Questions.FirstOrDefault(q => q.QuestionID == questionId);
            return View(question);
        }

        [HttpPost]
        public ActionResult EditQuestion(Question question)
        {
            if (ModelState.IsValid)
            {
                repository.SaveQuestion(question);
                return RedirectToAction("Questions", new { categoryId = question.CategoryID });
            }
            else
            {
                return View(question);
            }
        }

        public ViewResult CreateQuestion(int categoryId)
        {
            return View("EditQuestion", new Question() { CategoryID = categoryId });
        }

        public ActionResult DeleteQuestion(int questionId)
        {
            var question = repository.DeleteQuestion(questionId);
            return RedirectToAction("Questions", new { categoryId = question.CategoryID });
        }
    }
}