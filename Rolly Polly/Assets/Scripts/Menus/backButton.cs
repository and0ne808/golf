using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour {

    private Color startcolor;
    AudioSource audio;
    private string selected;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        startcolor = GetComponent<Renderer>().material.color;
        selected = "back";
    }

    void OnMouseEnter()
    {
        if (selected != "back")
        {
            selected = "back";
            audio.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
        if(selected == "back")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = startcolor;
        }

        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))
        {
                audio.Play();
                SceneManager.LoadScene("MainMenu");
        }

	}
}
