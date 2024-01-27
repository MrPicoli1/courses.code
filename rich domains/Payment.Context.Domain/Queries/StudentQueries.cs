using Payment.Context.Domain.Entities;
using System.Linq.Expressions;

namespace Payment.Context.Domain.Queries
{
    public static class StudentQueries
    {
        public static Expression<Func<Student,bool>> GetStudent(string document)
        {
            return x => x.Documents.Number == document;
        }
    }
}
