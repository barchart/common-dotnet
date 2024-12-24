namespace Barchart.Common.Interfaces;

/// <summary>
///     Defines a contract for implementing deep cloning functionality 
///     for objects of type <typeparamref name="T"/>.
///     <para>
///         The purpose of this interface is to ensure that classes 
///         implementing it provide a mechanism to create a deep copy of an object, 
///         meaning all referenced objects are also cloned, not just their references.
///     </para>
/// </summary>
/// <typeparam name="T">
///     The type of the object to clone.
/// </typeparam>
public interface IDeepCloneable<T>
{
    #region Methods
    
    /// <summary>
    ///     Performs a deep clone of the object of type <typeparamref name="T"/>.
    ///     <para>
    ///         A deep clone creates a new instance of the object, 
    ///         including recursively cloning all referenced objects 
    ///         to ensure complete separation from the original instance.
    ///     </para>
    /// </summary>
    /// <returns>
    ///     A deep clone of the object.
    /// </returns>
    T DeepClone();
    
    #endregion
}