using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MemorySystem;
using Unity.VisualScripting;
using System.Linq;
using System.Linq.Expressions;

public class VisualGraph : MonoBehaviour
{

    public Transform VertexParent;
    public Transform EdgeParent;


    public Graph graph;
    
    public Dictionary<int, VisualVertex> vertices;
    
    public Dictionary<int, List<VisualEdge>> edges;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Fill(Graph graph)
    {
        this.graph = graph;

        ClearGraph();
        loadVertices();
        positionVertices();
        loadEdges();

    }

    void ClearGraph()
    {
        // Delete all children of VertexParent
        foreach (Transform child in VertexParent)
        {
            Destroy(child.gameObject);
        }

        // Delete all children of EdgeParent
        foreach (Transform child in EdgeParent)
        {
            Destroy(child.gameObject);
        }

        // Reinitialize dictionaries
        vertices = new Dictionary<int, VisualVertex>();
        edges = new Dictionary<int, List<VisualEdge>>();
    }

    void loadVertices()
    {
        //Create the Visual Representation of the Vertices
        vertices = new Dictionary<int, VisualVertex>();
        foreach (var entry in graph.GetVertices())
        {
            Vertex currentVertex = entry.Value;
            GameObject VisualVertexGO = ResourceFunctions.LoadPrefab("VisualVertex");
            VisualVertexGO.transform.SetParent(VertexParent);
            VisualVertexGO.transform.localScale = Vector3.one;
            VisualVertex visualVertex = VisualVertexGO.GetComponent<VisualVertex>();
            visualVertex.Fill(currentVertex);
            vertices[currentVertex.Id] = visualVertex;
        }
    }
    void loadEdges() 
    {
        //Create the viusal Representation of the Edges
        edges = new Dictionary<int, List<VisualEdge>>();

        Dictionary<int, List<int>> loadedEdges = new Dictionary<int, List<int>>();

        foreach (int key in graph.GetAdjacencyList().Keys)
        {
            loadedEdges[key] = new List<int>();
            edges[key] = new List<VisualEdge>();
        }

        foreach (var entry in graph.GetAdjacencyList())
        {

            int sourceID = entry.Key;
            List<int> targetIDs = entry.Value;

            foreach (int targetID in targetIDs)
            {
                if (!loadedEdges[targetID].Contains(sourceID))
                {
                    GameObject VisualEdgeGO = ResourceFunctions.LoadPrefab("VisualEdge");
                    VisualEdgeGO.transform.SetParent(EdgeParent);
                    VisualEdge visualEdge = VisualEdgeGO.GetComponent<VisualEdge>();
                    visualEdge.Fill(vertices[sourceID], vertices[targetID]);
                    edges[sourceID].Add(visualEdge);
                    edges[targetID].Add(visualEdge);

                    loadedEdges[sourceID].Add(targetID);
                    loadedEdges[targetID].Add(sourceID);

                }
            }
        }
    }

    void positionVertices()
    {
        float scaleFactor = 0.7f;
        RectTransform canvas = GetComponent<RectTransform>();
        // Größe des Canvas
        float canvasWidth = canvas.rect.width;
        float canvasHeight = canvas.rect.height;

        // Radius des Kreises (nehmen wir den halben Durchmesser des Canvas)
        float radius = Mathf.Min(canvasWidth, canvasHeight) / 2f;

        // Anzahl der Objekte
        int objectCount = vertices.Keys.Count;

        // Winkelabstand zwischen den Objekten im Kreis
        float angleStep = 360f / objectCount;

        // Aktueller Winkel
        float currentAngle = 0f;

        // Platzierung der GameObjects entlang des Kreises
        foreach (VisualVertex visualVertex in vertices.Values)
        {
            RectTransform visualVertexRT = visualVertex.gameObject.GetComponent<RectTransform>();

            // Berechnung der Position des Objekts entlang des Kreises in Polarkoordinaten
            float posX = radius * Mathf.Cos(Mathf.Deg2Rad * currentAngle) * scaleFactor;
            float posY = radius * Mathf.Sin(Mathf.Deg2Rad * currentAngle) * scaleFactor;

            // Setzen der Position relativ zum Canvas
            visualVertexRT.localPosition = new Vector3(posX, posY, 0f);

            // Inkrementieren des Winkels für das nächste Objekt
            currentAngle += angleStep;
        }
    }

    public void UpdateColors(Graph graph)
    {
        this.graph = graph;

        foreach(VisualVertex visualVertex in vertices.Values)
        {
            visualVertex.SetColor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}




