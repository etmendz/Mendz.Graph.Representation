using Mendz.Matrix;
using System;
using System.Threading.Tasks;

namespace Mendz.Graph.Representation.Sparse
{
    /// <summary>
    /// Represents the base class for adjacency matrices. 
    /// </summary>
    /// <typeparam name="T">The type of data stored in the matrix.</typeparam>
    public abstract class AdjacencyMatrixBase<T> : SparseGraphMatrixBase<T>
    {
        /// <summary>
        /// Gets or sets the function to invoke when the vertices are adjacent.
        /// </summary>
        protected Func<int, Edge, T> Adjacent { get; set; }

        /// <summary>
        /// Gets or sets the default value of the elements.
        /// </summary>
        protected T NonAdjacent { get; set; }

        /// <summary>
        /// Gets or sets the default value of the diagonal.
        /// </summary>
        protected T Diagonal { get; set; }

        /// <summary>
        /// Constructor to create an adjacency matrix.
        /// </summary>
        /// <param name="graph">The graph.</param>
        /// <param name="adjacent">
        /// The function to invoke when the vertices are adjacent.
        /// The value returned can be based on a constant value, the edge's index and/or the edge itself.
        /// </param>
        /// <param name="nonadjacent">The default nonadjacent value.</param>
        /// <param name="diagonal">The default diagonal value.</param>
        protected AdjacencyMatrixBase(Graph graph, Func<int, Edge, T> adjacent, T nonadjacent = default, T diagonal = default)
            : base(graph, (graph.Order, graph.Order))
        {
            Adjacent = adjacent;
            NonAdjacent = nonadjacent;
            Diagonal = diagonal;
        }

        public override void Initialize() => Matrix = new CoordinatesKeyedSparseMatrix<T>(Size, NonAdjacent, Diagonal);

        /// <summary>
        /// Fills or refreshes the matrix.
        /// </summary>
        /// <returns>The filled matrix, which is also available via property Matrix.</returns>
        public override CoordinatesKeyedSparseMatrix<T> Fill() => 
            Fill((matrix, x, y, value, directed) => SetEntries(matrix, x, y, value, directed));

        protected CoordinatesKeyedSparseMatrix<T> Fill(Action<CoordinatesKeyedSparseMatrix<T>, int, int, T, bool> setEntries)
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
                    Adjacent(z, edge), edge.Directed);
            });
            return Matrix;
        }

        private static void SetEntries(CoordinatesKeyedSparseMatrix<T> matrix, int x, int y, T value, bool directed)
        {
            matrix.TryAdd((x, y), value);
            if (x != y)
            {
                if (!directed)
                {
                    matrix.TryAdd((y, x), value);
                }
            }
        }
    }
}
