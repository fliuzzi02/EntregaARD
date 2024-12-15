using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webcam : MonoBehaviour
{
    WebCamTexture webcamTexture;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        for (var i = 0; i < devices.Length; i++)
            Debug.Log(devices[i].name);

        if (devices.Length > 0)
        {
            WebCamTexture webcamTexture = new WebCamTexture(devices[0].name, 320, 240, 10);
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.mainTexture = webcamTexture;
            webcamTexture.Play();
        }
        else
        {
            Debug.Log("No camera detected");
        }
    }

    void Update() {
        if (Input.GetKey(KeyCode.Escape))
        {
            webcamTexture.Stop();
            Destroy(webcamTexture);
            Application.Quit();
        }
    }
    // Al cerrar la aplicación o el editor de Unity
    void OnApplicationQuit() {
        Debug.Log("Tancant\n");
        webcamTexture.Stop();
        Destroy(webcamTexture);
    }
}
