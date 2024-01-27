using Flunt.Validations;
using Payment.Context.Shared.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Payment.Context.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
           
            AddNotifications(new Contract<Name>()
                .Requires()
                .IsGreaterThan(firstName,3,"Nome deve conter pelo menos 3 Caracteres")
                .IsGreaterThan(lastName, 3, "Sobrenome deve conter pelo menos 3 Caracteres"));
          
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
