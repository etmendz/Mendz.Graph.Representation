using Mendz.Matrix;
using System;
using System.Collections.Generic;

namespace Mendz.Graph.Representation
{
    /// <summary>
    /// Represents a connection matrix.
    /// </summary>
    public sealed class ConnectionMatrix : GraphMatrixBase<HashSet<(int row, int column)>>
    {
        /// <summary>
        /// Gets the value at Matrix[row, column].
        /// </summary>
        /// <param name="row">The row index.</param>
        /// <param name="column">The column index.</param>
        /// <returns>The value at Matrix[row, column].</returns>
        public bool this[int row, int column]
        {
            get
            {
                MatrixCoordinates.CheckCoordinates(Size, row, column);
                return Matrix.Contains((row, column));
            }
        }

        /// <summary>
        /// Creates an instance of a connection matrix.
        /// </summary>
        /// <param name="graph"></param>
        public ConnectionMatrix(Graph graph)
            : base(graph, (graph.Order, graph.Order))
        {
        }

        /// <summary>
        /// Initializes the matrix.
        /// </summary>
        public override void Initialize() => Matrix = new HashSet<(int row, int column)>();

        /// <summary>
        /// Fills the matrix.
        /// </summary>
        /// <returns>The filled matrix, which is also available via property Matrix.</returns>
        public override HashSet<(int row, int column)> Fill()
        {
            Initialize();
            var indexedVertices = Graph.IndexVertices();
            var indexedEdges = Graph.IndexEdges();
            for (int z = 0; z < indexedEdges.Length; z++)
            {
                Edge edge = indexedEdges[z];
                SetEntries(
                    Array.BinarySearch<Vertex>(indexedVertices, edge.Tail),
                    Array.BinarySearch<Vertex>(indexedVertices, edge.Head),
                    edge.Directed);
            }
            return Matrix;
        }

        private void SetEntries(int x, int y, bool directed)
        {
            Matrix.Add((x, y));
            if (x != y)
            {
                if (!directed)
                {
                    Matrix.Add((y, x));
                }
            }
        }
    }
}
