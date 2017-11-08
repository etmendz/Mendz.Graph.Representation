namespace Mendz.Graph.Representation.Sparse
{
    /// <summary>
    /// Implements an adjacency matrix where the elements are the weights of the edges/arcs.
    /// </summary>
    public class WeightedAdjacencyMatrix : AdjacencyMatrixBase<double>
    {
        /// <summary>
        /// Constructor to create a weighted adjacency matrix.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public WeightedAdjacencyMatrix(Graph graph)
            : base(graph, (z, edge) => edge.Weight)
        {
        }
    }
}
