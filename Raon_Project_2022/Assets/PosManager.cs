using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PosManager : MonoBehaviour
{
    public Transform[] positions;

    [SerializeField] bool[] seat;

    private void Start()
    {
        seat = Enumerable.Repeat<bool>(false, positions.Length).ToArray<bool>();
    }

    public void setSeat(int index, bool state)
    {
        seat[index] = state;
    }

    public bool getSeat(int index)
    {
        return seat[index];
    }

    public bool IsFull()
    {
        for (int i = 0; i < seat.Length; i++)
        {
            if (seat[i])
                return false;
        }
        return true;
    }
}
