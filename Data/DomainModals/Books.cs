﻿using eBook.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBook.Data.DomainModals
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }

        public List<string> MultiLanguage { get; set; }
        public LanguageEnum LanguageEnum { get; set; }

        public int TotalPages { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
