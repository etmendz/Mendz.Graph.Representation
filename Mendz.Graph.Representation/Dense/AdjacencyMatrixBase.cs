using Mendz.Matrix;
using System;

namespace Mendz.Graph.Representation.Dense
{
    /// <summary>
    /// Represents the base class for adjacency matrices. 
    /// </summary>
    /// <typeparam name="T">The type of data stored in the matrix.</typeparam>
    public abstract class AdjacencyMatrixBase<T> : DenseGraphMatrixBase<T>
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
        /// The value returned can be based on
        /// a constant/caculated value, the edge's index and/or the edge itself.
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

        /// <summary>
        /// Initializes the matrix.
        /// </summary>
        public override void Initialize() => Matrix = Matrix<T>.Create(Size, NonAdjacent, Diagonal);

        /// <summary>
        /// Fills or refreshes the matrix.
        /// </summary>
        /// <returns>The filled matrix, which is also available via property Matrix.</returns>
        public override T[,] Fill()
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
                    Adjacent(z, edge), edge.Directed);
            }
            return Matrix;
        }

        protected virtual void SetEntries(T[,] matrix, int x, int y, T value, bool directed)
        {
            matrix[x, y] = value;
            if (x != y)
            {
                if (!directed)
                {
                    matrix[y, x] = value;
                }
            }
        }
    }
}
