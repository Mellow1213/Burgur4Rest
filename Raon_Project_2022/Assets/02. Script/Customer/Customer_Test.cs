using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Test : MonoBehaviour
{
    string[] food_ingredient = new string[10];
    Dish_Burger dish_burger = null;

    public CustomerMove _customerMove;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dish"))
        {
            dish_burger = other.GetComponent<Dish_Burger>();

            if(dish_burger)
                food_ingredient = dish_burger.GetIngredient();

            for (int i = 0; i < dish_burger.GetIngredientCnt(); i++)
                Debug.Log(food_ingredient[i]);

            Destroy(other.transform.parent.gameObject);

            _customerMove.ChangeDestination(1);
        }
    }
}
