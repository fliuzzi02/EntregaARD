using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator = null;
    [SerializeField] private Collider myCollider = null;
    [SerializeField] private float force = 10.0f;
    [SerializeField] private new Camera camera = null;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 1, -2);

    private GameObject ball;
    private Collider ballCollider;
    private Rigidbody ballRB;

    [ClientCallback]
    private void Start()
    {
        // If current player is the local player, then allow movement
        if (isLocalPlayer)
        {
            ball = GameObject.Find("Sphere");
            ballCollider = ball.GetComponent<Collider>();
            ballRB = ball.GetComponent<Rigidbody>();
            camera = Camera.FindObjectOfType<Camera>();

            camera.transform.parent = transform;
            camera.transform.localPosition = cameraOffset;
        }
    }

    [ClientCallback]
    private void Update()
    {
        if (isLocalPlayer)
        {
            // If current player is the local player, then allow movement
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetFloat("Speed", 1);
                animator.SetBool("Backwards", false);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetFloat("Speed", 1);
                animator.SetBool("Backwards", true);
            }
            else
            {
                animator.SetFloat("Speed", 0);
            }
        }
    }

    [ClientCallback]
    private void FixedUpdate()
    {
        // Apply force when my collider touches ball's collider
        if (myCollider.bounds.Intersects(ballCollider.bounds))
        {
            ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
            // Play sound of ball
            ball.GetComponent<AudioSource>().Play();
        }
    }
}
