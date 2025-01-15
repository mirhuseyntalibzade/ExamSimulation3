using BL.DTOs.NewsDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Validators.NewsValidator
{
    public class AddNewsValidation : AbstractValidator<AddNewsDTO>
    {
        public AddNewsValidation()
        {
            RuleFor(n => n.Image).NotEmpty();
            RuleFor(n => n.Description).NotEmpty();
            RuleFor(n => n.CategoryId).NotEmpty();
        }
    }
}
