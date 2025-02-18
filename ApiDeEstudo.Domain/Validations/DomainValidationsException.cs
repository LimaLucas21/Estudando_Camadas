using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDeEstudo.Domain.Validations
{
    public class DomainValidationsException : Exception
    {
        public DomainValidationsException(string error) : base(error) 
        { }

        public static void When(bool hasError, string message)
        {
            if (hasError)
            {
                throw new DomainValidationsException(message);  
            }
        }


    }
}
