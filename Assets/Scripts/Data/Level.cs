using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level
{
    public int ID;
    public Graph graph;
    public Color[] sequence;
    public int[] DyeSteps;
    
    public Level(int id, Graph graph, Color[] sequence, int[] DyeSteps)
    {
        this.ID = id;
        this.graph = graph;
        this.sequence = sequence;
        this.DyeSteps = DyeSteps;
    }
}
