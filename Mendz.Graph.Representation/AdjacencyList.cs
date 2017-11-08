using System.Collections.Concurrent;
using System.Linq;

namespace Mendz.Graph.Representation
{
    /// <summary>
    /// Implements an adjacency list.
    /// </summary>
    /// <remarks>
    /// <para>
    /// To get the neighborhood of a vertex: 
    /// adjacencyList.List[vertexID].Keys, where each key is a vertex ID.
    /// Given a vertex ID, you can get the actual vertex instance using graph.Vertices[id].
    /// </para>
    /// <para>
    /// To get the "incidence list" of a vertex:
    /// adjacencyList.List[vertexID].Values, where each result is an edge.
    /// </para>
    /// </remarks>
    public class AdjacencyList : GraphListBase<ConcurrentDictionary<int, ConcurrentDictionary<int, Edge>>>
    {
        /// <summary>
        /// Constructor to create an adjacency list.
        /// </summary>
        /// <param name="graph">The graph.</param>
        public AdjacencyList(Graph graph)
            : base(graph)
        {
        }

        public override void Initialize()
        {
            List = new ConcurrentDictionary<int, ConcurrentDictionary<int, Edge>>();
            Graph.Vertices
                .AsParallel()
                .ForAll((vertex) => List.TryAdd(vertex.Key, new ConcurrentDictionary<int, Edge>()));
        }

        /// <summary>
        /// Fills or refreshes the list.
        /// The data structure can be read as: "Given a vertex, it is adjacent to v as incident to edge e."
        /// </summary>
        /// <returns>The filled list, which is also available via property List.</returns>
        /// <remarks>Use to refresh the list.</remarks>
        public override ConcurrentDictionary<int, ConcurrentDictionary<int, Edge>> Fill()
        {
            Initialize();
            Graph.Edges
                .AsParallel()
                .ForAll((edge) => AdjacencyList.SetEntries(List, edge.Value));
            return List;
        }

        private static void SetEntries(ConcurrentDictionary<int, ConcurrentDictionary<int, Edge>> list, Edge edge)
        {
            int tailID = edge.Tail.ID;
            int headID = edge.Head.ID;
            list[tailID].TryAdd(headID, edge);
            if (!edge.Directed)
            {
                list[headID].TryAdd(tailID, edge);
            }
        }
    }
}
