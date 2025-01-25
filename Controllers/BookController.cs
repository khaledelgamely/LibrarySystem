using librarySystem.Models.Repository;
using librarySystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using librarySystem.ViewModels;

namespace librarySystem.Controllers
{
    public class BookController : Controller
    {
        public readonly ILiberaryRepository<Book> bookRepo;
        private readonly ILiberaryRepository<Author> authorRepo;

        public BookController(ILiberaryRepository<Book> bookRepo, ILiberaryRepository<Author> authorRepo)
        {
            this.bookRepo = bookRepo;
            this.authorRepo = authorRepo;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var books = bookRepo.List();
            return View(books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var book = bookRepo.Find(id);
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookAuthorViewModel
            {
                authors = FillSelectList()
            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAuthorViewModel bookModel)
        {
           //if (ModelState.IsValid)
            //{
                try
                {
                    if (bookModel.AuthorId == -1)
                    {
                        ViewBag.MSG = "Fill the form";
                       
                        return View(GetAllAuthors());
                    }
                    Book book = new Book
                    {
                        Id = bookModel.Id,
                        Title = bookModel.Title,
                        Description = bookModel.Description,
                        Author = authorRepo.Find(bookModel.AuthorId),
                    };
                    bookRepo.Add(book);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }

            //}

            //ModelState.AddModelError("", "you have to fill allddddd");

            //return View(GetAllAuthors());
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = bookRepo.Find(id);
            var authorId = book.Author == null ? 0 : book.Author.Id;

            var viewModel = new BookAuthorViewModel
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                AuthorId = authorId,
                authors = authorRepo.List().ToList(),
            };
            return View(viewModel);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookAuthorViewModel bookModel)
        {
            try
            {
                Book book = new Book
                {
                    Id = bookModel.Id,
                    Title = bookModel.Title,
                    Description = bookModel.Description,
                    Author = authorRepo.Find(bookModel.AuthorId),
                };
                bookRepo.Update(bookModel.Id, book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = bookRepo.Find(id);
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {
                bookRepo.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        List<Author> FillSelectList ()
        {
            var authors = authorRepo.List().ToList();
            authors.Insert(0, new Author { Id = -1, Name = "--Please Select An Author--" });
            return authors;
        }

        BookAuthorViewModel GetAllAuthors()
        {
            var vmodel = new BookAuthorViewModel
            {
                authors = FillSelectList()
            };
            return vmodel;
        }

        public IActionResult Search(string term)
        {
            var result = bookRepo.Search(term);
            return View("Index",result);
        }
    }
}
