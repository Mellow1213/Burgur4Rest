using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool W;
    public bool A;
    public bool S;
    public bool D;
    public bool Interaction;
    public bool Pause;

    private void Update()
    {
        W = Input.GetKey(KeyCode.W);
        A = Input.GetKey(KeyCode.A);
        S = Input.GetKey(KeyCode.S);
        D = Input.GetKey(KeyCode.D);
        Interaction = Input.GetKey(KeyCode.Space);
        Pause = Input.GetKeyDown(KeyCode.Escape);
    }
}
