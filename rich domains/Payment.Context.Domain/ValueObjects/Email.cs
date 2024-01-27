using Flunt.Validations;
using Payment.Context.Shared.ValueObject;

namespace Payment.Context.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address )
        {
            Address = address;

            AddNotifications(new Contract<Email>().Requires().IsEmailOrEmpty(Address, "Email Invalodo"));
        }

        public string Address { get; private set; }
      
    }
}
