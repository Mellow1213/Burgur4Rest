using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodType : MonoBehaviour
{
    public string IngredientName;
    public Vector3 IngredientScale;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
