using Payment.Context.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Context.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(string barCode, string boletoNumber, DateTime payedDate, DateTime expireDate, decimal total, decimal totalPayed, Address address, Document document, string payer, Email email)
            : base(payedDate, expireDate, total, totalPayed, address, document, payer, email)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }


        public string BarCode { get; private set; }
        public string BoletoNumber { get;private set; }

    }
}
