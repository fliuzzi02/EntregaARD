using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator = null;
    private TextMeshProUGUI scoreText = null;
    private int score = 0;

    private bool collisionCooldown = false;
    private float cooldownTime = 0;

    public override void OnStartLocalPlayer()
    {
        scoreText = GameObject.Find("Points").GetComponent<TextMeshProUGUI>();
    }

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

            // If player press E and collides with sword, then grab sword
            if (Input.GetKeyDown(KeyCode.E))
            {
                CmdGrabSword();
            }

            if(collisionCooldown && ((Time.time - cooldownTime) >= 2))
            {
                collisionCooldown = false;
            }
        }
    }

    private void AddScore()
    {
        score++;
        scoreText.text = "Score: "+score.ToString();
    }

    // On collision trigger
    void OnTriggerEnter(Collider other)
    {
        if (isLocalPlayer)
        {
            // If other is tagged as UFO
            if (other.gameObject.tag == "UFO" && other.gameObject.GetComponent<UFOBehaviour>().isVisible() && !collisionCooldown)
            {
                collisionCooldown = true;
                cooldownTime = Time.time;
                AddScore();
                // Make UFO invisible
                CmdUFO(other.gameObject.GetComponent<UFOBehaviour>());
            }
        }
    }

    [Command]
    public void CmdUFO(UFOBehaviour ufo)
    {
        Debug.Log("Commanding UFO");
        ufo.Disappear();
    }

    [Command]
    public void CmdGrabSword()
    {
        Debug.Log("Commanding Sword");
        GameObject sword = GameObject.Find("Sword");
        sword.GetComponent<ExctractSword>().AssignSword(gameObject);
    }
}
