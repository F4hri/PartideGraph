using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Level CurrentLevel;

    public VisualGraph visualGraph;

    public Button StepBackButton;
    public Button ReloadButton;

    public WinWindowUI winWindow;

    // Start is called before the first frame update
    private void Start()
    {
        LoadLevel();
    }
    void LoadLevel()
    {

        StepBackButton.onClick.AddListener(RevertDyeAction);

        ReloadButton.onClick.AddListener(ReloadLevel);

        int currentLevel = PlayerFunctions.GetCurrentLevel();

        List<int> takenActions = PlayerFunctions.GetTakenActions();

        Level toLoad = LevelFunctions.getLevel(currentLevel);

        foreach (int action in takenActions)
        {
            toLoad.graph.DyeVertex(action, toLoad.sequence);
        }
        CurrentLevel = toLoad;
        visualGraph.Fill(CurrentLevel.graph);
        
    }


    public void DyeAction(int ID)
    {
        CurrentLevel.graph.DyeVertex(ID, CurrentLevel.sequence);
        visualGraph.UpdateColors(CurrentLevel.graph);
        PlayerFunctions.SaveStep(ID);
        if (CurrentLevel.graph.isUniColor(CurrentLevel.sequence))
        {
            winWindow.Activate();
        }

    }

    public void RevertDyeAction()
    {
        if(PlayerFunctions.GetTakenActions().Count > 0)
        {
            CurrentLevel.graph.RevertDyeVertex(PlayerFunctions.GetTakenActions()[PlayerFunctions.GetTakenActions().Count - 1], CurrentLevel.sequence);
            visualGraph.UpdateColors(CurrentLevel.graph);
            PlayerFunctions.RemoveStep();
        }
    }

    public void ReloadLevel()
    {
        PlayerFunctions.SetLevel(CurrentLevel.ID);
        SceneManager.LoadScene("Game");
    }

    public void NextLevel()
    {
        Debug.Log("Level Finished!");

        Level newLevel = LevelFunctions.getNextLevel(CurrentLevel);
        if (newLevel != null) 
        {
            PlayerFunctions.SetLevel(CurrentLevel.ID + 1);
            LoadLevel();
        }
        winWindow.gameObject.SetActive(false);
        

    }

    public void LevelSelection() 
    {
        SceneManager.LoadScene("LevelSelection");
        winWindow.gameObject.SetActive(false);
    }
}
