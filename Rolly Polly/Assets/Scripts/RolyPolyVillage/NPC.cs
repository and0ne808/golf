using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPC : MonoBehaviour {

    public string NPC_Text;
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

        //signText = "ALBERT: Welcome to your first day of training my boy! Let's get right to it. ROLL to collect all the blueberries on this map. After my main course of blueberries (Yum!), you will be ready for your first Obstacle Course! Now hurry up and get me those blueberries. I'm starving!";


        }
	
	// Update is called once per frame
	void OnTriggerEnter (Collider collider) 
    {
        text.text = NPC_Text;
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
