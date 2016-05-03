using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimerTextScript : MonoBehaviour {

    public Text text;
    private String currentString;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        currentString = Math.Round(golfController.golfTime, 0).ToString();


    text.text = currentString;

	}
}
