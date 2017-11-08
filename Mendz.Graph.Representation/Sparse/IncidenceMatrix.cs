using Mendz.Matrix;
using System;
using System.Threading.Tasks;

namespace Mendz.Graph.Representation.Sparse
{
    /// <summary>
    /// Implements an incidence matrix.
    /// </summary>
    public class IncidenceMatrix : SparseGraphMatrixBase<int>
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
        /// Fills or refreshes the matrix.
        /// </summary>
        /// <returns>The filled matrix, which is also available via property Matrix.</returns>
        public override CoordinatesKeyedSparseMatrix<int> Fill()
        {
            Initialize();
            var indexedVertices = Graph.IndexVertices();
            var indexedEdges = Graph.IndexEdges();
            Parallel.For(0, indexedEdges.Length, (z) =>
                {
                    Edge edge = indexedEdges[z];
                    SetEntries(Matrix,
                        Array.BinarySearch<Vertex>(indexedVertices, edge.Tail),
                        Array.BinarySearch<Vertex>(indexedVertices, edge.Head),
                        z, edge.Directed, Oriented);
                });
            return Matrix;
        }

        private static void SetEntries(CoordinatesKeyedSparseMatrix<int> matrix, int x, int y, int z, bool directed, bool oriented)
        {
            if (x == y)
            {
                matrix.TryAdd((x, z), (directed ? 0 : (oriented ? 0 : 2)));
            }
            else
            {
                matrix.TryAdd((x, z), (directed ? -1 : (oriented ? -1 : 1)));
                matrix.TryAdd((y, z), 1);
            }
        }
    }
}
