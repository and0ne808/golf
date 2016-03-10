﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VerminVolcano2Sign : MonoBehaviour {

    public string signText;
    public GameObject player;
    public Canvas canvas;
    public Text text;
    public GameObject panel;
    public float distanceThreshold;

    Image img;
	// Use this for initialization
	void Start () {
        img = panel.GetComponent<Image>();
        img.color = Color.clear;

        string currentString = "Vermin Volcano Golf Course\n";
        currentString += "Best Time: " + PlayerPrefs.GetFloat("VerminVolcano2BestTime") + "\n";
        currentString += "Stars: " + PlayerPrefs.GetInt("VerminVolcano2Stars");

        signText = currentString;

	}
	
	void OnTriggerEnter (Collider collider) 
    {
        text.text = signText;
        img.color = new Color(0, 0, 0, 0.5F);
	}
    void OnTriggerExit(Collider collider)
    {
        text.text = "";
        img.color = new Color(0, 0, 0, 0);
    }
}
