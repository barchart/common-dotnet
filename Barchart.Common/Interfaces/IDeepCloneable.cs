namespace Barchart.Common.Interfaces;

/// <summary>
///     Provides a mechanism for deep cloning an object of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">
///     The type of the object to clone.
/// </typeparam>
public interface IDeepCloneable<T>
{
    #region Methods
    
    /// <summary>
    ///     Performs a deep clone of the object of type <typeparamref name="T"/>.
    /// </summary>
    /// <returns>
    ///     A deep clone of the object.
    /// </returns>
    T DeepClone();
    
    #endregion
}