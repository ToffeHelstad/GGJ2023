using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFPS : MonoBehaviour
{
	public float Sensitivity
	{
		get { return sensitivity; }
		set { sensitivity = value; }
	}
	[Range(0.1f, 9f)] [SerializeField] float sensitivity = 2f;
	[Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
	[Range(0f, 90f)] [SerializeField] float yRotationLimit = 88f;

	Vector2 rotation = Vector2.zero;
	const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
	const string yAxis = "Mouse Y";

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

    public int mouseSensitivity = 300;

    void Start()
    {
        LockMouse();
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

    void RightArm()
    {
        //if (mouseLocked == true)
        //{
        //    UnlockMouse();
        //}
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        rightHand.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        REngaged = true;
    }

    void LeftArm()
    {
        //if (mouseLocked == true)
        //{
        //    UnlockMouse();
        //}
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        leftHand.transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        LEngaged = true;
    }

    void NotEngaged()
    {
        rotation.x += Input.GetAxis(xAxis) * sensitivity;
        rotation.y += Input.GetAxis(yAxis) * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        transform.localRotation = xQuat * yQuat; //Quaternions seem to rotate more consistently than EulerAngles. Sensitivity seemed to change slightly at certain degrees using Euler. transform.localEulerAngles = new Vector3(-rotation.y, rotation.x, 0);
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
