using UnityEngine;
using System.Collections;

public class quitButton : MonoBehaviour {

    private Color startcolor;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        startcolor = GetComponent<Renderer>().material.color;
        audio = GetComponent<AudioSource>();
    }

    void OnMouseEnter()
    {
        if (optionManager.selected != "quit")
        {
            optionManager.selected = "quit";
            audio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (optionManager.selected == "quit")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = startcolor;
        }

    }
}
