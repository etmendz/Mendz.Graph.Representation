using System.Collections;

namespace Mendz.Graph.Representation
{
    /// <summary>
    /// Represents the base class for graph matrices.
    /// </summary>
    /// <typeparam name="M">The type of the matrix.</typeparam>
    public abstract class GraphMatrixBase<M> : GraphRepresentationBase<M>, IGraphMatrix<M>
        where M : IEnumerable
    {
        /// <summary>
        /// Gets the matrix.
        /// </summary>
        public M Matrix { get; protected set; }

        /// <summary>
        /// Gets the size of the matrix.
        /// </summary>
        public (int rows, int columns) Size { get; protected set; }

        protected GraphMatrixBase(Graph graph, (int rows, int columns) size)
            : base(graph) => Size = size;
    }
}
