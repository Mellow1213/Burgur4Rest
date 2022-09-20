using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    string[] ingredient = new string[10]; // 접시에 담긴 재료 정보 저장 배열
    int ingredientCnt = 0; // 접시에 담긴 재료 개수 저장

    FoodType foodtype;
    public int MaximumIngredient = 5; // 접시에 담을 수 있는 최대 재료
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

    private void Update() // 테스트용. 나중에 삭제
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            IngredientTest();
        }

    }
    void IngredientTest()
    {
        string temp = "";
        temp += "접시에 있는 음식들 : ";
        for (int i = 0; i < ingredientCnt; i++)
        {
            temp += "[" + i + "] " + ingredient[i] + "  ";
        }
        Debug.Log(temp);

    }
}