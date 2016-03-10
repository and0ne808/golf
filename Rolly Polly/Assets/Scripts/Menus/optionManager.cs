using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class optionManager : MonoBehaviour {

    static public string selected;
    public float deadZone;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        selected = "again";
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Selected");

        if(Input.GetAxis("Horizontal") > deadZone && selected != "options")
        {
            audio.Play();
            selected = "options";
        }
        else if(Input.GetAxis("Horizontal") < -deadZone && selected != "credits")
        {
            audio.Play();
            selected = "credits";
        }
        else if (Input.GetAxis("Vertical") > deadZone && selected != "play")
        {
            audio.Play();
            selected = "play";
        }
        else if (Input.GetAxis("Vertical") < -deadZone && selected != "quit")
        {
            audio.Play();
            selected = "quit";
        }

        if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))
        {
            if(selected == "play")
            {
                audio.Play();
                SceneManager.LoadScene("MainHub");
            }
            else if(selected == "quit")
            {
                Application.Quit();
            }
            else if (selected == "credits")
            {
                Application.Quit();
            }
            else if (selected == "options")
            {
                PlayerPrefs.DeleteAll();
                Debug.Log("Player Prefs Deleted");
            }
        }
	}
}
