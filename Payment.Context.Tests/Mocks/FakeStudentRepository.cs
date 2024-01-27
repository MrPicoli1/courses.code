using Payment.Context.Domain.Entities;
using Payment.Context.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Context.Tests.Mocks
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student student)
        {

        }

        public bool DocumentExists(string document)
        {
            if (document == "99999999999")
                return true;

            return false;
        }

        public bool EmailExists(string email)
        {
            if (email == "hello@balta.io")
                return true;

            return false;
        }
    }
}
