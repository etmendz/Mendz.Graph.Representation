using Mendz.Matrix;
using System;

namespace Mendz.Graph.Representation.Sparse
{
    /// <summary>
    /// Implements an outdegree matrix.
    /// </summary>
    public class OutDegreeMatrix : DegreeMatrix
    {
        /// <summary>
        /// Constructor to create an outdegree matrix.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public OutDegreeMatrix(Graph graph)
            : base(graph)
        {
        }

        /// <summary>
        /// Fills or refreshes the matrix.
        /// </summary>
        /// <returns>The filled matrix, which is also available via property Matrix.</returns>
        public override CoordinatesKeyedSparseMatrix<int> Fill() =>
            Fill((matrix, x, y, directed) => SetEntries(matrix, x, y, directed));

        private static void SetEntries(CoordinatesKeyedSparseMatrix<int> matrix, int x, int y, bool directed)
        {
            if (!directed)
            {
                throw new InvalidOperationException("Undirected edges are not supported.");
            }
            matrix.AddOrUpdate((x, x), 1, (k, v) => v + 1);
        }
    }
}
