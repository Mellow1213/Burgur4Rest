using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PosManager : MonoBehaviour
{
    public Transform[] positions;

    bool[] seat;

    private void Start()
    { 
        seat = Enumerable.Repeat<bool>(false, positions.Length).ToArray<bool>(); 
    }


}
