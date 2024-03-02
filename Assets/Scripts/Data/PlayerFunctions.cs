using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MemorySystem;
using System.IO;
using System;
public class PlayerFunctions : DataFunctions<PlayerData>
{
    public static string path = "Player"; 

    public static int GetCurrentLevel()
    {
        return content.CurrentLevel;
    }

    public static List<int> GetTakenActions()
    {
        return content.takenActions;
    }

    public static void SaveStep(int DyedVertex)
    {
        content.takenActions.Add(DyedVertex);
        Save(path);
    }

    public static void RemoveStep()
    {
        if(content.takenActions.Count > 0)
        {
            content.takenActions.RemoveAt(content.takenActions.Count - 1);
            Save(path);
        }
        
    }

    public static void SetLevel(int LevelID)
    {
        content.CurrentLevel = LevelID;
        content.takenActions = new List<int>();
        Save(path);
    }
}
