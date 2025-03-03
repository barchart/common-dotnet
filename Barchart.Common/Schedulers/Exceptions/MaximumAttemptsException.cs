namespace Barchart.Common.Schedulers.Exceptions;

/// <summary>
///     Thrown when the maximum number of attempts is reached.
/// </summary>
public class MaximumAttemptsException : Exception
{
    #region Constructor(s)

    /// <summary>
    ///     Initializes a new instance of the <see cref="MaximumAttemptsException"/> class.
    /// </summary>
    /// <param name="actionDescription">
    ///     The description of the action.
    /// </param>
    public MaximumAttemptsException(string actionDescription) : base($"Maximum attempts reached for {actionDescription}.")
    {
        
    }

    #endregion
}