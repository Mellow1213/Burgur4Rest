using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    string[] ingredient = new string[10]; // ���ÿ� ��� ��� ���� ���� �迭
    int ingredientCnt = 0; // ���ÿ� ��� ��� ���� ����

    FoodType foodtype;
    public int MaximumIngredient = 5; // ���ÿ� ���� �� �ִ� �ִ� ���
    float foodHeight = 0f;

    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            foodtype = other.GetComponent<FoodType>();
            GameObject temp = Instantiate(foodtype.platingPrefab, transform.position, transform.rotation);
            temp.transform.SetParent(transform);
            temp.transform.localPosition = new Vector3(0, foodHeight, 0);
            foodHeight += foodtype.food_Height;

            Destroy(other.gameObject);

            ingredient[ingredientCnt] = foodtype.food_name;
            ingredientCnt++;
        }


    }

    private void Update() // �׽�Ʈ��. ���߿� ����
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            IngredientTest();
        }

    }
    void IngredientTest()
    {
        string temp = "";
        temp += "���ÿ� �ִ� ���ĵ� : ";
        for (int i = 0; i < ingredientCnt; i++)
        {
            temp += "[" + i + "] " + ingredient[i] + "  ";
        }
        Debug.Log(temp);

    }
}