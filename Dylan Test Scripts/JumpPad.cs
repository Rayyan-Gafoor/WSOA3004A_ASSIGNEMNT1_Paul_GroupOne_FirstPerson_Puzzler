using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    /// <summary>
    /// if the player steps on a tribjgger (used a cube to make a small platform) then basically make it jump like in the PlayerMovement script.
    /// </summary>

    public float JumpHeight = 20f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("on jump pad");
            playerMovement.Velocity.y = Mathf.Sqrt(JumpHeight * -2f * playerMovement.Gravity); //Uses jump from player movement script but just with a different jump height so that they go higher.
        }
    }
}
