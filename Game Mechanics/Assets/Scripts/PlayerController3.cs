using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController3 : MonoBehaviour {

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

	// Texts
	public float textTime = 3;
	public Text controls;
	public Text controls2;
	public Text controls3;
	public Text welcome;
	public Text hey;
	public Text puzzleDone;

	// Cameras
	public Camera cam1;
	public Camera cam2;

	// Variables for color changing
	public int redPaint = 0;
	public int bluePaint = 0;
	public int greenPaint = 0;
	public int yellowPaint = 0;
	public int cyanPaint = 0;

	// Bool for completing puzzle
	private bool puzzleComplete = false;

	// Many booleans because I don't know how to do it in a better way
	private bool C1 = false, C2 = false, C3 = false, C4 = false, C5 = false, C6 = false, C7 = false;
	private bool G1 = false, G2 = false, G3 = false, G4 = false, G5 = false;
	private bool Y1 = false, Y2 = false;
	private bool R1 = false, R2 = false, R3 = false, R4 = false, R5 = false, R6 = false, R7 = false, R8 = false;
	private bool B1 = false, B2 = false, B3 = false, B4 = false;

	// Use this for initialization
	void Start ()
	{
		controller = GetComponent<CharacterController> ();

		// Setting the cameras to the start state
		cam1.enabled = true;
		cam2.enabled = false;

		// Texts
		controls.text = "";
		controls2.text = "";
		controls3.text = "";
		welcome.text = "The final challenge... You think you can connect the colors?";
		Destroy (welcome, textTime);
		hey.text = "";
		puzzleDone.text = "";
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
			Application.LoadLevel("Game 3");
		}

		// Buttonprompt to exit game
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}

		// Buttonprompt to switch between cameras
		if (Input.GetKeyDown(KeyCode.C)) {
			cam1.enabled = !cam1.enabled;
			cam2.enabled = !cam2.enabled;
		}
		// Buttonprompt to remove controls message
		if (Input.GetKeyDown (KeyCode.Backspace)) {
				Destroy (controls);
				Destroy (controls2);
				Destroy (controls3);
		}
		// Change painting color upon player input.
		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			redPaint = 0;
			bluePaint = 0;
			greenPaint = 0;
			yellowPaint = 0;
			cyanPaint = 0;
		}
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			redPaint = 1;
			bluePaint = 0;
			greenPaint = 0;
			yellowPaint = 0;
			cyanPaint = 0;
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			bluePaint = 1;
			redPaint = 0;
			greenPaint = 0;
			yellowPaint = 0;
			cyanPaint = 0;
		}
		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			greenPaint = 1;
			redPaint = 0;
			bluePaint = 0;
			yellowPaint = 0;
			cyanPaint = 0;
		}
		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			yellowPaint = 1;
			redPaint = 0;
			bluePaint = 0;
			greenPaint = 0;
			cyanPaint = 0;
		}
		if (Input.GetKeyDown(KeyCode.Alpha5)) {
			cyanPaint = 1;
			redPaint = 0;
			bluePaint = 0;
			greenPaint = 0;
			yellowPaint = 0;
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

	void OnTriggerEnter(Collider col) {
		// Collision with first door
		if (col.gameObject.CompareTag("Door")) {
			controls.text = "Press C to switch between cameras";
			controls2.text = "Press 1, 2, 3, 4, 5 to change painting color, press 0 for no paint";
			controls3.text = "Press BACKSPACE to close this message";
			Destroy (col.gameObject);
		}
		// Collision with the EndDoor
		if (col.gameObject.CompareTag("EndDoor") && puzzleComplete == true) {
			Destroy (col.gameObject);
		} else if (col.gameObject.CompareTag("EndDoor") && puzzleComplete == false) {
			hey.text = "Hey! You haven't completed the puzzle yet, get back in there!";
			Destroy (hey, textTime);
		}
		// Collision with the trophy
		if (col.gameObject.CompareTag("Prize")) {
			Application.LoadLevel("Game 4");
		}
		// Collision with the paintable platforms
		if (col.gameObject.CompareTag("PaintGroundC1")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.cyan) {
				C1 = true;
			} else {
				C1 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundC2")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.cyan) {
				C2 = true;
			} else {
				C2 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundC3")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.cyan) {
				C3 = true;
			} else {
				C3 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundC4")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.cyan) {
				C4 = true;
			} else {
				C4 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundC5")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.cyan) {
				C5 = true;
			} else {
				C5 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundC6")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.cyan) {
				C6 = true;
			} else {
				C6 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundC7")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.cyan) {
				C7 = true;
			} else {
				C7 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundG1")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.green) {
				G1 = true;
			} else {
				G1 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundG2")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.green) {
				G2 = true;
			} else {
				G2 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundG3")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.green) {
				G3 = true;
			} else {
				G3 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundG4")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.green) {
				G4 = true;
			} else {
				G4 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundG5")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.green) {
				G5 = true;
			} else {
				G5 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundY1")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.yellow) {
				Y1 = true;
			} else {
				Y1 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundY2")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.yellow) {
				Y2 = true;
			} else {
				Y2 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundR1")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.red) {
				R1 = true;
			} else {
				R1 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundR2")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.red) {
				R2 = true;
			} else {
				R2 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundR3")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.red) {
				R3 = true;
			} else {
				R3 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundR4")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.red) {
				R4 = true;
			} else {
				R4 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundR5")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.red) {
				R5 = true;
			} else {
				R5 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundR6")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.red) {
				R6 = true;
			} else {
				R6 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundR7")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.red) {
				R7 = true;
			} else {
				R7 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundR8")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.red) {
				R8 = true;
			} else {
				R8 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundB1")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.blue) {
				B1 = true;
			} else {
				B1 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundB2")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.blue) {
				B2 = true;
			} else {
				B2 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundB3")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.blue) {
				B3 = true;
			} else {
				B3 = false;
			}
		}
		if (col.gameObject.CompareTag("PaintGroundB4")) {
			if (redPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.red;
			} else if (bluePaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.blue;
			} else if (greenPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.green;
			} else if (yellowPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (cyanPaint == 1) {
				col.gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
			}
			if (col.gameObject.GetComponent<Renderer> ().material.color == Color.blue) {
				B4 = true;
			} else {
				B4 = false;
			}
		}
		if (C1 == true && C2 == true && C3 == true && C4 == true && C5 == true && C6 == true && C7 == true && G1 == true && G2 == true && G3 == true && G4 == true && G5 == true && Y1 == true && Y2 == true && R1 == true && R2 == true && R3 == true && R4 == true && R5 == true && R6 == true && R7 == true && R8 == true && B1 == true && B2 == true && B3 == true && B4 == true) {
			puzzleComplete = true;
			puzzleDone.text = "Hmm... I think you actually did it. Try that locked door over there.";
			Destroy (puzzleDone, textTime);
		} else {
			puzzleComplete = false;
		}
	}
}