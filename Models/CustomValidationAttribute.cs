using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eBook.Models
{
    public class CustomValidationAttribute : ValidationAttribute
    {
        public CustomValidationAttribute(string text) 
        {
            Text = text;
        }
        public string Text { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string bookName = value.ToString();
                if (bookName.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? "Book Name does not contain the desired value");
        }
    }
}
