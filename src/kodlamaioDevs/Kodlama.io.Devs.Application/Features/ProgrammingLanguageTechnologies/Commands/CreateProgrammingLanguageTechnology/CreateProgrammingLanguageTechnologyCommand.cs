using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology
{
    /// <summary>
    /// Programlama dili teknolojisi oluşturma komutu
    /// </summary>
    public class CreateProgrammingLanguageTechnologyCommand: IRequest<CreatedProgrammingLanguageTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Programlama dili teknolojisi oluşturmak için kullanılan işleyici sınıftır.
        /// </summary>
        public class CreateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<CreateProgrammingLanguageTechnologyCommand, CreatedProgrammingLanguageTechnologyDto>
        {

            public async Task<CreatedProgrammingLanguageTechnologyDto> Handle(CreateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
