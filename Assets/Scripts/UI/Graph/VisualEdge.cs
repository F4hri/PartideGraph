using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VisualEdge : MonoBehaviour
{
    public VisualVertex vertex1;
    public VisualVertex vertex2;
    public LineRenderer lineRenderer;
    public Material material;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Fill(VisualVertex vertex1, VisualVertex vertex2)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, vertex1.transform.position);
        lineRenderer.SetPosition(1, vertex2.transform.position);
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Equals(object obj)
    {
        // Überprüfen, ob das Objekt eine VisualEdge ist
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        VisualEdge otherEdge = (VisualEdge)obj;

        // Überprüfen, ob die Vertices die gleichen IDs haben
        return (vertex1.vertex.Id == otherEdge.vertex1.vertex.Id && vertex2.vertex.Id == otherEdge.vertex2.vertex.Id)
            || (vertex1.vertex.Id == otherEdge.vertex2.vertex.Id && vertex2.vertex.Id == otherEdge.vertex1.vertex.Id);
    }

    public override int GetHashCode()
    {
        // Eine einfache Methode zur Erstellung eines Hashcodes basierend auf den IDs der Vertices
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + vertex1.vertex.Id.GetHashCode();
            hash = hash * 23 + vertex2.vertex.Id.GetHashCode();
            return hash;
        }
    }


}
