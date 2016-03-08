using UnityEngine;
using System.Collections;

public class PointToBlueberry : MonoBehaviour {

    //public GameObject player;

    private Transform target;
    private GameObject[] blueberries;
    private GameObject closest;
    private bool filling;

	// Use this for initialization
	void Start () {
        blueberries = GameObject.FindGameObjectsWithTag("blueberry");
        closest = GameObject.FindWithTag("blueberry");
        filling = true;
	}
	
	// Update is called once per frame
	void Update () {
        foreach(GameObject blueberry in blueberries)
        {
            filling = true;

            if(blueberry == null || closest == null)
            {
                blueberries = GameObject.FindGameObjectsWithTag("blueberry");
                closest = GameObject.FindWithTag("blueberry");
                filling = true;
                break;
            }

            if (Vector3.Distance(blueberry.transform.position, this.transform.position) < Vector3.Distance(closest.transform.position, this.transform.position))
                closest = blueberry;
            filling = false;

        }

        if (closest != null && filling == false)
        {
            //Debug.Log(closest.transform.position);
            transform.LookAt(closest.transform);
            transform.Rotate(0, 90, 0);
            transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);
        }

	}
    /*
    void FixedUpdate()
    {
        if (closest != null)
        {
            Debug.Log(closest.transform.position);
            transform.LookAt(closest.transform);
            transform.Rotate(0, 90, 0);
            transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, 0);
        }
    }
      */
}
