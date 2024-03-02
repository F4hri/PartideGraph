using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneController : MonoBehaviour
{
    public Button ContinueButton;
    public Button LevelSelectionButton;
    // Start is called before the first frame update
    void Start()
    {
        ContinueButton.onClick.AddListener(delegate { SceneManager.LoadScene("Game"); });
        LevelSelectionButton.onClick.AddListener(delegate { SceneManager.LoadScene("LevelSelection"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
