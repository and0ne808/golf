using UnityEngine;
using System.Collections;

public class InsectIsland1Gate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("CritterCave2Stars") > 0)
        {
            Object.Destroy(this.gameObject);
        }
	}
}
