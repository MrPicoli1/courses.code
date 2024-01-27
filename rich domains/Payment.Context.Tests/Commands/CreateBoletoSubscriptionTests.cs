using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Context.Domain.Commands;

namespace Payment.Context.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionTests
    {
        [TestMethod] public void ShouldReturnIsInvalid() 
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Te";
            command.LastName = "Te";

            command.Validate();

            Assert.IsFalse(command.IsValid);
        }
    }
}
