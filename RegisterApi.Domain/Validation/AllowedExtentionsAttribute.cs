using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterApi.Domain.Validation
{
    public class AllowedExtentionsAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtentions;
        public AllowedExtentionsAttribute(string[] allowedExtentions)
        {
            _allowedExtentions = allowedExtentions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extention = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!_allowedExtentions.Contains(extention))
                {
                    return new ValidationResult("Foto type is not supported");
                }
            }
            return ValidationResult.Success;
        }
    }
}
