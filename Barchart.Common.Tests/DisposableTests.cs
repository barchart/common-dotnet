namespace Barchart.Common.Tests;

public class DisposableTests
{
    #region Fields
    
    private readonly ITestOutputHelper _testOutputHelper;
    
    #endregion

    #region Constructor(s)
    
    public DisposableTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    #endregion
    
    #region Test Methods (Dispose)
    
    [Fact]
    public void Dispose_SetsIsDisposed_ChecksFlag()
    {
        Disposable disposable = new();

        disposable.Dispose();

        Assert.True(disposable.IsDisposed);
    }

    [Fact]
    public void Dispose_CallsOnDispose_SetsFlag()
    {
        bool onDisposeCalled = false;
        TestDisposable disposable = new(() => onDisposeCalled = true);

        disposable.Dispose();

        Assert.True(onDisposeCalled);
    }

    #endregion

    #region Test Methods (FromAction)

    [Fact]
    public void FromAction_CreatesDisposableAction_ExecutesAction()
    {
        bool actionExecuted = false;
        Action action = () => actionExecuted = true;

        Disposable disposable = Disposable.FromAction(action);
        disposable.Dispose();

        Assert.True(actionExecuted);
    }

    #endregion

    #region Test Methods (GetEmpty)
    
    [Fact]
    public void GetEmpty_CreatesDisposableThatDoesNothing_ChecksFlag()
    {
        Disposable disposable = Disposable.GetEmpty();

        disposable.Dispose();

        Assert.True(disposable.IsDisposed);
    }
    
    #endregion

    #region Nested Types

    private class TestDisposable : Disposable
    {
        private readonly Action _onDispose;

        public TestDisposable(Action onDispose)
        {
            _onDispose = onDispose;
        }

        protected override void OnDispose()
        {
            _onDispose();
        }
    }
    
    #endregion
}