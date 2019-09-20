using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Dialogue dia;

    void OnTriggerEnter(Collider col)
    {
        // Collision for pick up 1
        if (col.gameObject.CompareTag("Pick Up 1"))
        {
            if (PickUps.instance.blue > 0 && PickUps.instance.green > 0 ||
                PickUps.instance.blue > 0 && PickUps.instance.yellow > 0 ||
                PickUps.instance.green > 0 && PickUps.instance.yellow > 0)
            {
                dia.SetDialogue(dia.twoColorsPicked, "You already picked 2 colors");
            }
            else
            {
                PickUps.instance.Increment(PickUps.instance.red, 1);
                col.gameObject.SetActive(false);
            }
        }
        // Collision for pick up 2
        if (col.gameObject.CompareTag("Pick Up 2"))
        {
            if (PickUps.instance.red > 0 && PickUps.instance.green > 0 ||
                PickUps.instance.red > 0 && PickUps.instance.yellow > 0 ||
                PickUps.instance.green > 0 && PickUps.instance.yellow > 0)
            {
                dia.SetDialogue(dia.twoColorsPicked, "You already picked 2 colors");
            }
            else
            {
                PickUps.instance.Increment(PickUps.instance.blue, 1);
                col.gameObject.SetActive(false);
            }
        }
        // Collision for pick up 3
        if (col.gameObject.CompareTag("Pick Up 3"))
        {
            if (PickUps.instance.red > 0 && PickUps.instance.blue > 0 ||
                PickUps.instance.red > 0 && PickUps.instance.yellow > 0 ||
                PickUps.instance.blue > 0 && PickUps.instance.yellow > 0)
            {
                dia.SetDialogue(dia.twoColorsPicked, "You already picked 2 colors");
            }
            else
            {
                PickUps.instance.Increment(PickUps.instance.green, 1); ;
                col.gameObject.SetActive(false);
            }
        }
        // Collision for pick up 4
        if (col.gameObject.CompareTag("Pick Up 4"))
        {
            if (PickUps.instance.red > 0 && PickUps.instance.blue > 0 ||
                PickUps.instance.red > 0 && PickUps.instance.green > 0 ||
                PickUps.instance.blue > 0 && PickUps.instance.green > 0)
            {
                dia.SetDialogue(dia.twoColorsPicked, "You already picked 2 colors");
            }
            else
            {
                PickUps.instance.Increment(PickUps.instance.yellow, 1);
                col.gameObject.SetActive(false);
            }
        }

        // Collision for the door
        if (col.gameObject.CompareTag("Door") && PickUps.instance.red > 0 && PickUps.instance.blue > 0)
        {
            dia.SetDialogue(dia.notYet, "Puzzle Complete!");
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("Door") && PickUps.instance.green > 0 && PickUps.instance.red > 0 || 
            col.gameObject.CompareTag("Door") && PickUps.instance.green > 0 && PickUps.instance.blue > 0 || 
            col.gameObject.CompareTag("Door") && PickUps.instance.yellow > 0 && PickUps.instance.red > 0 || 
            col.gameObject.CompareTag("Door") && PickUps.instance.yellow > 0 && PickUps.instance.blue > 0 || 
            col.gameObject.CompareTag("Door") && PickUps.instance.green > 0 && PickUps.instance.yellow > 0)
        {
            dia.SetDialogue(dia.wrongCombination, "Wrong color combination. Try again (Press R to restart)");
        }
        
        // Collision for hidden door
        if (col.gameObject.CompareTag("Hidden Door"))
        {
            Destroy(col.gameObject);
        }

        // Collision with the second door.
        if (col.gameObject.CompareTag("Door 2"))
        {
            NextLevel.LevelSelect("Game 2");
        }
    }
}
