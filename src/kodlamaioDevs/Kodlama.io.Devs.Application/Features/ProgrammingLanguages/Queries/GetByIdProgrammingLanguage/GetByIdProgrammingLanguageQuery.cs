using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    /// <summary>
    /// Programlama dili için sorgu sınıfı
    /// </summary>
    public class GetByIdProgrammingLanguageQuery: IRequest<ProgrammingLanguageGetByIdDto>
    {
        public int Id { get; set; }

        /// <summary>
        /// Programlama Dili getirmek için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                var programmingLanguage = await _programmingLanguageRepository.Query().Include(x => x.ProgrammingLanguageTechnologies).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

                _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

                var mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage);
                return mappedProgrammingLanguage;
            }
        }
    }
}
