using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;
	// current player movement speed
	public float movementSpeed = 12f;
	public float jumpHeight = 3f;
	public float gravity = -9.81f;

	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
	public Vector3 velocity;
	bool isGrounded;

    // Update is called once per frame
    void Update()
    {
		// check to see if player is on the ground
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

		// if grounded, change gravity back to a low value
		if (isGrounded && velocity.y < 0 ){
			velocity.y = -2f;
		}
		
		// new unity input system
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		controller.Move(move * movementSpeed * Time.deltaTime);

		if (Input.GetButtonDown("Jump") && isGrounded) {
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity* Time.deltaTime);
    }

}
