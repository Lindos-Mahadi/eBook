using eBook.Models;
using eBook.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult GetAllBooks()
        {
            var allData = _bookRepository.GetAllBooks();
            return View(allData);
        }
        [Route("book-details/{id}")]
        public ActionResult BookDetails(int id, string nameOfBook)
        {
            var bookDetails = _bookRepository.GetBookById(id);
            return View(bookDetails);
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }
        [HttpGet]
        public ActionResult AddNewBook(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public ActionResult AddNewBook(BookModel bookModel)
        {
            int id = _bookRepository.AddNewBook(bookModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBook), new { isSuccess = true});
            }
            return View();
        }
    }
}
