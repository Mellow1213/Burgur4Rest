using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject[] food;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Instantiate(food[0], new Vector3(0, 6, 0), Quaternion.identity);
        if (Input.GetKeyDown(KeyCode.W))
            Instantiate(food[1], new Vector3(0, 6, 0), Quaternion.identity);
        if (Input.GetKeyDown(KeyCode.E))
            Instantiate(food[2], new Vector3(0, 6, 0), Quaternion.identity);
    }
}
