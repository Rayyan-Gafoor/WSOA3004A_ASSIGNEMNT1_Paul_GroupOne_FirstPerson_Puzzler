using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;

    public GameObject obj;

    public KeyCode PickupKey, DropKey;

    public float Speed = 12f;
    public float Gravity = -9.8f;
    public float JumpHeight = 3f;

    public Vector3 Velocity;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask GroundMask;
    public LayerMask PickableObj;

    public bool isGrounded;
    public bool PickedUpObject;

    public Transform PickupPoint;

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        if (isGrounded && Velocity.y < 0)
        {
            Velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity); //Equation allows the player to jump. 
        }

        float X = Input.GetAxis("Horizontal");
        float Z = Input.GetAxis("Vertical");

        Vector3 Move = transform.right * X + transform.forward * Z;

        Controller.Move(Move * Speed * Time.deltaTime);

        Velocity.y += Gravity * Time.deltaTime;

        Controller.Move(Velocity * Time.deltaTime);

        ///
        ///
        ///
        ///
        ///

        Vector3 LookDirection = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;

        if (Physics.Raycast(PickupPoint.position, LookDirection, out hit ,100) && !PickedUpObject && Input.GetKeyDown(PickupKey))
        {
            if (hit.collider.tag == "Pickable")
            {
                Debug.Log("Looking at the object");
                //hit.transform.parent = PickupPoint.transform;
                obj = hit.collider.gameObject;
                obj.transform.parent = PickupPoint.transform;
                obj.transform.position = new Vector3(PickupPoint.transform.position.x, PickupPoint.transform.position.y, PickupPoint.transform.position.z);
                PickedUpObject = true;
            }
        }

        if (PickedUpObject && Input.GetKeyDown(DropKey))
        {
            obj.transform.parent = null;
            PickedUpObject = false;
            obj = null;
        }
    }
}

