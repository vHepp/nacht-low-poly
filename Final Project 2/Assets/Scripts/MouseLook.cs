using UnityEngine;

public class MouseLook : MonoBehaviour
{
	public Transform playerBody; // transform of player
	public float mouseSensitivity = 100f; // look sensitivity

	float xRotation = 0f; // vertical rotation of player/camera transform

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // lock the mouse to the game
    }

    // Update is called once per frame
    void Update()
    {
		// get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation,-90f,90f); // keeps player from turning upside down


		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // edit rotation 
		playerBody.Rotate(Vector3.up * mouseX);
	}
}
