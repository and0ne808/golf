using UnityEngine;
using System.Collections;

public class FanScript2 : MonoBehaviour {
    
    public float fanForce; //10 = normal
    public float rotationalVelocity; //500 = normal;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(Vector3.up * fanForce);
        }
    }
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.back, rotationalVelocity * Time.deltaTime);
    }
}
