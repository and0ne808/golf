using UnityEngine;
using System.Collections;

public class MegaStrengthBerry : MonoBehaviour {

    private float rotationRate;
    AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rotationRate = 50;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.left, rotationRate * Time.deltaTime);
    }
    void OnTriggerEnter(Collider collider)
    {
        playerController.pickupBlueberry.Play();
        playerController.megaStrengthTimer = 10f;
        Destroy(gameObject);
    }
}
