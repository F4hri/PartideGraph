using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int CurrentLevel;
    public List<int> takenActions;

    public PlayerData() 
    { 
        CurrentLevel = 1;
        takenActions = new List<int>();
    }

}
