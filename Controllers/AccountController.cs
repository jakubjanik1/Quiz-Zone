using Quiz_Zone.Models;
using Quiz_Zone.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Quiz_Zone.Controllers
{
    public class AccountController : Controller
    {
        private IQuizRepository repository;
        private static Account activeAccount;

        public AccountController(IQuizRepository repo)
        {
            repository = repo;
        }

        public ViewResult SignIn()
        {
            return View(new Account());
        }

        [HttpPost]
        public ActionResult SignIn(Account account)
        {
            bool accountExist = repository.Accounts.Any(a => a.Login == account.Login);
            if (accountExist)
            {
                ModelState.AddModelError("Login", "Konto o takiej nazwie istnieje!");
            }

            if(ModelState.IsValid)
            {
                repository.SaveAccount(account);
                return RedirectToAction("Quizzes", "Main");
            }
            else
            {
                return View(account);
            }
        }

        public ViewResult LogIn()
        {
            return View(new Account());
        }

        [HttpPost]
        public ActionResult LogIn(Account account)
        {
            if (ModelState.IsValid)
            {
                activeAccount = repository.FindAccount(account);
                if (activeAccount == null)
                {
                    ViewBag.Error = "Błędne hasło lub login!";
                    return View(account);
                }
                else
                {
                    return RedirectToAction("Quizzes", "Main");
                }
            }
            return View(account);
        }

        public string GetAccountLogin()
        {
            return activeAccount != null ? activeAccount.Login : string.Empty;
        }

        public void UpdateScore(string categoryName, int scoreValue)
        {
            if (activeAccount != null)
            {
                repository.UpdateScore(activeAccount.AccountID, categoryName, scoreValue);
            }
        }
    }
}