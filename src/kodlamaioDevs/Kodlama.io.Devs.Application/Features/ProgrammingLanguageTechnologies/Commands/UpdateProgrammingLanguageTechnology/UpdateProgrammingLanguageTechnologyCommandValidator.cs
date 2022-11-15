using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommandValidator : AbstractValidator<UpdateProgrammingLanguageTechnologyCommand>
    {
        public UpdateProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProgrammingLanguageTechnologyMessages.IdIsRequired);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage(ProgrammingLanguageTechnologyMessages.NameIsRequired);

            RuleFor(x => x.ProgrammingLanguageId)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProgrammingLanguageTechnologyMessages.ProgrammingLanguageIdIsRequired);

            RuleFor(x => x.ProgrammingLanguageId)
                .GreaterThan(0)
                .WithMessage(ProgrammingLanguageTechnologyMessages.ProgrammingLanguageIdGreaterThanZero);
        }
    }
}
