using UnityEngine;
using System.Collections;

public class blueberryScript : MonoBehaviour {

    public float rotationRate;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Rotate(Vector3.left, rotationRate * Time.deltaTime);
	}
    void OnTriggerEnter(Collider collider)
    {
        playerController.pickupBlueberry.Play();
        Destroy(gameObject);
    }
}
