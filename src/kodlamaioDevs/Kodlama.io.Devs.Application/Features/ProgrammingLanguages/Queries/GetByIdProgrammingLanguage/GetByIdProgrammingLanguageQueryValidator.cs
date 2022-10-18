using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQueryValidator : AbstractValidator<GetByIdProgrammingLanguageQuery>
    {
        public GetByIdProgrammingLanguageQueryValidator()
        {
            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageIdIsRequired);

            RuleFor(p => p.Id)
                .GreaterThan(0)
                .WithMessage(ProgrammingLanguageMessages.ProgrammingLanguageIdGreaterThanZero);
        }
    }
}
