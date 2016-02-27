using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {

    public static bool levelComplete;

	// Use this for initialization
	void Start () {
        levelComplete = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindWithTag("blueberry") == null)
        {
            levelComplete = true;
            Debug.Log("Level Complete");
            SceneManager.LoadScene(0);
        }
	}
}
