using UnityEngine;
using System.Collections;

public class CursorHideShow : MonoBehaviour {

	void Start ()
  {
    	Cursor.lockState = CursorLockMode.Locked;
    	Cursor.visible = false;
  }
    void Update ()
  {
    	Cursor.lockState = CursorLockMode.Locked;
    	Cursor.visible = false;
  }
}