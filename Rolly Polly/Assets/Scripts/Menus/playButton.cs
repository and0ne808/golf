using UnityEngine;
using System.Collections;

public class playButton : MonoBehaviour {

    private Color startcolor;
    AudioSource audio;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        startcolor = GetComponent<Renderer>().material.color;
    }

    void OnMouseEnter()
    {
        if (optionManager.selected != "play")
        {
            optionManager.selected = "play";
            audio.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
        if(optionManager.selected == "play")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = startcolor;
        }

	}
}
