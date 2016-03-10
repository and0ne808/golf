using UnityEngine;
using System.Collections;

public class FanScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if(other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(Vector3.up * 10);
        }
    }
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.back, 500 * Time.deltaTime);
    }
}
