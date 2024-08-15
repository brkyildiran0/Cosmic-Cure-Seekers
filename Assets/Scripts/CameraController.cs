using UnityEngine;
using Unity.Netcode;

public class CameraController : NetworkBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        if (!IsOwner)
        {
            // Disable the camera and its controller for non-owners
            // I need this to ensure everyone sees their own camera
            GetComponent<Camera>().enabled = false;
            GetComponent<AudioListener>().enabled = false;

            Destroy(this);
            return;
        }

        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        if (!IsOwner) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
