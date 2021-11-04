using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Cluster1Graph : MonoBehaviour
{
    private int _V;

    LinkedList<int>[] _adj;

    public Cluster1Graph(int V)
    {
        _adj = new LinkedList<int>[V];
        for (int i = 0; i < _adj.Length; i++)
        {
            _adj[i] = new LinkedList<int>();
        }
        _V = V;
    }

    public void AddEdge(int v, int w)
    {
        _adj[v].AddLast(w);
        _adj[w].AddLast(v);
    }

    public void BFS(int s)
    {
        bool[] visited = new bool[_V];
        for (int i = 0; i < _V; i++)
            visited[i] = false;

        LinkedList<int> queue = new LinkedList<int>();

        visited[s] = true;
        queue.AddLast(s);

        while (queue.Any())
        {
            s = queue.First();
            print(s + " ");
            queue.RemoveFirst();
            LinkedList<int> list = _adj[s];

            foreach (var val in list)
            {
                if (!visited[val])
                {
                    visited[val] = true;
                    queue.AddLast(val);
                }
            }
        }
    }

    void Start()
    {
        Cluster1Graph g = new Cluster1Graph(4);

        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(1, 3);

        print("Following is Breadth First " +"Traversal(starting from " +"vertex 2)\n");
        g.BFS(0);
    }

}
