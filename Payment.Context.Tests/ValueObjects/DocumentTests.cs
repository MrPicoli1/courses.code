using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Context.Domain.Enuns;
using Payment.Context.Domain.ValueObjects;

namespace Payment.Context.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(!doc.IsValid);
        }
        [TestMethod]
        public void ShouldReturnSuccesWhenCNPJIsValid()
        {
            var doc = new Document("12478108000173", EDocumentType.CNPJ);
            Assert.IsTrue(doc.IsValid);
        }
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(!doc.IsValid);

        }
        [TestMethod]
        public void ShouldReturnSuccesWhenCPFIsValid()
        {
            var doc = new Document("38100128073", EDocumentType.CPF);
            Assert.IsTrue(doc.IsValid);
        }
    }
}
