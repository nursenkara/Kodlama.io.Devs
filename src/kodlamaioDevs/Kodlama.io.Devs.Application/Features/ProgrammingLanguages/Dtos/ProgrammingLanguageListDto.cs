using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos
{
    /// <summary>
    /// Tüm programlama dilini döndüren dto sınıfı.
    /// </summary>
    public class ProgrammingLanguageListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProgrammingLanguageTechnologyListDto> ProgrammingTechnologies { get; set; }
    }
}
