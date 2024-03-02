using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using MemorySystem;

public class LevelFunctions : DataFunctions<Dictionary<int,Level>>
{
    public static string path = "Level";


    public static Level getLevel(int ID)
    {
        return content[ID];
    }

    public static Level getNextLevel(Level level)
    {
        if(content[level.ID + 1] == null)
        {
            Debug.Log("No new Levels");
            return null;
        }

        return content[level.ID + 1];
    }

    public static void CreateLevel(int id,int vertexCount,Color[] sequence, int[] dyeSteps)
    {
        Debug.Log("LevelCollection: " + content);
        if(content.Keys.Contains(id))
        {
            Debug.Log("Level already exists");
            return;
        }

        Graph graph = new Graph(vertexCount);
        graph.ColorGraph(dyeSteps, sequence);
        Level level = new Level(id,graph,sequence,dyeSteps);
        content[id] = level;
        Save(path);
    }

    public static void RemoveLevel(int id)
    {
        if (!content.Keys.Contains(id))
        {
            Debug.Log("Level with ID does not exist");
            return;
        }

        content.Remove(id);
        Save(path);
        
    }

}
