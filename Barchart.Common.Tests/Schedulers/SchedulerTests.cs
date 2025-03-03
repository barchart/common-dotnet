#region Using Statements

using Barchart.Common.Schedulers;
using Barchart.Common.Schedulers.Exceptions;

#endregion

namespace Barchart.Common.Tests.Schedulers;

public class SchedulerTests
{
    #region Fields
    
    private readonly ITestOutputHelper _testOutputHelper;
    
    #endregion
    
    #region Constructor(s)
    
    public SchedulerTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    #endregion
    
    #region Test Methods (BackoffAsync)
    
    [Fact]
    public async Task BackoffAsync_SuccessfulExecution_NoRetries()
    {
        int initialDelay = 100;
        string actionDescription = "Test Action";
        int maxAttempts = 3;
        int maxDelay = 1000;
        bool actionExecuted = false;

        Func<Task> action = async () =>
        {
            actionExecuted = true;
            await Task.CompletedTask;
        };

        await Scheduler.BackoffAsync(action, initialDelay, actionDescription, maxAttempts, null, null, maxDelay);

        Assert.True(actionExecuted);
    }

    [Fact]
    public async Task BackoffAsync_FailureWithRetries_SuccessfulAfterRetries()
    {
        int initialDelay = 100;
        string actionDescription = "Test Action";
        int maxAttempts = 3;
        int maxDelay = 1000;
        int attemptCount = 0;

        Func<Task> action = async () =>
        {
            attemptCount++;
            if (attemptCount < 3)
            {
                throw new Exception("Test Exception");
            }
            await Task.CompletedTask;
        };

        await Scheduler.BackoffAsync(action, initialDelay, actionDescription, maxAttempts, null, null, maxDelay);

        Assert.Equal(3, attemptCount);
    }

    [Fact]
    public async Task BackoffAsync_MaxAttemptsReached_ThrowsMaximumAttemptsException()
    {
        int initialDelay = 100;
        string actionDescription = "Test Action";
        int maxAttempts = 3;
        int maxDelay = 1000;

        Func<Task> action = () => throw new Exception("Test Exception");

        await Assert.ThrowsAsync<MaximumAttemptsException>(() => Scheduler.BackoffAsync(action, initialDelay, actionDescription, maxAttempts, null, null, maxDelay));
    }

    [Fact]
    public async Task BackoffAsync_FailureCallback_InvokedOnFailure()
    {
        int initialDelay = 100;
        string actionDescription = "Test Action";
        int maxAttempts = 3;
        int maxDelay = 1000;
        int failureCallbackCount = 0;

        Func<Task> action = () => throw new Exception("Test Exception");

        Action<int> failureCallback = (attempts) =>
        {
            failureCallbackCount = attempts;
        };

        await Assert.ThrowsAsync<MaximumAttemptsException>(() => Scheduler.BackoffAsync(action, initialDelay, actionDescription, maxAttempts, failureCallback, null, maxDelay));

        Assert.Equal(maxAttempts, failureCallbackCount);
    }
    
    #endregion
}