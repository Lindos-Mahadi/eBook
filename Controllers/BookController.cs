using eBook.Models;
using eBook.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eBook.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(IBookRepository bookRepository, 
            ILanguageRepository languageRepository, 
            IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        [Route("all-book")]
        public async Task<IActionResult> GetAllBooks()
        {
            var allData = await _bookRepository.GetAllBooks();

            return View(allData);
        }
        [Route("book-details/{id:int:min(1)}")]
        public async Task<ActionResult> BookDetails(int id)
        {
            var bookDetails = await _bookRepository.GetBookById(id);
            return View(bookDetails);
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }
        [HttpGet]
        public async Task<ActionResult> AddNewBook(bool isSuccess = false, int bookId = 0 )
        {
            var model = new BookModel();

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "LanguageId", "Name");

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    folder += Guid.NewGuid().ToString() + "_" + bookModel.CoverPhoto.FileName;

                    bookModel.CoverImageUrl = "/" + folder;

                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await bookModel.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                if (bookModel.BookPdf != null)
                {
                    string folder = "books/pdf/";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);
                }

                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "LanguageId", "Name");

            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
