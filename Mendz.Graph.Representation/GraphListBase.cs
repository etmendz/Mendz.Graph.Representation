using System.Collections;

namespace Mendz.Graph.Representation
{
    /// <summary>
    /// Represents the base class for graph lists.
    /// </summary>
    /// <typeparam name="L">The type of list/collection.</typeparam>
    public abstract class GraphListBase<L> : GraphRepresentationBase<L>, IGraphList<L>
        where L : IEnumerable
    {
        /// <summary>
        /// Gets the list.
        /// </summary>
        public L List { get; protected set; }

        protected GraphListBase(Graph graph)
            : base(graph)
        {
        }
    }
}
