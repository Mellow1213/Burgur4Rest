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
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

    public int myGold = 0;
    public float myRate = 0f;

    int rate = 0;
    int rateCnt = 0;
    public void CalRate(int rate)
    {
        rateCnt++;
        this.rate += rate;
        myRate = (float)this.rate / rateCnt; 
    }
}