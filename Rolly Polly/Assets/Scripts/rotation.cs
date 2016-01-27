using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
	}
}
