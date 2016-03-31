using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class optionManager : MonoBehaviour {

    static public string selected;
    public float deadZone;
    private float optionTime;
    private bool timerActive;
    public float selectionDelay; //amount of time before you can select a different option
    AudioSource audio;

	// Use this for initialization
	void Start () {
        timerActive = false;
        optionTime = 0;
        selected = "none";
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        if(timerActive)
        {
            optionTime += Time.deltaTime;

            if(optionTime > selectionDelay)
            {
                optionTime = 0;
                timerActive = false;
            }
        }

        if(!timerActive && Input.GetAxis("Horizontal") > deadZone && selected != "data")
        {
            optionTime = 0;
            timerActive = true;
            audio.Play();
            selected = "data";
        }
        else if (!timerActive && Input.GetAxis("Horizontal") < -deadZone && selected != "credits")
        {
            optionTime = 0;
            timerActive = true;
            audio.Play();
            selected = "credits";
        }
        else if (!timerActive && Input.GetAxis("Vertical") > deadZone && selected != "play")
        {
            optionTime = 0;
            timerActive = true;
            audio.Play();
            selected = "play";
        }
        else if (!timerActive && Input.GetAxis("Vertical") < -deadZone && selected != "quit")
        {
            optionTime = 0;
            timerActive = true;
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
                audio.Play();
                SceneManager.LoadScene("CreditsScreen");
            }
            else if (selected == "data")
            {
                /*
                PlayerPrefs.DeleteAll();
                Debug.Log("Player Prefs Deleted");
                 */
                audio.Play();
                SceneManager.LoadScene("EraseData");
            }
        }
	}
}
