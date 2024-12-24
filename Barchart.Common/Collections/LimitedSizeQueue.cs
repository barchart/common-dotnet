#region Using Statements

using Barchart.Common.Collections.Exceptions;

#endregion

namespace Barchart.Common.Collections;

/// <summary>
///     Represents a queue with a limited size.
/// </summary>
/// <typeparam name="TElement">
///     The type of elements stored in the queue.
/// </typeparam>
public class LimitedSizeQueue<TElement> : Queue<TElement>
{
    #region Fields

    private readonly int _limit;

    #endregion

    #region Constructor(s)

    /// <summary>
    ///     Initializes a new instance of the <see cref="LimitedSizeQueue{TElement}"/> class with the specified limit.
    /// </summary>
    /// <param name="limit">
    ///     The maximum number of elements that the queue can contain.
    /// </param>
    /// <exception cref="InvalidQueueLimitException">
    ///     Thrown when the <paramref name="limit"/> parameter is less than or equal to zero.
    /// </exception>
    public LimitedSizeQueue(int limit)
    {
        if (limit <= 0)
        {
            throw new InvalidQueueLimitException(limit);
        }
        
        _limit = limit;
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Adds an item to the end of the queue.
    ///     If adding the item exceeds the limit, it removes items from the front of the queue until the size is within the limit.
    /// </summary>
    /// <param name="item">
    ///     The item to add to the queue.
    /// </param>
    public new void Enqueue(TElement item)
    {
        base.Enqueue(item);
        
        while (Count > _limit)
        {
            Dequeue();
        }
    }
    
    #endregion
}