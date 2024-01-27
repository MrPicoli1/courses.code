using Flunt.Validations;
using Payment.Context.Domain.ValueObjects;
using Payment.Context.Shared.Entities;

namespace Payment.Context.Domain.Entities
{
    public abstract class Payment : Entity
    {
        public Payment(DateTime payedDate, DateTime expireDate, decimal total, decimal totalPayed, Address address, Document document, string payer, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PayedDate = payedDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPayed = totalPayed;
            Address = address;
            Document = document;
            Payer = payer;
            Email = email;

            AddNotifications(new Contract<Payment>().Requires()
                .IsLowerOrEqualsThan(0,Total,"Payment.Total", "O TOtal nao pode ser 0")
                .IsGreaterOrEqualsThan(Total, TotalPayed, "Payment.TotalPaid","O valor pago eh menor que o total"));;
        }

        public string Number { get; private set; }
        public DateTime PayedDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPayed { get; private set; }
        public Address Address { get; private set; }
        public Document Document { get; private set; }
        public string Payer { get; private set; }
        public Email Email { get; private set; }

    }

   

  

   

}
