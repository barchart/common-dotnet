#region Using Statements

using Barchart.Common.Collections;
using Barchart.Common.Collections.Exceptions;

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

    #region Test Methods (Constructor)

    [Fact]
    public void Constructor_ZeroLimit_ThrowsInvalidQueueLimitException()
    {
        Assert.Throws<InvalidQueueLimitException>(() => new LimitedSizeQueue<int>(0));
    }

    #endregion

    #region Test Methods (Enqueue)

    [Fact]
    public void Enqueue_ItemAddedToQueue_IncreasesCount()
    {
        LimitedSizeQueue<int> queue = new(3);

        queue.Enqueue(1);

        Assert.Equal(1, queue.Count);
    }

    [Fact]
    public void Enqueue_LimitExceeded_OldestItemRemoved()
    {
        LimitedSizeQueue<int> queue = new(3);
        
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        queue.Enqueue(4);

        Assert.Equal(2, queue.Peek());
    }

    [Fact]
    public void Enqueue_LimitExceeded_CountRemainsAtLimit()
    {
        LimitedSizeQueue<int> queue = new(3);
       
        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);

        queue.Enqueue(4);

        Assert.Equal(3, queue.Count);
    }

    #endregion

    #region Test Methods (Dequeue)

    [Fact]
    public void Dequeue_QueueContainsItems_ReturnsOldestItem()
    {
        LimitedSizeQueue<int> queue = new(3);
        
        queue.Enqueue(1);
        queue.Enqueue(2);

        int item = queue.Dequeue();

        Assert.Equal(1, item);
    }

    [Fact]
    public void Dequeue_EmptyQueue_ThrowsInvalidOperationException()
    {
        LimitedSizeQueue<int> queue = new(3);

        Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
    }

    #endregion

    #region Test Methods (Peek)

    [Fact]
    public void Peek_QueueContainsItems_ReturnsOldestItem()
    {
        LimitedSizeQueue<int> queue = new(3);
       
        queue.Enqueue(1);
        queue.Enqueue(2);

        int item = queue.Peek();

        Assert.Equal(1, item);
    }

    [Fact]
    public void Peek_EmptyQueue_ThrowsInvalidOperationException()
    {
        LimitedSizeQueue<int> queue = new(3);

        Assert.Throws<InvalidOperationException>(() => queue.Peek());
    }

    #endregion
}
