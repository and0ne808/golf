using UnityEngine;
using System.Collections;

public class RolyPolyVillage2Gate : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetString("RolyPolyVillage1Completed") == "true")
        {
            Object.Destroy(this.gameObject);
        }
	}
}
