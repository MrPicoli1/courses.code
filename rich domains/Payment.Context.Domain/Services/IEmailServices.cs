using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Context.Domain.Services
{
    public interface IEmailServices
    {
        void Send(string to, string email, string subject, string body);
    }
}
