using eBook.Models;
using eBook.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBook.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [Route("all-book")]
        public async Task<IActionResult> GetAllBooks()
        {
            var allData = await _bookRepository.GetAllBooks();

            return View(allData);
        }
        [Route("book-details/{id}")]
        public async Task<ActionResult> BookDetails(int id, string nameOfBook)
        {
            var bookDetails = await _bookRepository.GetBookById(id);
            return View(bookDetails);
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }
        [HttpGet]
        public ActionResult AddNewBook(bool isSuccess = false, int bookId = 0 )
        {
            ViewBag.Language = new SelectList(new List<string>() { "Hindi", "English", "Dutch" });

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            ViewBag.Language = new SelectList(new List<string>() { "Hindi", "English", "Dutch" });

            ModelState.AddModelError("", "This is my custom error message");
            ModelState.AddModelError("", "This is my second custom error message");

            return View();
        }
    }
}
