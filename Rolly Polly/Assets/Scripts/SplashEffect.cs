using UnityEngine;
using System.Collections;

public class SplashEffect : MonoBehaviour {

    public ParticleSystem particleSplash;
    public AudioSource splashSound;
    public AudioClip splash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            Debug.Log("On Trigger Enter Activated");
            particleSplash.Emit(20);
            splashSound.PlayOneShot(splash);
        }

        if(other.attachedRigidbody.CompareTag("moveable"))
        {
            Debug.Log("On Trigger Enter Activated");
            ParticleSystem barrelParticle = other.GetComponent<ParticleSystem>();
            barrelParticle.Emit(20);
            splashSound.PlayOneShot(splash);
            Destroy(other, 3);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            Debug.Log("On Trigger Exit Activated");
            particleSplash.Emit(20);
            splashSound.PlayOneShot(splash);
        }
    }

}
