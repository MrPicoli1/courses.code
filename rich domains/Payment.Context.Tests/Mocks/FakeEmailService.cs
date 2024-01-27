using Payment.Context.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Context.Tests.Mocks
{
    public class FakeEmailService : IEmailServices
    {
        public void Send(string to, string email, string subject, string body)
        {

        }
    }
}
