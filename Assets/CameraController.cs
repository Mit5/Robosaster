using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX;
    private float mouseY;
    public float mouseSensitivity = 0.5f;
    public GameObject Player;
    public float mouseRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        transform.Translate(mouseX, mouseY, 0);
        
    }
}
