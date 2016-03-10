using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class StatusText : MonoBehaviour {

    public Text text;
    private String currentString;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        currentString = "";

        if (playerController.wallJump)
        {
            currentString += " WALL JUMP \n";
        }
	if (playerController.megaSpeed)
    {
        currentString += " MEGA SPEED: " + Math.Round(playerController.megaSpeedTimer, 0) + "\n";
    }
    if (playerController.megaStrength)
    {
        currentString += " MEGA STRENGTH " + Math.Round(playerController.megaStrengthTimer, 0) + "\n";
    }
    if (playerController.megaJump)
    {
        currentString += " MEGA JUMP: " + Math.Round(playerController.megaJumpTimer, 0) + "\n";
    }


    text.text = currentString;

	}
}
