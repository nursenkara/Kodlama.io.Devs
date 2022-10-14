﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos
{
    /// <summary>
    /// Silinecek programlama dilini döndüren dto sınıfı.
    /// </summary>
    public class DeletedProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
