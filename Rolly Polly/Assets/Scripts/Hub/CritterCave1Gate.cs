using UnityEngine;
using System.Collections;

public class CritterCave1Gate : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("RolyPolyVillage2Stars") > 0)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
