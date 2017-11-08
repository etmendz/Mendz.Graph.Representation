namespace Mendz.Graph.Representation
{
    /// <summary>
    /// Represents a graph list.
    /// </summary>
    /// <typeparam name="T">The type of the graph list.</typeparam>
    public interface IGraphList<T>
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        T List { get; }
    }
}
