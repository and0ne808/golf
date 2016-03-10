using UnityEngine;
using System.Collections;

public class KublarCastle2Gate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetString("KublarCastle1Completed") == "true")
        {
            Object.Destroy(this.gameObject);
        }
	}
}
