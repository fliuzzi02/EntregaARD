using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraController : NetworkBehaviour
{
    [SerializeField] private Camera myCamera;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 rotation;

    private void Start()
    {
        if (isLocalPlayer)
        {
            // Find camera tagged as "MainCamera"
            myCamera = Camera.main;

            // Set camera to follow player
            myCamera.transform.SetParent(transform);
            myCamera.transform.localPosition = offset;
            myCamera.transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
