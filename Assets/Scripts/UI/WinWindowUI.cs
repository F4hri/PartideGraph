using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WinWindowUI : MonoBehaviour
{
    public GameObject Start1;
    public GameObject Start2;
    public GameObject Start3;

    public Button NextLevelButton;
    public Button LevelSelectionButton;

    public GameController gameController;

    public void Activate()
    {
        this.gameObject.SetActive(true);

        NextLevelButton.onClick.AddListener(delegate { gameController.NextLevel(); });
        LevelSelectionButton.onClick.AddListener(delegate { gameController.LevelSelection(); });

        Level level = gameController.CurrentLevel;

        //This numer is if you find the solution by "going back" the way the graph was colored. For every vertex you have to go the whole way threw the sequence to get back. Very likely not the minimum amount of steps but good enough
        int Reference = level.DyeSteps.Length * (level.sequence.Length - 1);

        int StepsNeeded = PlayerFunctions.GetTakenActions().Count;


        Start1.SetActive(false);
        Start2.SetActive(false);
        Start3.SetActive(false);

        if (StepsNeeded <= 4 * Reference)
        {
            Start1.SetActive(true);
        }
        if (StepsNeeded <= 3 * Reference)
        {
            Start2.SetActive(true);
        }
        if (StepsNeeded <= 2 * Reference)
        {
            Start3.SetActive(true);
        }
    }


}
