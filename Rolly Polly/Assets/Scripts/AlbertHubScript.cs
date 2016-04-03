using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlbertHubScript : MonoBehaviour {

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

        signText = "Welcome to the Olympic Training Center sonny-boy! My name is Albert, I've been coaching Roly Polys for YEARS! We will be starting your training in Roly Poly Village.";

        //ROLY POLY VILLAGE
        if(PlayerPrefs.GetString("RolyPolyVillage1Completed") == "true")
        {
            signText = "This next stage is your first obstacle course. Race to the goal as quickly as you can! No dilly-dallying!";
        }
        if(PlayerPrefs.GetInt("RolyPolyVillage2Stars") > 0)
        {
            if(PlayerPrefs.GetInt("LastStars") == 1)
            {
                signText = "Hans! Your performance was abismal! TERRIBLE I SAY! You need to go FASTER! I would try again before I moved on to Critter Cave...";
            }
            else if(PlayerPrefs.GetInt("LastStars") == 2)
            {
                signText = "Hans! That wasn't too shabby! Next we will be training at Critter Cave.";
            }
            else if (PlayerPrefs.GetInt("LastStars") == 3)
            {
                signText = "EXCELLENT WORK HANS! We will continue training at Critter Cave whenever you are ready.";
            }

        }
        //CRITTER CAVE
        if (PlayerPrefs.GetString("CritterCave1Completed") == "true")
        {
            signText = "Are you ready to race through the obstacle course as quickly as you can? I will watch from a safe distance...";
        }
        if (PlayerPrefs.GetInt("CritterCave2Stars") > 0)
        {
            if (PlayerPrefs.GetInt("LastStars") == 1)
            {
                signText = "Hans! Your performance was abismal! TERRIBLE I SAY! You need to go FASTER! I would try again before I moved on to Insect Island...";
            }
            else if (PlayerPrefs.GetInt("LastStars") == 2)
            {
                signText = "Hans! That wasn't too shabby! Next we will be training at Insect Island.";
            }
            else if (PlayerPrefs.GetInt("LastStars") == 3)
            {
                signText = "EXCELLENT WORK HANS! We will continue training at Insect Island whenever you are ready.";
            }

        }
        //INSECT ISLAND
        if (PlayerPrefs.GetString("InsectIsland1Completed") == "true")
        {
            signText = "The next stage is the Insect Island obstacle course. ON YOUR MARKS.. OH! WAIT! We are not even at the course yet! Hurry up then! ";
        }
        if (PlayerPrefs.GetInt("InsectIsland2Stars") > 0)
        {
            if (PlayerPrefs.GetInt("LastStars") == 1)
            {
                signText = "Hans! Your performance was abismal! TERRIBLE I SAY! You need to go FASTER! I would try again before I moved on to Vermin Volcano...";
            }
            else if (PlayerPrefs.GetInt("LastStars") == 2)
            {
                signText = "Hans! That wasn't too shabby! Next we will be training at Vermin Volcano.";
            }
            else if (PlayerPrefs.GetInt("LastStars") == 3)
            {
                signText = "EXCELLENT WORK HANS! We will continue training at Vermin Volcano whenever you are ready.";
            }

        }
        //VERMIN VOLCANO
        if (PlayerPrefs.GetString("VerminVolcano1Completed") == "true")
        {
            signText = "Can you guess what the next stage is? A time attack? How did you know that? Hmm...";
        }
        if (PlayerPrefs.GetInt("VerminVolcano2Stars") > 0)
        {
            if (PlayerPrefs.GetInt("LastStars") == 1)
            {
                signText = "Hans! Your performance was abismal! TERRIBLE I SAY! You need to go FASTER! I would try again before I moved on to Kublar's Castle...";
            }
            else if (PlayerPrefs.GetInt("LastStars") == 2)
            {
                signText = "Hans! That wasn't too shabby! Next we will be training at King Kublar's Castle.";
            }
            else if (PlayerPrefs.GetInt("LastStars") == 3)
            {
                signText = "EXCELLENT WORK HANS! We will continue training at Kublar's Castle whenever you are ready.";
            }

        }
        //KUBLAR CASTLE
        if (PlayerPrefs.GetString("KublarCastle1Completed") == "true")
        {
            signText = "This next stage is your first obstacle course. Race to the goal as quickly as you can! No dilly-dallying!";
        }
        if (PlayerPrefs.GetInt("KublarCastle2Stars") > 0)
        {
            if (PlayerPrefs.GetInt("LastStars") == 1)
            {
                signText = "Hans! I know you can do better than that! Don't let Tedrick win!";
            }
            else if (PlayerPrefs.GetInt("LastStars") == 2)
            {
                signText = "Sonny! You are tied with Tedrick's record in Kublar Castle right now, you need one more star to beat him!";
            }
            else if (PlayerPrefs.GetInt("LastStars") == 3)
            {
                signText = "EXCELLENT WORK SONNY BOY! I knew you could do it!";
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
