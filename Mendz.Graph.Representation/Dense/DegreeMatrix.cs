using Mendz.Matrix;
using System;

namespace Mendz.Graph.Representation.Dense
{
    /// <summary>
    /// Implements a degree matrix.
    /// </summary>
    public class DegreeMatrix : DenseGraphMatrixBase<int>
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
                    edge.Directed);
            }
            return Matrix;
        }

        protected virtual void SetEntries(int[,] matrix, int x, int y, bool directed)
        {
            matrix[x, x] += 1;
            matrix[y, y] += 1;
        }
    }
}
