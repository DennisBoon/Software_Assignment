using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private float textTime = 3;
    public Text wrongCombination, twoColors, notYet, twoColorsPicked,
        controls, controls2, controls3;

    private void Start()
    {
        controls.text = "WASD or Arrows to move, Mouse to look around";
        controls2.text = "Left/Right SHIFT to sprint";
        controls3.text = "Press BACKSPACE to close this message";
    }

    public void SetDialogue(Text textObj, string dia)
    {
        textObj.text = dia;
        Destroy(textObj, textTime);
    }
}
