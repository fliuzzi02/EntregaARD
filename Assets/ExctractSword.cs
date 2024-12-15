using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ExctractSword : NetworkBehaviour
{
    private Vector3 offsetPosition = new Vector3(0.002f, 0.005f, 0.002f);
    private Quaternion offsetRotation = Quaternion.Euler(186.621f, 94.901f, -261.87f);

    private bool extracted = false;

    [ClientRpc]
    public void AssignSword(GameObject player)
    {
        if (!extracted)
        {
            // List all childs of player
            Transform[] children = player.GetComponentsInChildren<Transform>();
            // Find the right hand among children
            GameObject rightHand = null;
            foreach (Transform child in children)
            {
                if (child.gameObject.name == "Right Hand")
                {
                    rightHand = child.gameObject;
                    break;
                }
            }
            if (rightHand == null)
            {
                Debug.LogError("Right Hand not found");
                return;
            }

            // Extract the sword
            extracted = true;
            transform.parent = rightHand.transform;
            transform.localPosition = offsetPosition;
            transform.localRotation = offsetRotation;

            // Play the sword extraction sound
            GetComponent<AudioSource>().Play();

            Debug.Log("Sword extracted");
        }
    }
}
