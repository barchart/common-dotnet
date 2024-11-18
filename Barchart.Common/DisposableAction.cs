namespace Barchart.Common;

public class DisposableAction(Action disposeAction) : Disposable
{
    #region Fields
    
    private Action? _disposeAction = disposeAction ?? throw new ArgumentNullException(nameof(disposeAction));
    
    #endregion


    #region Methods

    protected override void OnDispose()
    {
        _disposeAction?.Invoke();
        _disposeAction = null;
    }
    
    #endregion
}
