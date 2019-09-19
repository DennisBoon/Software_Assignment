using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerPickUps pPU;
    public Dialogue dia;

    void OnTriggerEnter(Collider col)
    {
        // Collision for pick up 1
        if (col.gameObject.CompareTag("Pick Up 1"))
        {
            if (pPU.blue > 0 && pPU.wrongPickup1 > 0 ||
                pPU.blue > 0 && pPU.wrongPickup2 > 0 ||
                pPU.wrongPickup1 > 0 && pPU.wrongPickup2 > 0)
            {
                dia.SetDialogue(dia.twoColorsPicked, "You already picked 2 colors");
            }
            else
            {
                pPU.Increment(pPU.red, 1);
                col.gameObject.SetActive(false);
            }
        }
        // Collision for pick up 2
        if (col.gameObject.CompareTag("Pick Up 2"))
        {
            if (pPU.red > 0 && pPU.wrongPickup1 > 0 ||
                pPU.red > 0 && pPU.wrongPickup2 > 0 ||
                pPU.wrongPickup1 > 0 && pPU.wrongPickup2 > 0)
            {
                dia.SetDialogue(dia.twoColorsPicked, "You already picked 2 colors");
            }
            else
            {
                pPU.Increment(pPU.blue, 1);
                col.gameObject.SetActive(false);
            }
        }
        // Collision for pick up 3
        if (col.gameObject.CompareTag("Pick Up 3"))
        {
            if (pPU.red > 0 && pPU.blue > 0 ||
                pPU.red > 0 && pPU.wrongPickup2 > 0 ||
                pPU.blue > 0 && pPU.wrongPickup2 > 0)
            {
                dia.SetDialogue(dia.twoColorsPicked, "You already picked 2 colors");
            }
            else
            {
                pPU.Increment(pPU.wrongPickup1, 1); ;
                col.gameObject.SetActive(false);
            }
        }
        // Collision for pick up 4
        if (col.gameObject.CompareTag("Pick Up 4"))
        {
            if (pPU.red > 0 && pPU.blue > 0 ||
                pPU.red > 0 && pPU.wrongPickup1 > 0 ||
                pPU.blue > 0 && pPU.wrongPickup1 > 0)
            {
                dia.SetDialogue(dia.twoColorsPicked, "You already picked 2 colors");
            }
            else
            {
                pPU.Increment(pPU.wrongPickup2, 1);
                col.gameObject.SetActive(false);
            }
        }

        // Collision for the door
        if (col.gameObject.CompareTag("Door") && pPU.red > 0 && pPU.blue > 0)
        {
            dia.SetDialogue(dia.notYet, "Puzzle Complete!");
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("Door") && pPU.wrongPickup1 > 0 && pPU.red > 0 || 
            col.gameObject.CompareTag("Door") && pPU.wrongPickup1 > 0 && pPU.blue > 0 || 
            col.gameObject.CompareTag("Door") && pPU.wrongPickup2 > 0 && pPU.red > 0 || 
            col.gameObject.CompareTag("Door") && pPU.wrongPickup2 > 0 && pPU.blue > 0 || 
            col.gameObject.CompareTag("Door") && pPU.wrongPickup1 > 0 && pPU.wrongPickup2 > 0)
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
