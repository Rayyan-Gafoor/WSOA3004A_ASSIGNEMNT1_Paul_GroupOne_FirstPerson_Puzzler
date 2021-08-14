using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{

    [SerializeField] float SprintSpeed = 6f;
    [SerializeField] float Acceleration = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ControlSpeed()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            
        }
    }
}
