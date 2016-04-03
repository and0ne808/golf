using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FirstTimePlaying : MonoBehaviour {

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
        //img.color = Color.clear;

        if(PlayerPrefs.GetString("RolyPolyVillage1Completed") == "true")
        {
            text.text = "";
            img.color = new Color(0, 0, 0, 0);
            Destroy(gameObject);
        }
        else
        {
            signText = "I see that this is your first time playing Roly Poly Adventure Ball. Use the arrow keys, WASD, or the left analog stick to roll. Have fun!";
            text.text = signText;
            img.color = new Color(0, 0, 0, 0.5F);     
        }


	}
	
	
    void OnTriggerStay (Collider collider) 
    {
        if (PlayerPrefs.GetString("RolyPolyVillage1Completed") != "true")
        {
            text.text = signText;
            img.color = new Color(0, 0, 0, 0.5F);
        }
	}
    void OnTriggerExit(Collider collider)
    {
        text.text = "";
        img.color = new Color(0, 0, 0, 0);
        Destroy(gameObject);
    }
}

