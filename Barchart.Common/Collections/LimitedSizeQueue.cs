#region Using Statements

using System.Collections;
using Barchart.Common.Collections.Exceptions;

#endregion

namespace Barchart.Common.Collections;

/// <summary>
///     Represents a queue with a limited size.
/// </summary>
/// <typeparam name="TElement">
///     The type of elements stored in the queue.
/// </typeparam>
public class LimitedSizeQueue<TElement> : IEnumerable<TElement>
{
    #region Fields

    private readonly Queue<TElement> _queue = new();
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

    #region Properties

    /// <summary>
    ///     Gets the number of elements contained in the queue.
    /// </summary>
    public int Count => _queue.Count;

    #endregion

    #region Methods

    /// <summary>
    ///     Adds an item to the end of the queue.
    ///     If adding the item exceeds the limit, it removes items from the front of the queue until the size is within the limit.
    /// </summary>
    /// <param name="item">
    ///     The item to add to the queue.
    /// </param>
    public void Enqueue(TElement item)
    {
        _queue.Enqueue(item);

        if (_queue.Count > _limit)
        {
            _queue.Dequeue();
        }
    }

    /// <summary>
    ///     Removes and returns the element at the beginning of the queue.
    /// </summary>
    /// <returns>
    ///     The element removed from the beginning of the queue.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the queue is empty.
    /// </exception>
    public TElement Dequeue()
    {
        return _queue.Dequeue();
    }

    /// <summary>
    ///     Returns the element at the beginning of the queue without removing it.
    /// </summary>
    /// <returns>
    ///     The element at the beginning of the queue.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    ///     Thrown when the queue is empty.
    /// </exception>
    public TElement Peek()
    {
        return _queue.Peek();
    }

    /// <summary>
    ///     Returns an enumerator that iterates through the queue.
    /// </summary>
    /// <returns>
    ///     An enumerator for the queue.
    /// </returns>
    public IEnumerator<TElement> GetEnumerator()
    {
        return _queue.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    
    #endregion
}
