﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgLang.Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommandValidator:AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
