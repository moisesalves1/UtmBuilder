using UtmBuilder.Core.ValueObjects.Exceptions;
using UtmBuilder.Core.ValueObjtecs;

namespace UtmBuilder.Core.Tests.ValueObjects;

[TestClass]
public class UrlTests
{
    private const string InvalidUrl = "melancia";
    private const string ValidUrl = "https://womi.com.br";

    [TestMethod]
    [ExpectedException(typeof(InvalidUrlException))]
    public void ShouldReturnExceptionWhenUrlIsInvalid()
    {
        new Url(InvalidUrl);
    }

    [TestMethod]
    public void ShouldNotReturnExceptionWhenUrlIsValid()
    {
        new Url(ValidUrl);
        Assert.IsTrue(true);
    }

    [TestMethod]
    [DataRow(" ", true)]
    [DataRow("http", true)]
    [DataRow("melancia", true)]
    [DataRow("https://womi.com.br", false)]
    public void TestUrl(string link, bool expectException)
    {
        if(expectException)
        {
            try
            {
                new Url(link);
                Assert.Fail();
            }
            catch(InvalidUrlException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
