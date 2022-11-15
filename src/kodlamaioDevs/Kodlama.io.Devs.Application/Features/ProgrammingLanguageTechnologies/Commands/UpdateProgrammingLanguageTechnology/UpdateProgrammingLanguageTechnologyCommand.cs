using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLanguageTechnology
{
    public class UpdateProgrammingLanguageTechnologyCommand : IRequest<UpdatedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingLanguageTechnologyCommandHandler : IRequestHandler<UpdateProgrammingLanguageTechnologyCommand, UpdatedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

            public UpdateProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageTechnologyDto> Handle(UpdateProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageTechnologyBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicated(request.Name);

                var programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.Query().AsNoTracking().FirstOrDefaultAsync(x =>
                    x.Id == request.Id,
                    cancellationToken: cancellationToken);

                await _programmingLanguageTechnologyBusinessRules.ProgrammingLanguageMustExistAsync(request.ProgrammingLanguageId);
                _programmingLanguageTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingLanguageTechnology);

                var mappedProgrammingLanguageTechnology = _mapper.Map<ProgrammingLanguageTechnology>(request);
                var updatedProgramminLanguageTechnology = await _programmingLanguageTechnologyRepository.UpdateAsync(mappedProgrammingLanguageTechnology);
                var mappedProgrammingLanguageTechnologyDto = _mapper.Map<UpdatedProgrammingLanguageTechnologyDto>(updatedProgramminLanguageTechnology);

                return mappedProgrammingLanguageTechnologyDto;

            }
        }
    }
}
