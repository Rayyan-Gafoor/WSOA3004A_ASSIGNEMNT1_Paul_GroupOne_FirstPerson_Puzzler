using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    [Header ("Parkour:WallRunning")]
    [SerializeField] Transform orientation;

    [SerializeField] float WallDis = 0.5f;
    [SerializeField] float MinJumpHeight = 0.5f;
    [SerializeField] float WallJumpForce;
    [SerializeField] float WallForceMulti = 100f;

    bool wallLeft = false;
    bool wallRight = false;

    Rigidbody rb;
    [SerializeField] float WallRunGravity;

    RaycastHit leftWallHit;
    RaycastHit rightWallHit;

    [Header("Parkour:Pole/Rope CLimb")]
    [SerializeField] float ClimbSpeed;


    bool wallRunEnabled()
    {
        return !Physics.Raycast(transform.position, Vector3.down, MinJumpHeight);
    }
    void CheckWall()
    {
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallHit, WallDis);
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallHit, WallDis);
         
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckWall();
        if (wallRunEnabled())
        {
            if (wallLeft)
            {
                WallRuning();
                Debug.Log("wall run on left");
            }
            else if (wallRight)
            {
                WallRuning();
                Debug.Log("wall run on Right");
            }
            else
            {
                DisableParkour();
            }

        }
    }
    void WallRuning()
    {
        rb.useGravity = false;
        rb.AddForce(Vector3.down * WallRunGravity, ForceMode.Force);
        if (Input.GetButtonDown("Jump"))
        {
            if (wallLeft)
            {
                Vector3 WallRunJumpDir = transform.up + leftWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(WallRunJumpDir * WallJumpForce * WallForceMulti, ForceMode.Force);
            }
            else if (wallRight)
            {
                Vector3 WallRunJumpDir = transform.up + rightWallHit.normal;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(WallRunJumpDir * WallJumpForce* WallForceMulti, ForceMode.Force);
            }
        }
    }
    void DisableParkour()
    {
        rb.useGravity = true;
    }
}
