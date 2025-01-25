using librarySystem.Models;
using librarySystem.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace librarySystem.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ILiberaryRepository<Author> AuthorRepo;
        public AuthorController(ILiberaryRepository<Author> AuthorRepo)
        {
            this.AuthorRepo = AuthorRepo;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            var auth = AuthorRepo.List();
            return View(auth);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            var author = AuthorRepo.Find(id);
            return View(author);
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                AuthorRepo.Add(author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            var author = AuthorRepo.Find(id);
            return View(author);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author author)
        {
            try
            {
                AuthorRepo.Update(id, author);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            var author = AuthorRepo.Find(id);

            return View(author);
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                AuthorRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
