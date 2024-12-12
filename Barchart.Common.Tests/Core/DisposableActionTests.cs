#region Using Statements

using Barchart.Common.Core;

#endregion

namespace Barchart.Common.Tests.Core;

public class DisposableActionTests
{
    #region Fields
    
    private readonly ITestOutputHelper _testOutputHelper;
    
    #endregion

    #region Constructor(s)
    
    public DisposableActionTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    #endregion

    #region Test Methods (Constructor)

    [Fact]
    public void Constructor_NullAction_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new DisposableAction(null!));
    }
    
    #endregion
    
    #region Test Methods (Dispose)
    
    [Fact]
    public void Dispose_ExecutesAction_SetsFlag()
    {
        bool actionExecuted = false;
        Action action = () => actionExecuted = true;
        DisposableAction disposableAction = new(action);

        disposableAction.Dispose();

        Assert.True(actionExecuted);
    }
    
    #endregion
}