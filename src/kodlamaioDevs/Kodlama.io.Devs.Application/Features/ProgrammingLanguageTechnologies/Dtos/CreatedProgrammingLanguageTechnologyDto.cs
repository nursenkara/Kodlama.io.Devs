using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Dtos
{
    /// <summary>
    /// Oluşturulacak programlama dili teknolojisini döndüren dto sınıfı.
    /// </summary>
    public class CreatedProgrammingLanguageTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
