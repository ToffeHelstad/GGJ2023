using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [Header("Mouse Sensitivity")]
    [Tooltip("How sensitive should the mouse be? Default is: 300")]
    public float mouseSensitivity = 300f;               //Public variable for mouse sensitivity

    private Camera mainCamera;
    private float xRotation;
    private float yRotation;

    [Header("Arms and Hands")]
    public bool REngaged;
    public bool LEngaged;
    public bool BothEngaged;
    public GameObject rightHand;
    public GameObject leftHand;

    float mouseX;
    float mouseY;

    private bool mouseLocked;

    void Start()
    {
        mainCamera = Camera.main;                           //Fetches Main Camera in scene
        Cursor.lockState = CursorLockMode.Locked;       //Locks mouse to middle of screen
        Cursor.visible = false;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;        //Moves Mouse's X Axis
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;        //Moves Mouse's Y Axis

        if (Input.GetKey(KeyCode.Mouse1))
        {
            RightArm();
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            LeftArm();
        }
        else
        {
            NotEngaged();
        }


    }

    void NotEngaged()
    {
        if (mouseLocked == false)
        {
            LockMouse();
        }
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        mainCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
        REngaged = false;
    }

    void RightArm()
    {
        if(mouseLocked == true)
        {
            UnlockMouse();
        }
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        rightHand.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        REngaged = true;
    }

    void LeftArm()
    {
        if (mouseLocked == true)
        {
            UnlockMouse();
        }
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        leftHand.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        LEngaged = true;
    }

    void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        mouseLocked = true;
    }

    void UnlockMouse()
    {
        Cursor.lockState = CursorLockMode.None;
        mouseLocked = false;
    }
}
