using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BallBehaviour : MonoBehaviour
{
    public float force;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Add force to the ball
            Vector3 direction = transform.position - collision.transform.position;
            direction = direction.normalized;
            GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
            // Play sound
            GetComponent<AudioSource>().Play();
        }
    }
}
