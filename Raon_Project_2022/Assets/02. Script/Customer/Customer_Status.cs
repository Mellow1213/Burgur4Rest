using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Status : MonoBehaviour
{
    public int star = 7;
    public int money = 0;
    public string goodIngredient;
    public string badIngredient;

    string[] ingredientList = { "bread-top", "bread-down", "alface", "chesse", "ham-baked", "ham-burnt", "ham-raw", "onion", "tomato" };
    void Start()
    {
        goodIngredient = ingredientList[Random.Range(2, 8)];
        do
        {
            badIngredient = ingredientList[Random.Range(2, 8)];
        } while (badIngredient == goodIngredient);
        Debug.Log("good = " + goodIngredient + ", bad = " + badIngredient);
    }
}
