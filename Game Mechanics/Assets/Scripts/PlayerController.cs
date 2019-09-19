using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	// Pick Ups
	private int red = 0;
	private int blue = 0;
	private int wrongPickup1 = 0;
	private int wrongPickup2 = 0;

	// A boolean variable to make the player controllable or not.
	public bool controllable = false;
 
	// Variables for player movement.
	public float speed = 5.0f;
	public float sprintSpeed = 10.0f;
	public float jumpSpeed = 6.0f;
	public float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	// Variables for camera movement.
	public float speedH = 2.0f;
	public float speedV = 2.0f;
	private float yaw = 0.0f;
	private float pitch = 0.0f;
	private Vector2 mouseLook;

	// Text variables.
	public float textTime = 3;
	public Text wrongCombination;
	public Text twoColors;
	public Text notYet;
	public Text twoColorsPicked;
	public Text controls;
	public Text controls2;
	public Text controls3;

	// Use this for initialization
	void Start ()
	{
		controller = GetComponent<CharacterController> ();

		// Texts
		wrongCombination.text = "";
		twoColors.text = "";
		notYet.text = "";
		twoColorsPicked.text = "";
		controls.text = "WASD or Arrows to move, Mouse to look around";
		controls2.text = "Left/Right SHIFT to sprint";
		controls3.text = "Press BACKSPACE to close this message";
	}

	// Update is called once per frame
	void Update ()
	{
		// Cheats
		if (Input.GetKeyDown(KeyCode.F1)) {
			Application.LoadLevel("Game");
		}
		if (Input.GetKeyDown(KeyCode.F2)) {
			Application.LoadLevel("Game 2");
		}
		if (Input.GetKeyDown(KeyCode.F3)) {
			Application.LoadLevel("Game 3");
		}
		if (Input.GetKeyDown(KeyCode.F4)) {
			Application.LoadLevel("Game 4");
		}

		// Buttonprompt to restart game
		if (Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel("Game");
		}

		// Buttonprompt to exit game
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		// Buttonprompt to close controls
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			Destroy (controls);
			Destroy (controls2);
			Destroy (controls3);
		}

		// Camera movement
		yaw += speedH * Input.GetAxis ("Mouse X");
		pitch -= speedV * Input.GetAxis ("Mouse Y");

		transform.eulerAngles = new Vector3 (pitch, yaw, 0.0f);

		// Player movement
		if (controller.isGrounded && controllable) {
    	 
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);

			// Player speed
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
				moveDirection *= sprintSpeed;
			} else {
				moveDirection *= speed;
			}
            
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
	}

	void OnTriggerEnter (Collider col)
	{
		// Collision for pick up 1
		if (col.gameObject.CompareTag ("Pick Up 1")) {
			if (blue > 0 && wrongPickup1 > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else if (blue > 0 && wrongPickup2 > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else if (wrongPickup1 > 0 && wrongPickup2 > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else {
				red += 1;
				print ("Pick Up 1 collected");
				col.gameObject.SetActive (false);
			}
		}
		// Collision for pick up 2
		if (col.gameObject.CompareTag ("Pick Up 2")) {
			if (red > 0 && wrongPickup1 > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else if (red > 0 && wrongPickup2 > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else if (wrongPickup1 > 0 && wrongPickup2 > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else {
				blue += 1;
				print ("Pick Up 2 collected");
				col.gameObject.SetActive (false);
			}
		}
		// Collision for pick up 3
		if (col.gameObject.CompareTag ("Pick Up 3")) {
			if (red > 0 && blue > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else if (red > 0 && wrongPickup2 > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else if (blue > 0 && wrongPickup2 > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else {
				wrongPickup1 += 1;
				print ("Pick Up 3 collected");
				col.gameObject.SetActive (false);
			}
		}
		// Collision for pick up 4
		if (col.gameObject.CompareTag ("Pick Up 4")) {
			if (red > 0 && blue > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else if (red > 0 && wrongPickup1 > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else if (blue > 0 && wrongPickup1 > 0) {
				twoColorsPicked.text = "Don't be greedy, you already picked 2 colors!";
				Destroy (twoColorsPicked, textTime);
			} else {
				wrongPickup2 += 1;
				print ("Pick Up 4 collected");
				col.gameObject.SetActive (false);
			}
		}
		// Collision for the door
		if (col.gameObject.CompareTag ("Door") && red > 0 && blue > 0) {
			notYet.text = "Impressive... But you are not done yet!";
			Destroy (notYet, textTime);
			Destroy (col.gameObject);
		} else if (col.gameObject.CompareTag ("Door") && wrongPickup1 > 0 && red > 0 || col.gameObject.CompareTag ("Door") && wrongPickup1 > 0 && blue > 0 || col.gameObject.CompareTag ("Door") && wrongPickup2 > 0 && red > 0 || col.gameObject.CompareTag ("Door") && wrongPickup2 > 0 && blue > 0 || col.gameObject.CompareTag ("Door") && wrongPickup1 > 0 && wrongPickup2 > 0) {
			wrongCombination.text = "That's the wrong color combination. Try again (Press R to restart)";
			Destroy (wrongCombination, textTime);
		} else if (col.gameObject.CompareTag ("Door")) {
			twoColors.text = "Don't these colored blocks look interesting to you?";
			Destroy (twoColors, textTime);
		}
		if (col.gameObject.CompareTag ("Hidden Door")) {
			Destroy (col.gameObject);
		}
		// Collision with the second door.
		if (col.gameObject.CompareTag ("Door 2")) {
			Application.LoadLevel("Game 2");
		}
	}
}
   