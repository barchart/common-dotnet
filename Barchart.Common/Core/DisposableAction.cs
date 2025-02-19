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

    /// <summary>
    ///     Initializes a new instance of the <see cref="DisposableAction"/> class.
    /// </summary>
    /// <param name="disposeAction">
    ///     The action to execute when the object is disposed.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the <paramref name="disposeAction"/> parameter is <see langword="null"/>.
    /// </exception>
    public DisposableAction(Action disposeAction)
    {
        ArgumentNullException.ThrowIfNull(disposeAction, nameof(disposeAction));
        
        _disposeAction = disposeAction;
    }

    #endregion

    #region Methods

    /// <inheritdoc />
    protected override void OnDispose()
    {
        _disposeAction.Invoke();
    }
    
    #endregion
}
