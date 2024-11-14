#region Using Statements

using Barchart.Common.Collections;

#endregion

namespace Barchart.Common.Tests.Collections;

public class LimitedSizeQueueTests
{
    #region Fields
    
    private readonly ITestOutputHelper _testOutputHelper;
    
    #endregion

    #region Constructor(s)
    
    public LimitedSizeQueueTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }
    
    #endregion
    
    #region Test Methods (Enqueue)
        
    [Fact]
    public void Enqueue_ItemAddedToQueue_QueueContainsItem()
    {
        LimitedSizeQueue<int> queue = new(3);

        queue.Enqueue(1);

        Assert.Single(queue);
        Assert.Equal(1, queue.Peek());
    }

    [Fact]
    public void Enqueue_LimitExceeded_OldestItemRemoved()
    {
        LimitedSizeQueue<int> queue = new(3);
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        queue.Enqueue(4);

        Assert.Equal(3, queue.Count);
        Assert.Equal(2, queue.Peek());
    }

    [Fact]
    public void Enqueue_LimitNotExceeded_ItemsRemainInQueue()
    {
        LimitedSizeQueue<int> queue = new(3);
        queue.Enqueue(1);
        queue.Enqueue(2);

        queue.Enqueue(3);

        Assert.Equal(3, queue.Count);
        Assert.Equal(1, queue.Peek());
    }

    #endregion
}