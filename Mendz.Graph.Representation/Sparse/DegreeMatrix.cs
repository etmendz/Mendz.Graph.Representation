using Mendz.Matrix;
using System;
using System.Threading.Tasks;

namespace Mendz.Graph.Representation.Sparse
{
    /// <summary>
    /// Implements a degree matrix.
    /// </summary>
    public class DegreeMatrix : SparseGraphMatrixBase<int>
    {
        /// <summary>
        /// Constructor to create a degree matrix.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public DegreeMatrix(Graph graph)
            : base(graph, (graph.Order, graph.Order))
        {
        }

        /// <summary>
        /// Fills or refreshes the matrix.
        /// </summary>
        /// <returns>The filled matrix, which is also available via property Matrix.</returns>
        public override CoordinatesKeyedSparseMatrix<int> Fill() =>
            Fill((matrix, x, y, directed) => SetEntries(matrix, x, y, directed));

        protected CoordinatesKeyedSparseMatrix<int> Fill(Action<CoordinatesKeyedSparseMatrix<int>, int, int, bool> setEntries)
        {
            Initialize();
            var indexedVertices = Graph.IndexVertices();
            var indexedEdges = Graph.IndexEdges();
            Parallel.For(0, indexedEdges.Length, (z) =>
                {
                    Edge edge = indexedEdges[z];
                    setEntries(Matrix,
                        Array.BinarySearch<Vertex>(indexedVertices, edge.Tail),
                        Array.BinarySearch<Vertex>(indexedVertices, edge.Head),
                        edge.Directed);
                });
            return Matrix;
        }

        private static void SetEntries(CoordinatesKeyedSparseMatrix<int> matrix, int x, int y, bool directed)
        {
            matrix.AddOrUpdate((x, x), 1, (k, v) => v + 1);
            matrix.AddOrUpdate((y, y), 1, (k, v) => v + 1);
        }
    }
}
