using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float SensX;
    [SerializeField] private float SensY;

    [SerializeField] Transform cam;
    [SerializeField] Transform orientation;

    float mouseX;
    float mouseY;
    float multiplier = 0.01f;
    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        cam.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    void MyInput()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * SensX * multiplier;
        xRotation -= mouseY * SensY * multiplier;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
    }
}
