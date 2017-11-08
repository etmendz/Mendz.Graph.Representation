using System.Collections;

namespace Mendz.Graph.Representation
{
    /// <summary>
    /// Represents the base class for graph representations.
    /// </summary>
    /// <typeparam name="T">The type of representation.</typeparam>
    public abstract class GraphRepresentationBase<T>
        where T : IEnumerable
    {
        /// <summary>
        /// Gets the graph.
        /// </summary>
        public Graph Graph { get; protected set; }

        /// <summary>
        /// When implemented by a derived class, creates a graph representation.
        /// </summary>
        /// <param name="graph">The graph instance.</param>
        protected GraphRepresentationBase(Graph graph) => Graph = graph;

        /// <summary>
        /// Initializes the representation.
        /// </summary>
        public abstract void Initialize();

        /// <summary>
        /// Fills or refreshes the representation.
        /// </summary>
        public abstract T Fill();
    }
}
