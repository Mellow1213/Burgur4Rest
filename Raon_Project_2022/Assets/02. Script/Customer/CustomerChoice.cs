using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerChoice : MonoBehaviour
{
    Dish_Burger dish_made, dish_customer;
    GameObject dish;
    int review;
    
    string liked_Ingredient, hated_Ingredient;
    // Start is called before the first frame update
    void Start()
    {
        dish_customer = new Dish_Burger();
        SetTaste();
    }

    // Update is called once per frame
    void Update()
    {
        // when 'dish' GameObject is OnTriggerEnter with the field on table
        // in front of the customer -> the GameObject dish will be 'dish_made'
        // -> Run Review() to give grades of the dish
    }
    

    public void SetTaste()
    { // randomly choose the likable ingredient and hateable ingredient
        string[] ingredientList = { "Bread", "Patty", "Lettuce", "Tomato" }; // Temporary ingredientList
        int random_a = Random.Range(1, 4);
        int random_b = Random.Range(1, 4);
        while (random_a == random_b)
        {
            random_b = Random.Range(1, 4);
        }
        liked_Ingredient = ingredientList[random_a];
        hated_Ingredient = ingredientList[random_b];

    }

    public int Review() // whether the customer is satisfied or not
    {
        string[] dish_ingredient = dish_made.GetIngredient();
        int ingredientCnt = dish_made.GetIngredientCnt();
        bool hated_in = false;
        bool liked_in = false;
        review = 3;
        if (dish_ingredient[0] != "Bread" || dish_ingredient[ingredientCnt - 1] != "Bread")
        {
            review = 3;
        }
        else
        {
            for(int i = 0; i < ingredientCnt; i++)
            {
                if (dish_ingredient[i] == liked_Ingredient)
                    liked_in = true;
                if (dish_ingredient[i] == hated_Ingredient)
                    hated_in = true;
            }
        }
        if (liked_in) review++;
        if (hated_in) review--;

        return review;
    }
}
