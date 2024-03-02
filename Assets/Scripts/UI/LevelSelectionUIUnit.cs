using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;







public class LevelSelectionUIUnit : MonoBehaviour
{
    public Level level;
    public Text Titel;
    public Button button;
    // Start is called before the first frame update
    public void Fill(Level level, string Titel)
    {
        this.level = level;
        this.Titel.text = Titel;
        button.onClick.AddListener(onClick);
    
    }

    void onClick()
    {
        GameObject.Find("LevelSelectionController").GetComponent<LevelSelectionController>().StartLevel(level);
    }


}
