using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExctractSword : MonoBehaviour
{
    public GameObject sword;
    private Collider swordCollider;

    private bool extracted = false;

    // Start is called before the first frame update
    void Start()
    {
        sword = GameObject.Find("Sword");
        if (sword == null)
            Debug.LogError("Sword not found");
        swordCollider = sword.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if a game object tagged as player exists
        if (!(GameObject.FindGameObjectWithTag("Player") == null)) {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            // If a game object tagged as player is within the sword collider, and the player presses the E key, extract the sword
            if (swordCollider.bounds.Intersects(player.GetComponent<Collider>().bounds) && Input.GetKeyDown(KeyCode.E) && !extracted)
            {
                extracted = true;
                GameObject hand = GameObject.Find("Right Hand");
                sword.transform.parent = hand.transform;
                sword.transform.localPosition = new Vector3(0.002f, 0.005f, 0.002f);
                sword.transform.localRotation = Quaternion.Euler(186.621f, 94.901f, -261.87f);

                // Play the sword extraction sound
                GetComponent<AudioSource>().Play();

                Debug.Log("Sword extracted");
            }
        }
    }
}
