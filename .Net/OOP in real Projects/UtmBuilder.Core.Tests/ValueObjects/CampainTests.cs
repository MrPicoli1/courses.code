using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtmBuilder.Core.ValueObjects.Exceptions;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class CampainTests
    {
        [TestMethod]
        [DataRow("", "", "", true)]
        [DataRow("src", "", "", true)]
        [DataRow("src", "med", "", true)]
        [DataRow("src", "med", "nme", false)]
        public void TestCampaign(
        string source,
        string medium,
        string name,
        bool expectException)
        {
            if (expectException)
            {
                try
                {
                    new Campaign(source, medium, name);
                    Assert.Fail();
                }
                catch (InvalidCampaignExeption)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                new Campaign(source, medium, name);
                Assert.IsTrue(true);
            }
        }
    }
}
