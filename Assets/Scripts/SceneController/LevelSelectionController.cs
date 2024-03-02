using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MemorySystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionController : MonoBehaviour
{
    public Transform UnitParent;
    public Button BackButton;
    // Start is called before the first frame update


    public void Start()
    {
        Fill();
    }

    void Fill()
    {
        foreach(var entry in LevelFunctions.content)
        {
            GameObject UnitGO = ResourceFunctions.LoadPrefab("LevelSelectionUIUnit");
            UnitGO.transform.SetParent(UnitParent);
            UnitGO.transform.localScale = Vector3.one;
            UnitGO.GetComponent<LevelSelectionUIUnit>().Fill(entry.Value, "Level " + entry.Key.ToString());
        }

        BackButton.onClick.AddListener(delegate { SceneManager.LoadScene("StartScene"); });
    }


    public void StartLevel(Level level)
    {
        PlayerFunctions.SetLevel(level.ID);
        SceneManager.LoadScene("Game");
    }
}
