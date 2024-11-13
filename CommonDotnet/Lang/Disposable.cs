namespace CommonDotnet.Lang;

/// <summary>
///     Represents an action that will be executed when the object is disposed.
/// </summary>
public class Disposable : IDisposable
{
    #region Fields

    private readonly Action _action;

    #endregion

    #region Constructor(s)

    /// <summary>
    ///     Initializes a new instance of the <see cref="Disposable"/> class with the specified action.
    /// </summary>
    /// <param name="disposableAction">
    ///     The action to execute when the object is disposed.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the <paramref name="disposableAction"/> is null.
    /// </exception>
    public Disposable(Action disposableAction)
    {
        _action = disposableAction ?? throw new ArgumentNullException(nameof(disposableAction));
    }

    #endregion

    #region Methods
    
    /// <summary>
    ///     Executes the action specified during the initialization of the object.
    /// </summary>
    public void Dispose()
    {
        _action.Invoke();
        
        GC.SuppressFinalize(this);
    }
    
    #endregion
}