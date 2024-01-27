using Payment.Context.Domain.Entities;

namespace Payment.Context.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void CreateSubscription(Student student);



    }
}
