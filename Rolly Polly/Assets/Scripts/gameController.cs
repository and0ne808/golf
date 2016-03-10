using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    public static bool levelComplete;
    public AudioSource music;
    public string playerPrefsString;

	// Use this for initialization
	void Start () {
        levelComplete = false;
        //PlayerPrefs.SetString("RolyPolyVillage1Completed", "true");
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindWithTag("blueberry") == null)
        {
            levelComplete = true;
            Debug.Log("Level Complete");
            PlayerPrefs.SetString(playerPrefsString, "true");
            PlayerPrefs.Save();
            SceneManager.LoadScene("BlueberriesCollected");
        }

        if(playerController.megaSpeed)
        {
            music.pitch = 2f;
        }
        else
        {
            music.pitch = 1;
        }
	}
}
