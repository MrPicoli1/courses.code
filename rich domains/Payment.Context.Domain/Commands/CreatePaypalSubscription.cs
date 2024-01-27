using Payment.Context.Domain.Enuns;
using Payment.Context.Domain.ValueObjects;
using Payment.Context.Shared.Commands;

namespace Payment.Context.Domain.Commands
{
    public class CreatePaypalSubscription: ICommand
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

        public string TransactionCode { get;  set; }
        public string PaymentNumber { get;  set; }
        public DateTime PayedDate { get;  set; }
        public DateTime ExpireDate { get;  set; }
        public decimal Total { get;  set; }
        public decimal TotalPayed { get;  set; }
        public string PayerDocument { get;  set; }
        public EDocumentType PayerDocumentType { get; set; }

        public string Payer { get;  set; }
        public string PayerEmail { get;  set; }

        public string Street { get;  set; }
        public string Number { get;  set; }
        public string Neighborhood { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string ZipCode { get;  set; }
        public string Country { get;  set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
