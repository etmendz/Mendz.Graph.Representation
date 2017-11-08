using System;

namespace Mendz.Graph.Representation.Dense
{
    /// <summary>
    /// Implements an indegree matrix.
    /// </summary>
    public class InDegreeMatrix : DegreeMatrix
    {
        /// <summary>
        /// Constructor to create an indegree matrix.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public InDegreeMatrix(Graph graph)
            : base(graph)
        {
        }

        protected override void SetEntries(int[,] matrix, int x, int y, bool directed)
        {
            if (!directed)
            {
                throw new InvalidOperationException("Undirected edges are not supported.");
            }
            matrix[y, y] += 1;
        }
    }
}
