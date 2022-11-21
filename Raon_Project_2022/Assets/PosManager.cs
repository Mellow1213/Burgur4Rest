using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PosManager : MonoBehaviour
{
    public Transform[] positions;

    [SerializeField] bool[] seat;
    int index = 2;

    private void Start()
    {
        seat = Enumerable.Repeat<bool>(false, positions.Length).ToArray<bool>();
        seat[0] = true;
        seat[1] = true;
    }

    private void Update()
    {
        Debug.Log(index);
        index = Mathf.Clamp(index, 2, 13);
    }

    public void SeatOn(int index)
    {
            seat[index] = true;
    }

    public void SeatOff(int index)
    {
            seat[index] = false;
    }

    public int getIndex() {
        for(int i =2; i<=13; i++)
            if(!seat[i])
                return i;

        return 0;
    }

    public bool IsFull()
    {
        for (int i = 0; i < seat.Length; i++)
        {
            if (!seat[i])
                return false;
        }
        return true;
    }
}
