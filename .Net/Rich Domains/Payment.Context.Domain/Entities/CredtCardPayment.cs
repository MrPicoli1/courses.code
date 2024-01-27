using Payment.Context.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Context.Domain.Entities
{
    public class CredtCardPayment : Payment
    {
        public CredtCardPayment(string cardHolderName, string cardNumber, string lastTrasactionNumber, DateTime payedDate, DateTime expireDate, decimal total, decimal totalPayed, Address address, Document document, string payer, Email email)
            : base(payedDate, expireDate, total, totalPayed, address, document, payer, email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTrasactionNumber = lastTrasactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTrasactionNumber { get; private set; }
    }
}
