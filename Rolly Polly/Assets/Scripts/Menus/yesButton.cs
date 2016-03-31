using UnityEngine;
using System.Collections;

public class yesButton : MonoBehaviour {

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
        if (eraseDataManager.selected != "yes")
        {
            eraseDataManager.selected = "yes";
            audio.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (eraseDataManager.selected == "yes")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = startcolor;
        }

	}
}
