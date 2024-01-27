using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Context.Domain.Entities;
using Payment.Context.Domain.Enuns;
using Payment.Context.Domain.Queries;
using Payment.Context.Domain.ValueObjects;

namespace Payment.Context.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public  StudentQueriesTests()
        {
            _students = new List<Student>();
            for (var i = 0; i <= 10; i++)
            {
                _students.Add(new Student(
                    new Name("Aluno", i.ToString()), new Email(i.ToString() + "@balta.io"),
                    new Document("1111111111" + i.ToString(), EDocumentType.CPF))
                    );
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudent("12345678911");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, studn);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentExists()
        {
            var exp = StudentQueries.GetStudent("11111111111");
            var studn = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, studn);
        }


    }
       
    
}
