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

    public LimitedSizeQueue(int limit)
    {
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