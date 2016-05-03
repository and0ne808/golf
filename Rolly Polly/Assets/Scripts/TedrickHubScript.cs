using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TedrickHubScript : MonoBehaviour {

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

        signText = "TEDRICK: You must be the new guy. Hans, was it? I'm Tedrick! I'm the best Roly Poly Racer there is!";

        //ROLY POLY VILLAGE
        if(PlayerPrefs.GetString("RolyPolyVillage1Completed") == "true")
        {
            signText = "TEDRICK: I got three stars on my first try, I bet you won't even come close!";
        }
        if(PlayerPrefs.GetInt("RolyPolyVillage2Stars") > 0)
        {
            if (PlayerPrefs.GetInt("RolyPolyVillage2Stars") == 1)
            {
                signText = "TEDRICK: HAHAHA! Boy are you SLOW! Better luck next time bud!";
            }
            else if (PlayerPrefs.GetInt("RolyPolyVillage2Stars") == 2)
            {
                signText = "TEDRICK: I knew you couldn't get three stars!";
            }
            else if (PlayerPrefs.GetInt("RolyPolyVillage2Stars") == 3)
            {
                signText = "TEDRICK: Hmm... That was beginner's luck!";
            }

        }
        //CRITTER CAVE
        if (PlayerPrefs.GetString("CritterCave1Completed") == "true")
        {
            signText = "TEDRICK: Get ready newbie! This one is much harder than the last one! You can always catch the bus back home if you can't do it!";
        }
        if (PlayerPrefs.GetInt("CritterCave2Stars") > 0)
        {
            if (PlayerPrefs.GetInt("CritterCave2Stars") == 1)
            {
                signText = "TEDRICK: HAHAHA! What were you doing out there!?";
            }
            else if (PlayerPrefs.GetInt("CritterCave2Stars") == 2)
            {
                signText = "TEDRICK: There is no way you can get three stars like me!";
            }
            else if (PlayerPrefs.GetInt("CritterCave2Stars") == 3)
            {
                signText = "TEDRICK: Hmm... I think you cheated!";
            }

        }
        //INSECT ISLAND
        if (PlayerPrefs.GetString("InsectIsland1Completed") == "true")
        {
            signText = "TEDRICK: I can't believe how slow you have been in the last courses. Are you going to step it up?";
        }
        if (PlayerPrefs.GetInt("InsectIsland2Stars") > 0)
        {
            if (PlayerPrefs.GetInt("InsectIsland2Stars") == 1)
            {
                signText = "TEDRICK: I don't know what Albert sees in you. I would've sent you home already!";
            }
            else if (PlayerPrefs.GetInt("InsectIsland2Stars") == 2)
            {
                signText = "TEDRICK: Mediocracy suits you.";
            }
            else if (PlayerPrefs.GetInt("InsectIsland2Stars") == 3)
            {
                signText = "TEDRICK: You won't be so lucky at the next stage.";
            }

        }
        //VERMIN VOLCANO
        if (PlayerPrefs.GetString("VerminVolcano1Completed") == "true")
        {
            signText = "TEDRICK: Have you ever considered changing your color to something a little more flashy?";
        }
        if (PlayerPrefs.GetInt("VerminVolcano2Stars") > 0)
        {
            if (PlayerPrefs.GetInt("VerminVolcano2Stars") == 1)
            {
                signText = "TEDRICK: This is pathetic Hans! Tell me again, how did you qualify for the Jr. Olympics?";
            }
            else if (PlayerPrefs.GetInt("VerminVolcano2Stars") == 2)
            {
                signText = "TEDRICK: That wasn't bad, but still not as good as my time.";
            }
            else if (PlayerPrefs.GetInt("VerminVolcano2Stars") == 3)
            {
                signText = "TEDRICK: Have you been copying my technique?";
            }

        }
        //KUBLAR CASTLE
        if (PlayerPrefs.GetString("KublarCastle1Completed") == "true")
        {
            signText = "TEDRICK: This is it! I've only gotten two stars on this stage. Let's see how you do.";
        }
        if (PlayerPrefs.GetInt("KublarCastle2Stars") > 0)
        {
            if (PlayerPrefs.GetInt("KublarCastle2Stars") == 1)
            {
                signText = "TEDRICK: I thought so, that's ok kid, there's always next year!";
            }
            else if (PlayerPrefs.GetInt("KublarCastle2Stars") == 2)
            {
                signText = "TEDRICK: Well, you can't beat the best.";
            }
            else if (PlayerPrefs.GetInt("KublarCastle2Stars") == 3)
            {
                signText = "TEDRICK: ... You actually did it, I can't believe it!";
            }

        }

	}
	
	// Update is called once per frame
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
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            text.text = "";
            img.color = new Color(0, 0, 0, 0);
        }
    }
}
