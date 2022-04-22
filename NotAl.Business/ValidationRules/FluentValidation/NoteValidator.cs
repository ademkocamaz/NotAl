using FluentValidation;
using NotAl.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAl.Business.ValidationRules.FluentValidation
{
    public class NoteValidator : AbstractValidator<Note>
    {
        public NoteValidator()
        {
            RuleFor(n => n.Title).NotEmpty().WithMessage("Başlık boş olamaz");
            RuleFor(n => n.Title).Length(0, 1000).WithMessage("Başlık en fazla 1000 karakter olmalı");
            RuleFor(n => n.Detail).Length(0, 5000).WithMessage("İçerik en fazla 5000 karakter olmalı");
        }

    }
}
