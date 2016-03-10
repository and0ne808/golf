using UnityEngine;
using System.Collections;

public class CritterCave2Gate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetString("CritterCave1Completed") == "true")
        {
            Object.Destroy(this.gameObject);
        }
	}
}
