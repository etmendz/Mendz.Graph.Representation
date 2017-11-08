using System;

namespace Mendz.Graph.Representation.Sparse
{
    /// <summary>
    /// Implements a generic adjacency matrix.
    /// </summary>
    public class GenericAdjacencyMatrix<T> : AdjacencyMatrixBase<T>
    {
        /// <summary>
        /// Constructor to create a generic adjacency matrix.
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="adjacent">
        /// The function to invoke when the vertices are adjacent.
        /// The value returned can be based on a constant value, the edge's index and/or the edge itself.
        /// </param>
        /// <param name="nonadjacent">The default nonadjacent value.</param>
        /// <param name="diagonal">The default diagonal value.</param>
        /// <example>
        /// var adjacencyMatrixOfIndexedEdges = new GenericAdjacencyMatrix<int>(graph, (z, edge) => z);
        /// var adjacencyMatrixOfEdges = new GenericAdjacencyMatrix<Edge>(graph, (z, edge) => edge);
        /// var connectionMatrix = new GenericAdjacencyMatrix<bool>(graph, (z, edge) => true);
        /// </example>
        public GenericAdjacencyMatrix(Graph graph, Func<int, Edge, T> adjacent, T nonadjacent = default, T diagonal = default)
            : base(graph, adjacent, nonadjacent, diagonal)
        {
        }
    }
}
