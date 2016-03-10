using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelZone : MonoBehaviour {

    public string nameOfLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(nameOfLevel);
    }
}
