using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour {

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

	// Text variables.
	public float textTime = 3;
	public Text hint;
	public Text watchOut;
	public Text gratz;

	// Variable to lock door
	private Vector3 roomlock = new Vector3 (92.08f, 8.15f, 39.606f);

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();

		// Texts
		hint.text = "Memorize the colors you see before you, it may come in handy.";
		Destroy (hint, textTime);
		watchOut.text = "";
		gratz.text = "";
	}
	
	// Update is called once per frame
	void Update () {

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
			Application.LoadLevel("Game 2");
		}

		// Buttonprompt to exit game
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
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
			if (Input.GetKey (KeyCode.LeftShift)) {
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

	void OnTriggerEnter (Collider col) {
		// Collision with hidden door/wall
		if (col.gameObject.CompareTag ("Hidden Door")) {
			gratz.text = "Very impressive... But I still have one more challenge for you!";
			Destroy (gratz, textTime);
			Destroy (col.gameObject);
		}

		// Collision with wrong ground
		if (col.gameObject.CompareTag ("Wrong Ground")) {
			Application.LoadLevel ("Game 2");
		}	
	
		// Collision with watch out hint
		if (col.gameObject.CompareTag ("Watch Out")) {
			watchOut.text = "Watch yourself, when you step on the wrong color you will have to retry.";
			Destroy (watchOut, textTime);

		}
		// Collision with room lock
		if (col.gameObject.CompareTag ("Room Lock")) {
			col.gameObject.transform.position = roomlock;
		
		}
		// Collision with door to next level
		if (col.gameObject.CompareTag ("Door")) {
			Application.LoadLevel ("Game 3");
		}
	}
}

