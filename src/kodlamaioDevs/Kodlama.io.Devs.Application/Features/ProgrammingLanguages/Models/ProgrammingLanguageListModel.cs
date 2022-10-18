using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Models
{
    /// <summary>
    /// Programlama dili için geriye dönen sayfalanmış veri modeli
    /// </summary>
    public class ProgrammingLanguageListModel: BasePageableModel
    {
        public IList<ProgrammingLanguageListDto> Items { get; set; }
    }
}
