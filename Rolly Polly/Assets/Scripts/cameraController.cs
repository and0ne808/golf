using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

  public GameObject player;

    private Vector3 offset;
    private Vector3 zoomVector;
    private float zoom;
    public float minZoom; // default = 3
    public float maxZoom; // deafault = -50

    void Start ()
    {
        offset = transform.position - player.transform.position;
        zoomVector = Vector3.zero;
    }

    void Update()
    {
        if (zoom <= minZoom && zoom >= maxZoom)
        {

            zoom += (Input.GetAxis("RightV"));
            //Debug.Log(zoom);
            zoomVector = new Vector3(0, -zoom, zoom);
        }

        if (zoom > minZoom)
        {
            zoom = minZoom;
            zoomVector = new Vector3(0, -zoom, zoom);
        }
        if (zoom < maxZoom)
        {
            zoom = maxZoom;
            zoomVector = new Vector3(0, -zoom, zoom);
        }
    }
    
    void LateUpdate ()
    {
        transform.position = player.transform.position + offset + zoomVector;
    }
}
