namespace Mendz.Graph.Representation
{
    /// <summary>
    /// Represents the base class for dense matrices.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DenseGraphMatrixBase<T> : GraphMatrixBase<T[,]>
    {
        /// <summary>
        /// Gets the value at Matrix[row, column].
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <returns>The value at Matrix[row, column].</returns>
        public T this[int row, int column]
        {
            get => Matrix[row, column];
        }

        protected DenseGraphMatrixBase(Graph graph, (int rows, int columns) size) 
            : base(graph, size)
        {
        }
    }
}
