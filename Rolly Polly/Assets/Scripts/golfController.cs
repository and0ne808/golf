using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class golfController : MonoBehaviour {

    public static bool levelComplete;
    public AudioSource music;
    public string playerPrefsBestTime;
    public string playerPrefsStars;
    public static float golfTime;
    public int stars;
    public float twoStarThreshold; //Set to 20 for 20 seconds
    public float threeStarThreshold; // Set to 10 for 10 seconds

	// Use this for initialization
	void Start () {
        levelComplete = false;
        //PlayerPrefs.SetString("RolyPolyVillage1Completed", "true");
        stars = 0;
        golfTime = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if(GameObject.FindWithTag("blueberry"))
        {
        golfTime += Time.deltaTime;
        }
        else if (GameObject.FindWithTag("blueberry") == null)
        {
            levelComplete = true;
            stars = 1;
            Debug.Log("Level Complete");

            //SET STAR RATING

           

            if(golfTime < threeStarThreshold)
            {
                stars = 3;
            }
            else if(golfTime < twoStarThreshold)
            {
                stars = 2;
            }

            PlayerPrefs.SetInt("LastStars", stars);
            PlayerPrefs.SetFloat("LastTime", golfTime);

            //SET NEW BEST TIME
            if(PlayerPrefs.GetFloat(playerPrefsBestTime) == 0)
            {
                PlayerPrefs.SetFloat(playerPrefsBestTime, golfTime);
                PlayerPrefs.SetInt(playerPrefsStars, stars);
            }
            else if (PlayerPrefs.GetFloat(playerPrefsBestTime) > golfTime)
            {
                PlayerPrefs.SetFloat(playerPrefsBestTime, golfTime);
                PlayerPrefs.SetInt(playerPrefsStars, stars);
            }



            PlayerPrefs.SetInt(playerPrefsStars, stars);
            PlayerPrefs.Save();
            if (stars == 1)
            {
                SceneManager.LoadScene("OneStar");
            }
            else if (stars == 2)
            {
                SceneManager.LoadScene("TwoStars");
            }
            else if (stars == 3)
            {
                SceneManager.LoadScene("ThreeStars");
            }
            else
            {
                SceneManager.LoadScene("MainHub");
            }
        }

        if(playerController.megaSpeed)
        {
            music.pitch = 2f;
        }
        else
        {
            music.pitch = 1;
        }
	}
}
