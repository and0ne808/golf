using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class okButton : MonoBehaviour
{

    private Color startcolor;
    AudioSource audio;
    private string selected;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        startcolor = GetComponent<Renderer>().material.color;
        selected = "ok";
    }

    void OnMouseEnter()
    {
        if (selected != "ok")
        {
            selected = "ok";
            audio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (selected == "ok")
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<Renderer>().material.color = startcolor;
        }

        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Return))
        {
            audio.Play();
            SceneManager.LoadScene("MainHub");
        }

    }
}
