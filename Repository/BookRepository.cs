using eBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBook.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id =1, Title="MVC", Author = "lindos" , Description="This is the description for MVC"},
                new BookModel(){Id =2, Title="Dot Net Core", Author = "lindos" , Description="This is the description for DotNet Core"},
                new BookModel(){Id =3, Title="C#", Author = "lindos" , Description="This is the description for C#"},
                new BookModel(){Id =4, Title="Java", Author = "lindos" , Description="This is the description for Java"},
                new BookModel(){Id =5, Title="Php", Author = "lindos", Description="This is the description for PHP"},
                new BookModel(){Id =6, Title="Azure", Author = "lindos" , Description="This is the description for Azure"},
                new BookModel(){Id =7, Title="Angular", Author = "lindos" , Description="This is the description for Angular"},
                new BookModel(){Id =8, Title="F#", Author = "lindos" , Description="This is the description for F#"},
                new BookModel(){Id =9, Title="React", Author = "lindos" , Description="This is the description for React"},
                new BookModel(){Id =10, Title="Python", Author = "lindos", Description="This is the description for Python"},
                new BookModel(){Id =11, Title="DevOps", Author = "lindos", Description="This is the description for DevOps"},
                new BookModel(){Id =12, Title="Networking", Author = "lindos", Description="This is the description for Networking"},
            };
        }
    }
}
