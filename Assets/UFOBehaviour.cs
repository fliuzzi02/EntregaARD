using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class UFOBehaviour : NetworkBehaviour
{
    [SerializeField] private Vector3 movement;
    [SerializeField] private bool movingLeft = true;
    [SerializeField] private float minInvisibleTime = 2;
    [SerializeField] private float maxInvisibleTime = 5;
    [SerializeField]
    [SyncVar] private float invisibleTime;

    [SerializeField]
    [SyncVar] public bool visible = true;

    // Start is called before the first frame update
    void Start()
    {
        // Play audio
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (movingLeft)
            transform.position -= movement * Time.deltaTime;
        else
            transform.position += movement * Time.deltaTime;

        if (transform.position.x <= -8)
            movingLeft = false;
        else if (transform.position.x >= 8)
            movingLeft = true;
    }

    [ClientRpc]
    public void Disappear()
    {
        Debug.Log("Executing Command");
        // Play sound
        GetComponent<AudioSource>().Stop();
        // Make object invisible
        GetComponent<MeshRenderer>().enabled = false;
        // Make object inconsistent
        GetComponent<CapsuleCollider>().enabled = false;
        // Wait random seconds before making object visible again
        invisibleTime = Random.Range(minInvisibleTime, maxInvisibleTime);
        // Invoke method to make object visible again
        Invoke("Appear", invisibleTime);
    }

    void Appear()
    {
        // Make object visible and play music
        visible = true;
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<AudioSource>().Play();
    }

    public bool isVisible()
    {
        return visible;
    }
}
