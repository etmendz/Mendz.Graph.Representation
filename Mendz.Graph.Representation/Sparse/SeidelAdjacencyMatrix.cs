using Mendz.Matrix;
using System;

namespace Mendz.Graph.Representation.Sparse
{
    /// <summary>
    /// Implements a Seidel adjacency matrix of a simple graph.
    /// </summary>
    public class SeidelAdjacencyMatrix : AdjacencyMatrixBase<int>
    {
        /// <summary>
        /// Constructor to create a Seidel adjacency matrix of a simple graph.
        /// </summary>
        /// <param name="graph">The simple graph.</param>
        public SeidelAdjacencyMatrix(Graph graph) 
            : base(graph, (z, edge) => -1, 1)
        {
        }

        /// <summary>
        /// Fills or refreshes the matrix.
        /// </summary>
        /// <returns>The filled matrix, which is also available via property Matrix.</returns>
        public override CoordinatesKeyedSparseMatrix<int> Fill() =>
            Fill((matrix, x, y, value, directed) => SetEntries(matrix, x, y, value, directed));

        private static void SetEntries(CoordinatesKeyedSparseMatrix<int> matrix, int x, int y, int value, bool directed)
        {
            if (x == y)
            {
                throw new InvalidOperationException("Loops are not supported.");
            }
            if (directed)
            {
                throw new InvalidOperationException("Directed edges are not supported.");
            }
            matrix.TryAdd((x, y), value);
            matrix.TryAdd((y, x), value);
        }
    }
}
