using MemorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    void Start()
    {
        //First start of the game!
        if (!MemoryFunctions.pathExists("Player"))
        {
            LevelFunctions.Create(LevelFunctions.path);
            LevelFunctions.Load(LevelFunctions.path);
            LevelFunctions.CreateLevel(1, 4, new Color[] { Color.green, Color.red }, new int[] { 1, 3 });
            LevelFunctions.CreateLevel(2, 6, new Color[] { Color.green, Color.red }, new int[] { 2, 4, 5 });

            PlayerFunctions.Create(PlayerFunctions.path);
        }

        LevelFunctions.Load(LevelFunctions.path);
        PlayerFunctions.Load(PlayerFunctions.path);

        SceneManager.LoadScene("StartScene");

    }
}
