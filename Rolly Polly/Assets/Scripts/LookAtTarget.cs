using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

    private Transform target;
    public GameObject look;

	// Use this for initialization
	void Start () {
        target = look.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
        if(target != null)
        {
            transform.LookAt(target);
            transform.Rotate(0, 180, 0);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        }
	}
}
