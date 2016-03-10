using UnityEngine;
using System.Collections;

public class InsectIsland2Gate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetString("InsectIsland1Completed") == "true")
        {
            Object.Destroy(this.gameObject);
        }
	}
}
