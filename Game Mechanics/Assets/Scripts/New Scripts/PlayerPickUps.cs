using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUps : MonoBehaviour
{
    // Pick Ups
    [HideInInspector]
    public int red = 0;
    [HideInInspector]
    public int blue = 0;
    [HideInInspector]
    public int wrongPickup1 = 0;
    [HideInInspector]
    public int wrongPickup2 = 0;

    public void Increment(int pickUp, int value)
    {
        pickUp += value;
    }
}
