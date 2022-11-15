using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Commands.DeleteProgrammingLanguageTechnology
{
    public class DeleteProgrammingLanguageTechnologyCommand : IRequest<DeletedProgrammingLanguageTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguageTechnologyCommandHandler : IRequestHandler<DeleteProgrammingLanguageTechnologyCommand, DeletedProgrammingLanguageTechnologyDto>
        {
            private readonly IProgrammingLanguageTechnologyRepository _programmingLanguageTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingLanguageTechnologyBusinessRules;

            public DeleteProgrammingLanguageTechnologyCommandHandler(IProgrammingLanguageTechnologyRepository programmingLanguageTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingLanguageTechnologyBusinessRules)
            {
                _programmingLanguageTechnologyRepository = programmingLanguageTechnologyRepository;
                _mapper = mapper;
                _programmingLanguageTechnologyBusinessRules = programmingLanguageTechnologyBusinessRules;
            }
            public async Task<DeletedProgrammingLanguageTechnologyDto> Handle(DeleteProgrammingLanguageTechnologyCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguageTechnology = await _programmingLanguageTechnologyRepository.GetAsync(x => x.Id == request.Id);

                _programmingLanguageTechnologyBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(programmingLanguageTechnology);
                var deletedProgrammingLanguageTechnology = await _programmingLanguageTechnologyRepository.DeleteAsync(programmingLanguageTechnology);
                var mappedProgrammingLanguageTechnologyDto = _mapper.Map<DeletedProgrammingLanguageTechnologyDto>(deletedProgrammingLanguageTechnology);
                return mappedProgrammingLanguageTechnologyDto;

            }
        }
    }
}
