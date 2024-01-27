using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Context.Domain.Entities;
using Payment.Context.Domain.Enuns;
using Payment.Context.Domain.ValueObjects;



namespace Payment.Context.Tests.Entities
{
   [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Subscription _subscription;


        public StudentTests()
        {
            _name = new Name("Name", "Name");
            _document = new Document("38100128073", EDocumentType.CPF);
            _email = new Email("email@email.com");
            
            _address = new Address("Ruaa", "1", "Bairro", "Cidade", "Estado", "123456", "Pais");
            _subscription = new Subscription(null);
            
        }


        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscriptions()
        {

            var payment = new PayPalPayment("1234456", DateTime.Now, DateTime.Now.AddDays(3), 10, 10, _address, _document, "Batata", _email);
            _subscription.AddPayment(payment);
            var _student = new Student(_name, _email, _document);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);


            Assert.IsTrue(!_student.IsValid);
        }
        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptionsHasNoPayments()
        {
            var _student = new Student(_name, _email, _document);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(!_student.IsValid);
        }
        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscriptions()
        {
            var _student = new Student(_name, _email, _document);
            var payment = new PayPalPayment("1234456", DateTime.Now, DateTime.Now.AddDays(3), 10, 10, _address, _document, "Batata", _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.IsValid);

        }

    }
}
