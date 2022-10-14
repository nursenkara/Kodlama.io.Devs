using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Constants;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules
{
    /// <summary>
    /// Programlama dili için kurallar
    /// </summary>
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }
        /// <summary>
        /// Programlama Dili Varlığının Adı Tekrar Edemez
        /// </summary>
        /// <param name="name"> Programlama Dili Adı </param>
        /// <returns></returns>
        /// <exception cref="BusinessException"> Programlama Dili Varlığının Adı Tekrar Edemez </exception>
        public async Task ProgrammingLanguageNameCanNotBeDuplicated(string name)
        {
            var result = await _programmingLanguageRepository.GetListAsync(x => x.Name == name);
            if(result.Items.Any())
                throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNameIsAlreadyExist);
        }
        /// <summary>
        /// Programlama dili varlığını id'ye göre kontrol et
        /// </summary>
        /// <param name="id"> Programlama Dili Id </param>
        /// <returns></returns>
        /// <exception cref="BusinessException"> Programlama Dili Bu Id'ye Ait Varlık Bulunamadı </exception>

        public async Task ProgrammingLanguageIdShouldBeExist(int id)
        {
            var result = await _programmingLanguageRepository.GetListAsync(x =>x.Id == id);
            if (!result.Items.Any())
                throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNotFound);
        }

        /// <summary>
        /// Bu programlama dili varlığının boş olup olmadığını kontrol et
        /// </summary>
        /// <param name="programmingLanguage"> Proglama Dili Varlığı </param>
        /// <exception cref="BusinessException"> Programlama Dili Varlığı Boş Olamaz </exception>
        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage is null)
                throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageDoesNotHaveAnyRecords);
            
        }
    }
}
