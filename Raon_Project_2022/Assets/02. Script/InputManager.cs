using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool W;
    public bool A;
    public bool S;
    public bool D;

    private void Update()
    {
        W = Input.GetKeyDown(KeyCode.W);
        A = Input.GetKeyDown(KeyCode.A);
        S = Input.GetKeyDown(KeyCode.S);
        D = Input.GetKeyDown(KeyCode.D);
    }
}
