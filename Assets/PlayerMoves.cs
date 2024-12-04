using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{   
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;

    // Animator component
    private Animator animator;

    // Get animation parameter hash
    private int animationSpeed = Animator.StringToHash("Speed");
    private int animationBackwards = Animator.StringToHash("Backwards");

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // If pressing W or S, set the speed parameter to 1
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetFloat(animationSpeed, 1);
            animator.SetBool(animationBackwards, false);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            animator.SetFloat(animationSpeed, 1);
            animator.SetBool(animationBackwards, true);
        }
        else
        {
            animator.SetFloat(animationSpeed, 0);
        }


        // Player moves with WASD, w and s to move forward and backward, a and d to turn left and right
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
