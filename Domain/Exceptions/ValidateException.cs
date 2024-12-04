using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidateException : Exception
    {
        public IReadOnlyDictionary<string, string[]> ErrorsDictionary { get; }
        public ValidateException(IReadOnlyDictionary<string, string[]> errorDictionary) :
          base("Uno o más errores de validación han ocurrido") => ErrorsDictionary = errorDictionary;

    }
}
