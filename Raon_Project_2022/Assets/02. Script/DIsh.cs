using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    //접시에 담긴 재료 저장하는 연결 리스트
    LinkedList<string> IngredientList = new LinkedList<string>();
    private float ingredientCount = 1f;
    private float foodHeight;

    public GameObject prefab_;
    void Start()
    {
        foodHeight = 0.1f;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Food")
        {
            other.transform.parent = this.gameObject.transform.parent;

            FoodType ingredient = other.GetComponent<FoodType>();

            Vector3 foodPos = new Vector3(0, foodHeight, 0);
            foodHeight += 0.1f;
            Debug.Log("foodHeight = " + foodHeight);
            Destroy(other.gameObject);
            GameObject temp = Instantiate(prefab_, transform.parent.position+foodPos, prefab_.transform.rotation);
            temp.transform.parent = transform.parent;

            IngredientList.AddLast(ingredient.IngredientName);
            ingredientCount++;
            Debug.Log(ingredient.IngredientName);
            Debug.Log(ingredientCount);
        }
    }
}
