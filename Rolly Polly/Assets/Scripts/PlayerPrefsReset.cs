using UnityEngine;
using System.Collections;

public class PlayerPrefsReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
        Debug.Log("Player Prefs Deleted");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
