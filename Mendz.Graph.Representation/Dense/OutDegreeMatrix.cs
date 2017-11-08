using System;

namespace Mendz.Graph.Representation.Dense
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

        protected override void SetEntries(int[,] matrix, int x, int y, bool directed)
        {
            if (!directed)
            {
                throw new InvalidOperationException("Undirected edges are not supported.");
            }
            matrix[x, x] += 1;
        }
    }
}
