﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RolyPolyVillage1Sign : MonoBehaviour {

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

        if(PlayerPrefs.GetString("RolyPolyVillage1Completed") == "true")
        {
            signText = "You have found all the blueberries in Roly Poly Village! The Roly Poly Village Obstacle Course has been UNLOCKED!";
        }
        else
        {
            signText = "You still need to find all of the blueberries in Roly Poly Village";
        }


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

