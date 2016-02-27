using UnityEngine;
using System.Collections;

public class againButton : MonoBehaviour {

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
        if (optionManager.selected != "again")
        {
            optionManager.selected = "again";
            audio.Play();
        }
    }





	
	// Update is called once per frame
	void Update () {
	
        if(optionManager.selected == "again")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = startcolor;
        }

	}
}
