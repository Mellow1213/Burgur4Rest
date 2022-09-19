using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    string[] ingredient = new string[5]; // 접시에 담긴 재료 정보 저장 배열 -> 최대 재료 10개
    int ingredientCnt = 0; // 접시에 담긴 재료 개수 저장

    float foodHeight;
    FoodType foodtype;

    public int MaximumIngredient = 5;

    void Start()
    {
        foodHeight = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            if (ingredientCnt < MaximumIngredient)
            {
                other.transform.parent = gameObject.transform.parent;
                foodtype = other.GetComponent<FoodType>();
                Vector3 foodPos = new Vector3(0, foodHeight, 0);
                foodHeight += 0.1f;
                GameObject temp = Instantiate(foodtype.platingPrefab, transform.position + foodPos, transform.rotation);
                temp.transform.parent = transform;
                Destroy(other.gameObject);
                ingredient[ingredientCnt] = foodtype.food_name;
                ingredientCnt++;
                Debug.Log("음식의 갯수 = " + ingredientCnt);
            }
            else
                Debug.Log("재료를 10개 이상 담을 수 없습니다.");
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("접시에 있는 음식들 : ");
            for (int i = 0; i < ingredientCnt; i++)
            {
                Debug.Log("\n" + ingredient[i]);
            }
        }
    }
}