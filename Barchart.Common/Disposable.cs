namespace Barchart.Common;

/// <summary>
///     An object that has an end-of-life process.
/// </summary>
public class Disposable : IDisposable
{
    #region Properties

    /// <summary>
    ///     Returns true if the <see cref="Dispose"/> function has been invoked.
    /// </summary>
    public bool IsDisposed { get; private set; }

    #endregion

    #region Methods

    /// <summary>
    ///     Invokes end-of-life logic. Once this function has been
    ///     invoked, further interaction with the object is not
    ///     recommended.
    /// </summary>
    public void Dispose()
    {
        if (IsDisposed)
        {
            return;
        }

        IsDisposed = true;

        OnDispose();
        GC.SuppressFinalize(this);
    }

    /// <summary>
    ///     End-of-life logic to be implemented by derived classes.
    /// </summary>
    protected virtual void OnDispose()
    {
    }

    /// <summary>
    ///     Creates and returns a <see cref="Disposable"/> object with end-of-life logic
    ///     delegated to a function.
    /// </summary>
    /// <param name="disposeAction">
    ///     The action to execute when the object is disposed.
    /// </param>
    /// <returns>
    ///     A <see cref="Disposable"/> object.
    /// </returns>
    public static Disposable FromAction(Action disposeAction)
    {
        if (disposeAction == null)
        {
            throw new ArgumentNullException(nameof(disposeAction));
        }

        return new DisposableAction(disposeAction);
    }

    /// <summary>
    ///     Creates and returns a <see cref="Disposable"/> object whose end-of-life
    ///     logic does nothing.
    /// </summary>
    /// <returns>
    ///     A <see cref="Disposable"/> object.
    /// </returns>
    public static Disposable GetEmpty()
    {
        return FromAction(() => { });
    }
    
    #endregion
}