using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] string mouseXInputName, mouseYInputName;
    [SerializeField] public float mouseSensitivity = 0.5f;
    //Temp / Testing recoil
    [SerializeField] private float recoilDegrees;
    private Transform playerBody;
    private CharacterController parentController;

    private float xAxisClamp = 0.0f;
    private float mouseX;
    private float mouseY;


    // Start is called before the first frame update
    void Start()
    {
        lockCursor();
        playerBody = transform.parent;
        parentController = GetComponentInParent<CharacterController>();
    }

    private void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
        CameraHeight();
    }
    
    /// <summary>
    /// Recoil method, used in weapon scripts with a specific constant, leaving empty will set the recoil to 1 degree
    /// </summary>
    /// <param name="recoilAmount"> The amount of distance the camera moves up after every shot, in degrees </param>
    /// <param name="maxRecoilHeight"> The maximum height the camera can reach because of recoil in degrees</param>
    public void Recoil(float recoilAmount = 1.0f)
    {
        
        transform.Rotate(Vector3.left * recoilAmount * Time.fixedDeltaTime * 50);
        xAxisClamp += recoilAmount;

    }

    private void CameraHeight()
    {
        transform.position = new Vector3(parentController.transform.position.x, parentController.transform.position.y + parentController.height / 2 - 0.1f, parentController.transform.position.z);
    }

    private void CameraRotation()
    {
        //Mouse's X and Y inputs
       
        {
            mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;
        }

        //Keeps the amount of degrees the mouse has moved up
        xAxisClamp += mouseY;

        //Clamps the mouse look so that it does not exceed 90* up or down
        ClampMouse();

        //Rotates the camera AND the player
        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);

    }

    //Mouse Y axis Clamping
    private void ClampMouse()
    {
        if (xAxisClamp > 90)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }
    }

    //Mouse movement clamp sub-method
    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }


}
