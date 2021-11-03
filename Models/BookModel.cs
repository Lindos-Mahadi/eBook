﻿using eBook.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBook.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string Category { get; set; }
        [Required(ErrorMessage = "Please choose the language of your book")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Please choose the languages of your book")]
        public List<string> MultiLanguage { get; set; }

        [Required(ErrorMessage = "Please choose the language of your book")]
        public LanguageEnum LanguageEnum { get; set; }

        [Display(Name = "Total pages of book")]
        public int? TotalPages { get; set; }
    }
}
