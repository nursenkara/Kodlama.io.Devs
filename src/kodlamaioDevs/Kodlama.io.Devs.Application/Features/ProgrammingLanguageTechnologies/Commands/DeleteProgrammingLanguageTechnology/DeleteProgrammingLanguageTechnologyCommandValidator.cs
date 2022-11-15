using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology
{
    /// <summary>
    /// Programlama dili silme komutu için validasyon sınıfıdır.
    /// </summary>
    public class DeleteProgrammingLanguageTechnologyCommandValidator : AbstractValidator<DeleteProgrammingLanguageTechnologyCommand>
    {
        public DeleteProgrammingLanguageTechnologyCommandValidator()
        {
            RuleFor(d => d.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage(ProgrammingLanguageTechnologyMessages.IdIsRequired);

            RuleFor(d => d.Id)
               .GreaterThan(0)
               .WithMessage(ProgrammingLanguageTechnologyMessages.GreaterThanZero);
        }
    }
}
