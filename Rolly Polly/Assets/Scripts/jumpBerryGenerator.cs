using UnityEngine;
using System.Collections;

public class jumpBerryGenerator : MonoBehaviour {

    GameObject closest;
    GameObject current;
    GameObject[] speedBerries;
    float spawnTimer;
    bool respawn;

	// Use this for initialization
	void Start () {
	//speedBerry = GameObject.FindWithTag("speedberry");
        spawnTimer = 0;
        respawn = false;

        //spawn blueberry
        GameObject newBerry = Instantiate(Resources.Load("megaJumpBerry", typeof(GameObject)), new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {

        if (respawn == false && GameObject.FindWithTag("jumpberry") != null)
        {
            speedBerries = GameObject.FindGameObjectsWithTag("jumpberry");
            closest = GameObject.FindWithTag("jumpberry");

            foreach (GameObject speedBerry in speedBerries)
            {
                //find closest
                if (Vector3.Distance(speedBerry.transform.position, this.transform.position) < Vector3.Distance(closest.transform.position, this.transform.position))
                    closest = speedBerry;
            }

            if(Vector3.Distance(closest.transform.position, this.transform.position) > 3)
            {
                Debug.Log(Vector3.Distance(closest.transform.position, this.transform.position));
                spawnTimer = 3f;
                respawn = true;
            }
        }
        else if (respawn == false && GameObject.FindWithTag("jumpberry") == null)
        {
            spawnTimer = 3f;
            respawn = true;
        }

        if (respawn == true && spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else if (respawn == true && spawnTimer <= 0)
        {
            spawnTimer = 0;
            respawn = false;
            //spawn blueberry
            GameObject newBerry = Instantiate(Resources.Load("megaJumpBerry", typeof(GameObject)), new Vector3(this.transform.position.x, this.transform.position.y+1, this.transform.position.z), Quaternion.identity) as GameObject;
        }
	}
}
