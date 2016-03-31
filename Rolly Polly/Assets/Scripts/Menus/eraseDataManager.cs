using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class eraseDataManager : MonoBehaviour {

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
        selected = "no";
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

        if(!timerActive && Input.GetAxis("Horizontal") > deadZone && selected != "yes")
        {
            optionTime = 0;
            timerActive = true;
            audio.Play();
            selected = "yes";
        }
        else if (!timerActive && Input.GetAxis("Horizontal") < -deadZone && selected != "no")
        {
            optionTime = 0;
            timerActive = true;
            audio.Play();
            selected = "no";
        }

        if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))
        {
            if(selected == "no")
            {
                audio.Play();
                SceneManager.LoadScene("MainMenu");
            }
            else if(selected == "yes")
            {
                audio.Play();
                PlayerPrefs.DeleteAll();             
                Debug.Log("Player Prefs Deleted");
                SceneManager.LoadScene("MainMenu");

            }
        }
	}
}
