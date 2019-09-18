using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {

	// Texts
	public Text thanks;
	public Text madeBy;
	public Text musicBy;
	public Text musicBy2;
	public Text musicBy3;
	public Text exitGame;

	// Use this for initialization
	void Start () {
		thanks.text = "Thanks for playing!";
		madeBy.text = "Made by: Dennis Boon";
		musicBy.text = "Backgroundmusic by: Lex Relax Piano";
		musicBy2.text = "Puzzle of Life / Relaxing Emotional Piano music";
		musicBy3.text = "https://www.youtube.com/channel/UCa0JSgSSRQf2eQbZ7ydjdfA";
		exitGame.text = "Press ESCAPE to close the game";
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
	}
}
