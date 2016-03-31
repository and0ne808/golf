using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

  public GameObject player;

    private Vector3 offset;
    public Vector3 zoomVector;
    public float zoom;

    void Start ()
    {
        offset = transform.position - player.transform.position;
        zoomVector = Vector3.zero;
    }

    void Update()
    {
        if (zoom <= 3 && zoom >= -50)
        {

            zoom += (Input.GetAxis("RightV"));
            //Debug.Log(zoom);
            zoomVector = new Vector3(0, -zoom, zoom);
        }

        if (zoom > 3)
        {
            zoom = 3;
            zoomVector = new Vector3(0, -zoom, zoom);
        }
        if (zoom < -50)
        {
            zoom = -50;
            zoomVector = new Vector3(0, -zoom, zoom);
        }
    }
    
    void LateUpdate ()
    {
        transform.position = player.transform.position + offset + zoomVector;
    }
}
