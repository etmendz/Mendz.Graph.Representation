# Mendz.Graph.Representation
Provides a library of classes and types to represent Graph Theory graphs as list and/or matrix. [Wiki](https://github.com/etmendz/Mendz.Graph.Representation/wiki)
## Namespaces
### Mendz.Graph.Representation
#### Contents
Name | Description
---- | -----------
GraphRepresentationBase | The base class of graph representation.
IGraphList | Defines a graph represented as a list.
GraphListBase | The base class of a graph represented as a list.
AdjacencyList | Represents an adjacency list.
IGraphMatrix | Defines a graph represented as a matrix.
GraphMatrixBase | The base class of a graph represented as a matrix.
DenseGraphMatrixBase | The base class of a graph represented as a dense matrix.
SparseGraphMatrixBase | The base class of a graph represented as a sparse matrix.
ConnectionMatrix | Represents a connection matrix.
#### AdjacencyList
The main problem that the adjacency list solves is how to find all the vertices adjacent to a vertex v -- by "adjacent" it means that the vertex v is one of the endpoints in an edge. The vertex v and its adjacent vertices are collectively called the neighborhood. Thus, an adjacent vertex is a neighbor of a vertex v.

To use:
```C#
using Mendz.Graph;
using Mendz.Graph.Representation;
...
Graph graph = new Graph();
...
// ToDo: initialize the graph...
...
AdjacencyList adjacencyList = new AdjacencyList(graph);
adjacencyList.Fill();
...
```
To find vertices with neighbors: 
```C#
foreach (var id in adjacencyList.List.Keys
    .Where((key) => adjacencyList.List[key].Count > 0))
{
    Console.WriteLine(id.ToString());
}
```
To find vertices with no neighbor:
```C#
foreach (var id in adjacencyList.List.Keys
    .Where((key) => adjacencyList.List[key].Count == 0))
{
    Console.WriteLine(id.ToString());
}
```
To get an "incidence list", which lists the edges incident to the vertex v -- by "incident" it means that the edge has the vertex v as one of the endpoints:
```C#
foreach (var edge in adjacencyList.List[vertexID].Values)
{
    Console.WriteLine(edge.Name);
}
```
DFS (depth-first search) with an adjacency list can look like the following:
```C#
HashSet<Edge> subgraph = new HashSet<Edge>();
traversed = new HashSet<int>();
Action<int> traverse = (id) =>
{
    if (!traversed.Contains(id))
    {
        traversed.Add(id);
        foreach (var item in adjacencyList.List[id])
        {
            subgraph.Add(item.Value);
            traverse(item.Key);
        }
    }
};
int vertexID = 1; // assign a vertex ID that exists in the graph
traverse(vertexID);
Console.WriteLine("digraph G" + vertexID.ToString() + " {");
foreach (var edge in subgraph)
{
    Console.WriteLine(" " + edge.Name + ";");
}
Console.WriteLine("}");
```
### Mendz.Graph.Representation.Dense
#### Contents
Name | Description
---- | -----------
AdjacencyMatrixBase | The base class of a graph represented as an adjacency matrix.
AdjacencyMatrix | Represents an adjacency matrix.
WeightedAdjacencyMatrix | Represents a weighted adjacency matrix.
SeidelAdjacencyMatrix | Represents a Seidel adjacency matrix.
GenericAdjacencyMatrix | Represents a generic adjacency matrix.
LaplacianMatrix | Represents a Laplacian matrix.
DegreeMatrix | Represents a degree matrix.
InDegreeMatrix | Represents an indegree matrix.
OutDegreeMatrix | Represents an outdegree matrix.
IncidenceMatrix | Represents an incidence matrix.
### Mendz.Graph.Representation.Sparse
#### Contents
Name | Description
---- | -----------
AdjacencyMatrixBase | The base class of a graph represented as an adjacency matrix.
AdjacencyMatrix | Represents an adjacency matrix.
WeightedAdjacencyMatrix | Represents a weighted adjacency matrix.
SeidelAdjacencyMatrix | Represents a Seidel adjacency matrix.
GenericAdjacencyMatrix | Represents a generic adjacency matrix.
LaplacianMatrix | Represents a Laplacian matrix.
DegreeMatrix | Represents a degree matrix.
InDegreeMatrix | Represents an indegree matrix.
OutDegreeMatrix | Represents an outdegree matrix.
IncidenceMatrix | Represents an incidence matrix.
## NuGet It...
[https://www.nuget.org/packages/Mendz.Graph.Representation/](https://www.nuget.org/packages/Mendz.Graph.Representation/)
