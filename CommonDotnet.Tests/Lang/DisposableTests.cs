#region Using Statements

using CommonDotnet.Lang;

#endregion

namespace CommonDotnet.Tests.Lang;

public class DisposableTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public DisposableTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public void Dispose_ExecutesAction()
    {
        bool actionExecuted = false;
        Action action = () => actionExecuted = true;
        Disposable disposable = new(action);

        disposable.Dispose();

        Assert.True(actionExecuted);
    }

    [Fact]
    public void Constructor_NullAction_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new Disposable(null!));
    }
}