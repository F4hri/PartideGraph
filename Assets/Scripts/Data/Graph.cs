using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[JsonObject]
public class Graph
{
    [JsonProperty]
    private Dictionary<int, Vertex> vertices;
    [JsonProperty]
    private Dictionary<int, List<int>> adjacencyList;


    public Dictionary<int, Vertex> GetVertices()
    {
        return vertices;
    }

    public Dictionary<int, List<int>> GetAdjacencyList()
    {
        return adjacencyList;
    }





    public Graph()
    {
        vertices = new Dictionary<int, Vertex>();
        adjacencyList = new Dictionary<int, List<int>>();
    }


    public Graph(int vertexCount)
    {
        vertices = new Dictionary<int, Vertex>();
        adjacencyList = new Dictionary<int, List<int>>();

        // Add vertices
        for (int i = 0; i < vertexCount; i++)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            AddVertex(i, randomColor);
        }

        // Add random edges
        for (int i = 0; i < vertexCount; i++)
        {
            int numEdges = Random.Range(1, vertexCount); // Random number of edges for each vertex
            for (int j = 0; j < numEdges; j++)
            {
                int targetId = Random.Range(0, vertexCount);
                if (targetId != i && !adjacencyList[i].Contains(targetId))
                {
                    AddEdge(i, targetId);
                }
            }
        }
    }



    public void AddVertex(int id, Color color)
    {
        if (!vertices.ContainsKey(id))
        {
            vertices[id] = new Vertex(id, color);
            adjacencyList[id] = new List<int>();
        }
        else
        {
            Debug.LogWarning("Vertex with ID " + id + " already exists.");
        }
    }

    public void AddEdge(int sourceId, int targetId)
    {
        if (!vertices.ContainsKey(sourceId) || !vertices.ContainsKey(targetId))
        {
            Debug.LogWarning("One or both vertices do not exist.");
            return;
        }

        adjacencyList[sourceId].Add(targetId);
        adjacencyList[targetId].Add(sourceId);
    }

    public void SetVertexColor(int id, Color color)
    {
        if (vertices.ContainsKey(id))
        {
            vertices[id].Color = color;
        }
        else
        {
            Debug.LogWarning("Vertex with ID " + id + " does not exist.");
        }
    }

    public Color GetNextColor(Color color, Color[] sequence)
    {
        if (sequence == null || sequence.Length == 0)
        {
            Debug.LogError("Color sequence is null or empty.");
            return Color.white; // Return default color if sequence is not valid
        }

        int currentIndex = Array.IndexOf(sequence, color); // Find index of current color in sequence

        if (currentIndex == -1)
        {
            Debug.LogWarning("Current color not found in the sequence. Returning the first color.");
            return sequence[0]; // Return the first color if current color is not found
        }

        // Get the next color index, wrapping around to the beginning if at the end
        int nextIndex = (currentIndex + 1) % sequence.Length;

        return sequence[nextIndex];
    }

    public Color GetBeforeColor(Color color, Color[] sequence)
    {
        if (sequence == null || sequence.Length == 0)
        {
            Debug.LogError("Color sequence is null or empty.");
            return Color.white; // Return default color if sequence is not valid
        }

        int currentIndex = Array.IndexOf(sequence, color); // Find index of current color in sequence

        if (currentIndex == -1)
        {
            Debug.LogWarning("Current color not found in the sequence. Returning the last color.");
            return sequence[sequence.Length - 1]; // Return the last color if current color is not found
        }

        // Get the previous color index, wrapping around to the end if at the beginning
        int previousIndex = (currentIndex - 1 + sequence.Length) % sequence.Length;

        return sequence[previousIndex];
    }

    public void DyeVertex(int id, Color[] sequence) 
    {
        SetVertexColor(id, GetNextColor(vertices[id].Color, sequence));

        foreach (int neighborID in adjacencyList[id])
        {
            SetVertexColor(neighborID, GetNextColor(vertices[neighborID].Color, sequence));
        }
    }

    public void RevertDyeVertex(int id, Color[] sequence)
    {
        SetVertexColor(id, GetBeforeColor(vertices[id].Color, sequence));

        foreach (int neighborID in adjacencyList[id])
        {
            SetVertexColor(neighborID, GetBeforeColor(vertices[neighborID].Color, sequence));
        }
    }


    public void ColorGraph(int[] dyeSteps, Color[] sequence)
    {
        //set all Colors to the starting one. Assures that the problem is solvable
        foreach(int id in vertices.Keys)
        {
            SetVertexColor(id, sequence[0]);
        }

        foreach (int index in dyeSteps) 
        {
            DyeVertex(index, sequence);
        }
    }

    public bool isUniColor(Color[] sequence)
    {
        return !vertices.Values.Any(x => x.Color != sequence[0]);
    }

}
[JsonObject]
public class Vertex
{
    [JsonProperty]
    public int Id { get; private set; }
    [JsonProperty]
    public Color Color { get; set; }

    public Vertex(int id, Color color)
    {
        Id = id;
        Color = color;
    }

}