using Mendz.Matrix;
using System.Collections.Concurrent;

/// <summary>
/// Represents the base class for sparse matrices.
/// </summary>
namespace Mendz.Graph.Representation
{
    public abstract class SparseGraphMatrixBase<T> : GraphMatrixBase<CoordinatesKeyedSparseMatrix<T>>
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

        protected SparseGraphMatrixBase(Graph graph, (int rows, int columns) size)
            : base(graph, size)
        {
        }

        /// <summary>
        /// Initializes the matrix.
        /// </summary>
        public override void Initialize() => Matrix = new CoordinatesKeyedSparseMatrix<T>(Size);
    }
}
