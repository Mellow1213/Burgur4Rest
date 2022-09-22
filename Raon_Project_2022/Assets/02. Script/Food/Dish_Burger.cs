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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            foodtype = other.GetComponent<BurgerType>();
            GameObject temp = Instantiate(foodtype.platingPrefab, transform.position, transform.rotation);
            temp.transform.SetParent(transform);

            Debug.Log("prevHeight = " + prevHeight + ", currHeight = " + foodtype.food_Height);
            Debug.Log("���̰� : " + (prevHeight / 2 + foodtype.food_Height / 2) + ", �Լ� ��ȯ �� = " + CalcHeight(prevHeight, foodtype.food_Height));

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
