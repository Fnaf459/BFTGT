using System;
using System.Collections.Generic;

class Graph
{
    private int[,] adjacencyMatrix;
    private int vertices;

    public Graph(int vertexCount)
    {
        vertices = vertexCount;
        adjacencyMatrix = new int[vertices, vertices];
    }

    public void AddEdge(int source, int destination)
    {
        adjacencyMatrix[source, destination] = 1;
        adjacencyMatrix[destination, source] = 1;
    }

    public void BFS(int start)
    {
        bool[] visited = new bool[vertices];
        Queue<int> queue = new Queue<int>();

        visited[start] = true;
        queue.Enqueue(start);

        Console.WriteLine("Обход в ширину:");

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            Console.Write(current + " ");

            for (int i = 0; i < vertices; i++)
            {
                if (adjacencyMatrix[current, i] == 1 && !visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }

        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        Graph graph = new Graph(7);

        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(1, 4);
        graph.AddEdge(2, 5);
        graph.AddEdge(2, 6);

        graph.BFS(0);
    }
}
