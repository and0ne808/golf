using UnityEngine;
using System.Collections;

public class MoveableObject : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.mass = 500;
	}
	
	// Update is called once per frame
	void Update () {
	if(playerController.megaStrength)
    {
        rb.mass = 0.01f;
    }
    else
    {
        rb.mass = 500;
    }

    if (this.transform.position.y < -20)
    {
        Destroy(gameObject);

    }
	}
}
