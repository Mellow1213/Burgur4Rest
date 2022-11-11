using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish_Burger : MonoBehaviour
{
    string[] ingredient = new string[10]; // ���ÿ� ��� ��� ���� ���� �迭
    int ingredientCnt = 0; // ���ÿ� ��� ��� ���� ����

    BurgerType foodtype;
    public int MaximumIngredient = 5; // ���ÿ� ���� �� �ִ� �ִ� ���
    float foodHeight = 0f;
    float prevHeight = 0f;

    public string[] GetIngredient()
    {
        return ingredient;
    }

    public int GetIngredientCnt()
    {
        return ingredientCnt;
    }

    public void SetIngredient(string[] input_ingredient)
    {
        ingredient = input_ingredient;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            foodtype = other.GetComponent<BurgerType>();
            GameObject temp = Instantiate(foodtype.platingPrefab, transform.position, foodtype.platingPrefab.transform.rotation);
            temp.transform.SetParent(transform);

            foodHeight += CalcHeight(prevHeight, foodtype.food_Height);
            temp.transform.localPosition = new Vector3(0, foodHeight, 0);
            prevHeight = foodtype.food_Height;

            Destroy(other.gameObject);

            ingredient[ingredientCnt] = foodtype.food_name;
            ingredientCnt++;
        }
    }

    float CalcHeight(float prev, float curr)
    {
        return prev * 0.5f + curr * 0.5f;
    }

}
