using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public static PickUps instance = null;

    // Pick Ups
    public int red = 0;
    public int blue = 0;
    public int green = 0;
    public int yellow = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void Increment(int pickUp, int value)
    {
        pickUp += value;
    }
}
