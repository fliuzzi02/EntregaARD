using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator = null;

    [Client]
    private void Start()
    {
        
    }

    [Client]
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
}
