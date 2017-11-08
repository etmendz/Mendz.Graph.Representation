using Mendz.Matrix;
using System;

namespace Mendz.Graph.Representation.Dense
{
    /// <summary>
    /// Implements an incidence matrix.
    /// </summary>
    public class IncidenceMatrix : DenseGraphMatrixBase<int>
    {
        /// <summary>
        /// Indicates if the undirected graph is oriented or unoriented.
        /// </summary>
        public bool Oriented { get; set; }

        /// <summary>
        /// Constructor to create an incidence matrix.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public IncidenceMatrix(Graph graph)
            : base(graph, (graph.Order, graph.Size))
        {
        }

        /// <summary>
        /// Initializes the matrix.
        /// </summary>
        public override void Initialize() => Matrix = Matrix<int>.Create(Size);

        /// <summary>
        /// Fills or refreshes the matrix.
        /// </summary>
        /// <returns>The filled matrix, which is also available via property Matrix.</returns>
        public override int[,] Fill()
        {
            Initialize();
            var indexedVertices = Graph.IndexVertices();
            var indexedEdges = Graph.IndexEdges();
            for (int z = 0; z < indexedEdges.Length; z++)
            {
                Edge edge = indexedEdges[z];
                SetEntries(Matrix,
                    Array.BinarySearch<Vertex>(indexedVertices, edge.Tail),
                    Array.BinarySearch<Vertex>(indexedVertices, edge.Head),
                    z, edge.Directed, Oriented);
            }
            return Matrix;
        }

        private void SetEntries(int[,] matrix, int x, int y, int z, bool directed, bool oriented)
        {
            if (x == y)
            {
                matrix[x, z] = (directed ? 0 : (oriented ? 0 : 2));
            }
            else
            {
                matrix[x, z] = (directed ? -1 : (oriented ? -1 : 1));
                matrix[y, z] = 1;
            }
        }
    }
}
