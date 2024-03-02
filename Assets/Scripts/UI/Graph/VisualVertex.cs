using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualVertex : MonoBehaviour
{
    public Vertex vertex;

    public Button button;

    public Image image;
    

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<SpriteRenderer>().sprite = sprite;
        //GetComponent<SpriteRenderer>().material = material;
        button.onClick.AddListener(onClick);
    }

    void onClick()
    {
        Debug.Log(vertex.Id);
        GameObject.Find("GameController").GetComponent<GameController>().DyeAction(vertex.Id);
    }

    public void SetColor()
    {

        image.color = vertex.Color;
    }

    public void Fill(Vertex vertex)
    {
        this.vertex = vertex;
        SetColor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
