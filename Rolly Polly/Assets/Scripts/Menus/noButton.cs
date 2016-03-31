using UnityEngine;
using System.Collections;

public class noButton : MonoBehaviour {

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
        if (eraseDataManager.selected != "no")
        {
            eraseDataManager.selected = "no";
            audio.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (eraseDataManager.selected == "no")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = startcolor;
        }

	}
}
