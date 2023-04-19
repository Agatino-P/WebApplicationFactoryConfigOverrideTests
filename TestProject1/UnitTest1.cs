namespace TestProject1;

public class UnitTest1 :IClassFixture<MyWebFactory>
{
    private readonly MyWebFactory _webFactory;

    public UnitTest1(MyWebFactory webFactory)
    {
        _webFactory = webFactory;
    }
    [Fact]
    public async Task Test1Async()
    {
        var c = _webFactory.CreateClient();
        var r =await c.GetAsync("/weatherforecast");
        var s= await r.Content.ReadAsStringAsync();
        Assert.True(s== "Test");
    }
}