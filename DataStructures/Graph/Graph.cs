namespace MyDataStructures;

public class Graph<T>  where T : IComparable<T>
{
    private Dictionary<T, List<(T, double)>> AdjacencyList;
    private bool IsDirected;
    private bool IsWeighted;

    public Graph(bool IsDirected = false, bool IsWeighted = false)
    {
        this.AdjacencyList = new Dictionary<T, List<(T, double)>>();
        this.IsDirected = IsDirected;
        this.IsWeighted = IsWeighted;
    }

    public void AddNode(T val, List<(T, double)> list)
    {
        if (AdjacencyList.ContainsKey(val))
        {
            throw new InvalidOperationException("Trying to insert duplicate node");
        }
        
        foreach (var value in list)
        {
            if (!AdjacencyList.ContainsKey(value.Item1))
            {
                throw new KeyNotFoundException("A node in the list does not exist");
            } 
        }

        AdjacencyList.Add(val, list);

        if (!IsDirected)
        {
            foreach (var value in list)
            {
                AdjacencyList[value.Item1].Add((val, value.Item2));
            }
        }
    }

    public void AddEdge(T node, (T, double) tuple)
    {
        if (AdjacencyList.ContainsKey(node))
        {
            if (AdjacencyList.ContainsKey(tuple.Item1))
            {
                AdjacencyList[node].Add(tuple);
            }
            else
            {
                throw new KeyNotFoundException("Neighbor node does not exist");
            }
        }
        else
        {
            throw new KeyNotFoundException("Node does not exist");
        }

        if (!IsDirected)
        {
            AdjacencyList[tuple.Item1].Add((node, tuple.Item2));
        }
    }

    public List<(T, double)> GetNeighbors(T node)
    {
        List<(T, double)> ret = new List<(T, double)>();
        
        foreach (var neighbor in AdjacencyList[node])
        {
            ret.Add(neighbor);
        }

        return ret;
    }

    public void DeleteNode(T node)
    {
        if (!AdjacencyList.ContainsKey(node))
        {
            throw new KeyNotFoundException("Node does not exist in the graph.");
        }

        AdjacencyList.Remove(node);
        

        foreach (var key in AdjacencyList.Keys)
        {
            AdjacencyList[key].RemoveAll(list => list.Item1.Equals(node)); 
        }
    }

    public (double, List<T>) Dijkstras(T startNode, T endNode)
    {
        if (!IsWeighted)
        {
            throw new InvalidOperationException("Graph is not weighted");
        }

        if (!AdjacencyList.ContainsKey(startNode) 
            || !AdjacencyList.ContainsKey(endNode))
        {
            throw new KeyNotFoundException("One of the nodes does not exist");
        }

        var distance = new Dictionary<T, double>();  // keep track of all min distances
        var previous = new Dictionary<T, T>();     // keep track of path
        var nodes = new SortedSet<(T, double)>
            (Comparer<(T, double)>.Create((x, y) =>
        {
            int result = x.Item2.CompareTo(y.Item2);
            if (result == 0)
                result = Comparer<T>.Default.Compare(x.Item1, y.Item1);
            return result;
        }));

        foreach (var node in AdjacencyList.Keys)
        {
            if (node.Equals(startNode))
                distance.Add(node, 0);
            else
                distance.Add(node, double.MaxValue);
        }  

        nodes.Add((startNode, distance[startNode]));
 
        while (nodes.Count > 0)
        {
            var currentNode = nodes.Min.Item1;
            nodes.Remove(nodes.Min);

            foreach (var (neighbor, weight) in AdjacencyList[currentNode])
            {
                double sum = weight + distance[currentNode];
                
                if (sum < distance[neighbor])
                {
                    nodes.Remove((neighbor, distance[neighbor]));
                    distance[neighbor] = sum;
                    previous[neighbor] = currentNode;
                    nodes.Add((neighbor, sum));
                }
            }
        }

        if (distance[endNode] == double.MaxValue)
        {
            // There is no path from startNode to endNode
            return (double.MaxValue, new List<T>());
        }

        var path = new List<T>();
        for (var at = endNode; !at.Equals(default(T)); at = previous[at])
        {
            path.Add(at);
        }
        path.Reverse();
        
        return (distance[endNode], path);
    }
}
