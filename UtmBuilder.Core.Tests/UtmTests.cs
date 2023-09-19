using UtmBuilder.Core.ValueObjtecs;

namespace UtmBuilder.Core.Tests;

[TestClass]
public class UtmTests
{
    private readonly Url _url = new ("https://womi.com.br/");
    private readonly Campaign _cmp = new ("src", "med", "nme", "id", "ter", "ctn");
    private const string _result = "https://womi.com.br/?utm_source=src&utm_medium=med&utm_campaign=nme&utm_id=id&utm_term=ter&utm_content=ctn";

    [TestMethod]
    public void ShouldReturnUrlFromUtm()
    {
        var utm = new Utm(_url, _cmp);
        Assert.AreEqual(_result, utm.ToString());
        Assert.AreEqual(_result, (string)utm);
    }

    [TestMethod]
    public void ShouldReturnUtmFromUrl()
    {
        Utm utm = _result;
        Assert.AreEqual("https://womi.com.br/", utm.Url.Address);
        Assert.AreEqual("src", utm.Campaign.Source);
        Assert.AreEqual("med", utm.Campaign.Medium);
        Assert.AreEqual("nme", utm.Campaign.Name);
        Assert.AreEqual("id", utm.Campaign.Id);
        Assert.AreEqual("ter", utm.Campaign.Term);
        Assert.AreEqual("ctn", utm.Campaign.Content);
    }

}
