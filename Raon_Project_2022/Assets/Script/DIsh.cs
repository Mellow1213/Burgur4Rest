using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIsh : MonoBehaviour
{
    LinkedList<string> IngredientList = new LinkedList<string>();
    private float ingredientCount = 1f;
    private float foodHeight;

    // Start is called before the first frame update
    void Start()
    {
        foodHeight = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Food")
        {
            
            other.transform.parent = this.gameObject.transform.parent;
            FoodType ingredient = other.GetComponent<FoodType>();
            foodHeight = ingredient.IngredientScale.y + foodHeight;
            other.transform.localPosition = new Vector3(0f, foodHeight, 0f);
            other.transform.eulerAngles = Vector3.zero;
            other.transform.localScale = ingredient.IngredientScale;
            other.transform.GetComponent<BoxCollider>().enabled = false;
            other.transform.GetComponent<Rigidbody>().isKinematic = true;
            IngredientList.AddLast(ingredient.IngredientName);
            ingredientCount++;

            Debug.Log(ingredient.IngredientName);
        }    
    }
}
