using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			gameObject.GetComponent<Renderer> ().material.color = Color.white;
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			gameObject.GetComponent<Renderer> ().material.color = Color.red;
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			gameObject.GetComponent<Renderer> ().material.color = Color.blue;
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			gameObject.GetComponent<Renderer> ().material.color = Color.green;
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			gameObject.GetComponent<Renderer> ().material.color = Color.cyan;
		}
	}
}
