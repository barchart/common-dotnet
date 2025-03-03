#region Using Statements

using Barchart.Common.Schedulers.Exceptions;

#endregion

namespace Barchart.Common.Schedulers;

/// <summary>
///     Contains methods for scheduling actions.
/// </summary>
public static class Scheduler
{
    #region Methods
    
    /// <summary>
    ///     Schedules an action with exponential backoff.
    /// </summary>
    /// <param name="action">
    ///     A function that represents the action to be scheduled.
    /// </param>
    /// <param name="initialDelay">
    ///     The initial delay in milliseconds.
    /// </param>
    /// <param name="actionDescription">
    ///     A description of the action.
    /// </param>
    /// <param name="maxAttempts">
    ///     A value that represents the maximum number of attempts.
    /// </param>
    /// <param name="failureCallback">
    ///     A callback that is called when the action fails.
    /// </param>
    /// <param name="failureValue">
    ///     A value that represents the failure.
    /// </param>
    /// <param name="maxDelay">
    ///     A value that represents the maximum delay in milliseconds.
    /// </param>
    /// <exception cref="MaximumAttemptsException">
    ///     Thrown when the maximum number of attempts is reached.
    /// </exception>
    public static async Task BackoffAsync(Func<Task> action, int initialDelay, string actionDescription, int maxAttempts, Action<int>? failureCallback, object? failureValue, int maxDelay)
    {
        int attempts = 0;
        int delay = initialDelay;

        while (true)
        {
            try
            {
                await action();
                break;
            }
            catch (Exception)
            {
                attempts++;
                failureCallback?.Invoke(attempts);

                if (maxAttempts > 0 && attempts >= maxAttempts)
                {
                    throw new MaximumAttemptsException($"Maximum attempts reached for {actionDescription}.");
                }

                await Task.Delay(delay);
                delay = Math.Min(delay * 2, maxDelay);
            }
        }
    }
    
    #endregion
}