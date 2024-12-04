using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExctractSword : MonoBehaviour
{
    public GameObject sword;
    public GameObject player;
    public GameObject playerHand;

    // Sword collider
    private Collider swordCollider;
    private Collider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        sword = GameObject.Find("Sword");
        player = GameObject.Find("Banana Man");
        playerHand = GameObject.Find("Right Hand");
        swordCollider = sword.GetComponent<Collider>();
        playerCollider = player.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player is within collider of sword, press E to extract sword
        if (swordCollider.bounds.Intersects(playerCollider.bounds) && Input.GetKeyDown(KeyCode.E))
        {
            // Play the sword extraction sound
            sword.GetComponent<AudioSource>().Play();

            // Set the sword to be a child of the player's hand
            sword.transform.parent = playerHand.transform;

            // Set the sword's local position and rotation to (186.621, 94.901, -261.87) degrees
            sword.transform.localPosition = new Vector3(0.002f, 0.005f, 0.002f);
            sword.transform.localRotation = Quaternion.Euler(186.621f, 94.901f, -261.87f);

            // Debug message
            Debug.Log("Sword extracted");
        }

    }
}
