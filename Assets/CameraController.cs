using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CameraController : NetworkBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 rotation;

    public override void OnStartLocalPlayer()
    {
        Camera.main.transform.SetParent(transform);
        Camera.main.transform.localPosition = offset;
        Camera.main.transform.rotation = Quaternion.Euler(rotation);
    }
}
