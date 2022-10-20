using Core.Persistence.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Services.Repositories
{
    /// <summary>
    /// Programlama dilleri için metotların imzalarını tutar.
    /// </summary>
    public interface IProgrammingLanguageRepository: IAsyncRepository<ProgrammingLanguage>, IRepository<ProgrammingLanguage>
    {
 
    }
}
