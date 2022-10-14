using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageIdIsRequired);
            RuleFor(c => c.Id)
                .GreaterThan(0)
                .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageIdGreaterThanZero);
            RuleFor(c => c.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageNameIsRequired);
        }
    }
}
