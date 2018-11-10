using Quiz_Zone.Models;
using Quiz_Zone.Repository;
using System.Linq;
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
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(category);
                return RedirectToAction("Categories");
            }
            else
            {
                return View(category);
            }
        }
    }
}