namespace Mendz.Graph.Representation
{
    /// <summary>
    /// Represents a graph matrix.
    /// </summary>
    /// <typeparam name="T">The type of the graph matrix.</typeparam>
    public interface IGraphMatrix<T>
    {
        /// <summary>
        /// Gets the matrix.
        /// </summary>
        T Matrix { get; }

        /// <summary>
        /// Gets the size of the matrix.
        /// </summary>
        (int rows, int columns) Size { get; }
    }
}
