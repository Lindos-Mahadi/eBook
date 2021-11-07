using eBook.Data;
using eBook.Data.DomainModals;
using eBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBook.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context = null;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                   .Select(book => new BookModel()
                   {
                       Author = book.Author,
                       Category = book.Category,
                       Description = book.Description,
                       Id = book.Id,
                       LanguageId = book.LanguageId,
                       Language = book.Language.Name,
                       Title = book.Title,
                       TotalPages = book.TotalPages,
                       CoverImageUrl = book.CoverImageUrl
                   }).ToListAsync();
        }

        public async Task<BookModel> GetBookById(int id)
        {

            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                return await _context.Books.Where(x => x.Id == id)
                 .Select(book => new BookModel()
                 {
                     Author = book.Author,
                     Category = book.Category,
                     Description = book.Description,
                     Id = book.Id,
                     LanguageId = book.LanguageId,
                     Language = book.Language.Name,
                     Title = book.Title,
                     TotalPages = book.TotalPages,
                     CoverImageUrl = book.CoverImageUrl,
                     BookPdfUrl = book.BookPdfUrl
                 }).FirstOrDefaultAsync();

                //return bookDetails;
            }

            return null;
        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books
                  .Select(book => new BookModel()
                  {
                      Author = book.Author,
                      Category = book.Category,
                      Description = book.Description,
                      Id = book.Id,
                      LanguageId = book.LanguageId,
                      Language = book.Language.Name,
                      Title = book.Title,
                      TotalPages = book.TotalPages,
                      CoverImageUrl = book.CoverImageUrl
                  }).Take(count).ToListAsync();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return null;
        }

    }
}
