using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        myGold = 100;
        myRate = 0.7f;
    }

    public int myGold;
    public float myRate;

    private void Update()
    {
        myRate = Mathf.Clamp(myRate, 0, 1);
    }
}