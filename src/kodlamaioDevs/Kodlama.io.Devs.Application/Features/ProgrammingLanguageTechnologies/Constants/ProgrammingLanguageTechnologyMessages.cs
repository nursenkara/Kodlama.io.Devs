using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.Constants
{
    /// <summary>
    /// Programlama Dili Teknolojisi mesajları
    /// </summary>
    public static class ProgrammingLanguageTechnologyMessages
    {
        public const string ProgrammingLanguageNotFound = "Programming Language was not found";
        public const string NameIsAlreadyExist = "Name is already exist";
        public const string DoesNotHaveAnyRecords = "Does not have any records";
        public const string NameIsRequired = "Name is required";
        public const string ProgrammingLanguageIdIsRequired = "Programming Language Id is required";
        public const string ProgrammingLanguageIdGreaterThanZero = "Programming language id is must be greater than zero";

    }
}
