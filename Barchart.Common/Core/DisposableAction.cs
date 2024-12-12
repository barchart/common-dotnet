namespace Barchart.Common.Core;

/// <summary>
///     An object that has an end-of-life process with an action to execute when disposed.
/// </summary>
public class DisposableAction : Disposable
{
    #region Fields
    
    private readonly Action _disposeAction;
    
    #endregion

    #region Constructor(s)

    public DisposableAction(Action disposeAction)
    {
        ArgumentNullException.ThrowIfNull(disposeAction, nameof(disposeAction));
        
        _disposeAction = disposeAction;
    }

    #endregion

    #region Methods

    protected override void OnDispose()
    {
        _disposeAction.Invoke();
    }
    
    #endregion
}
