﻿using eBook.Models;
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
                new BookModel(){Id =1, Title="MVC", Author = "lindos" , Description="This is the description for MVC", Category = "Programming", Language = "English", TotalPages = 134},
                new BookModel(){Id =2, Title="Dot Net Core", Author = "lindos" , Description="This is the description for DotNet Core", Category = "Framework", Language = "Chinese", TotalPages = 567},
                new BookModel(){Id =3, Title="C#", Author = "lindos" , Description="This is the description for C#", Category = "Developer", Language = "Hindi", TotalPages = 897},
                new BookModel(){Id =4, Title="Java", Author = "lindos" , Description="This is the description for Java", Category = "Concept", Language = "English", TotalPages = 564},
                new BookModel(){Id =5, Title="Php", Author = "lindos", Description="This is the description for PHP", Category = "Programming", Language = "English", TotalPages = 100},
                new BookModel(){Id =6, Title="Azure", Author = "lindos" , Description="This is the description for Azure", Category = "DevOps", Language = "English", TotalPages = 800},
                new BookModel(){Id =7, Title="Angular", Author = "lindos" , Description="This is the description for Angular", Category = "DevOps", Language = "English", TotalPages = 800},
                new BookModel(){Id =8, Title="F#", Author = "lindos" , Description="This is the description for F#", Category = "Concept", Language = "English", TotalPages = 800},
                new BookModel(){Id =9, Title="React", Author = "lindos" , Description="This is the description for React", Category = "DevOps", Language = "English", TotalPages = 800},
                new BookModel(){Id =10, Title="Python", Author = "lindos", Description="This is the description for Python", Category = "Concept", Language = "English", TotalPages = 800},
                new BookModel(){Id =11, Title="DevOps", Author = "lindos", Description="This is the description for DevOps", Category = "DevOps", Language = "English", TotalPages = 800},
                new BookModel(){Id =12, Title="Networking", Author = "lindos", Description="This is the description for Networking", Category = "DevOps", Language = "English", TotalPages = 800},
            };
        }
    }
}