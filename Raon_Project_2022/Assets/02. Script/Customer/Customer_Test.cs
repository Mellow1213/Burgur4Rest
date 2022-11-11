using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Test : MonoBehaviour
{
    string[] food_ingredient = new string[10];
    Dish_Burger dish_burger = null;
    Customer_Status _customer_status = null;
    GameObject customer = null;

    private void Update()
    {
    }

    public CustomerMove _customerMove;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dish"))
        {
            dish_burger = other.GetComponent<Dish_Burger>();

            if(dish_burger)
                food_ingredient = dish_burger.GetIngredient();


            Debug.Log("food_ingredient[0] = " + food_ingredient[0]);
            Debug.Log("food_ingredient[dish_burger.GetIngredientCnt() - 1] = " + food_ingredient[dish_burger.GetIngredientCnt() - 1]);
            if (food_ingredient[0] != "bread-down" || food_ingredient[dish_burger.GetIngredientCnt() - 1] != "bread-top")
            {
                Debug.Log("잘못된 햄버거!");
            }

            for (int i = 0; i < dish_burger.GetIngredientCnt(); i++)
            {

                if (food_ingredient[i] == _customer_status.goodIngredient)
                    Debug.Log("호감 가는 햄버거~");
                if (food_ingredient[i] == _customer_status.badIngredient)
                    Debug.Log("비호감 햄버거~");
            }
             

            Destroy(other.transform.parent.gameObject);

            _customerMove.ChangeDestination(1);
        }



        if (other.CompareTag("Customer"))
        {
            customer = other.gameObject;
            _customer_status = customer.GetComponent<Customer_Status>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            customer = null;
            _customer_status = null;
        }
    }
}
