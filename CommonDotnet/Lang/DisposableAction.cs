namespace CommonDotnet.Lang;

public class DisposableAction : Disposable
{
    #region Fields
    
    private Action _disposeAction;
    
    #endregion

    #region Constructor(s)

    public DisposableAction(Action disposeAction)
    {
        _disposeAction = disposeAction ?? throw new ArgumentNullException(nameof(disposeAction));
    }

    #endregion

    #region Methods

    protected override void OnDispose()
    {
        _disposeAction.Invoke();
        _disposeAction = null!;
    }
    
    #endregion
}
