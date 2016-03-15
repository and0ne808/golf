using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

    private Transform target;
    public GameObject look;
    public RectTransform cameraTransform;
    public Vector3 cameraRotation;

	// Use this for initialization
	void Start () {

        target = look.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
        if(target != null)
        {
            transform.LookAt(target,this.transform.up);
            //transform.Rotate(0, 0, 0);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        }
	}
}
