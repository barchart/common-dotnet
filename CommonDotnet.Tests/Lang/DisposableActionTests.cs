#region Using Statements

using CommonDotnet.Lang;

#endregion

namespace CommonDotnet.Tests.Lang;

public class DisposableActionTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public DisposableActionTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    [Fact]
    public void Dispose_ExecutesAction()
    {
        bool actionExecuted = false;
        Action action = () => actionExecuted = true;
        DisposableAction disposableAction = new(action);

        disposableAction.Dispose();

        Assert.True(actionExecuted);
    }

    [Fact]
    public void Constructor_NullAction_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new DisposableAction(null!));
    }
}