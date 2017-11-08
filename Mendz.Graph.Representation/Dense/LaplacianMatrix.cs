using System;

namespace Mendz.Graph.Representation.Dense
{
    /// <summary>
    /// Implements a Laplacian matrix of a simple graph.
    /// </summary>
    public class LaplacianMatrix : AdjacencyMatrixBase<int>
    {
        /// <summary>
        /// Constructor to create a Laplacian matrix of a simple graph.
        /// </summary>
        /// <param name="graph">The simple graph.</param>
        public LaplacianMatrix(Graph graph)
            : base(graph, (z, edge) => -1)
        {
        }

        protected override void SetEntries(int[,] matrix, int x, int y, int value, bool directed)
        {
            if (x == y)
            {
                throw new InvalidOperationException("Loops are not supported.");
            }
            if (directed)
            {
                throw new InvalidOperationException("Directed edges are not supported.");
            }
            matrix[x, x] += 1;
            matrix[y, y] += 1;
            matrix[x, y] = value;
            matrix[y, x] = value;
        }
    }
}
