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

        if(Input.GetAxis("Horizontal") > deadZone && selected != "quit")
        {
            audio.Play();
            selected = "quit";
        }
        else if(Input.GetAxis("Horizontal") < -deadZone && selected != "again")
        {
            audio.Play();
            selected = "again";
        }

        if(Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))
        {
            if(selected == "again")
            {
                audio.Play();
                SceneManager.LoadScene(1);
            }
            else if(selected == "quit")
            {
                Application.Quit();
            }
        }
	}
}
