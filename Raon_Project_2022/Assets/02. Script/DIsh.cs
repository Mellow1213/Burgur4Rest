using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    string[] ingredient = new string[10]; // 접시에 담긴 재료 정보 저장 배열 -> 최대 재료 10개
    int ingredientCnt = 0; // 접시에 담긴 재료 개수 저장

    float foodHeight;
    FoodType foodtype;

    void Start()
    {
        foodHeight = 0.1f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            other.transform.parent = gameObject.transform.parent;
            foodtype = other.GetComponent<FoodType>();

            Vector3 foodPos = new Vector3(0, foodHeight, 0);
            foodHeight += 0.1f;
            GameObject temp = Instantiate(foodtype.platingPrefab, transform.position + foodPos, transform.rotation);
            temp.transform.parent = transform;
            Destroy(other.gameObject);
            ingredientCnt++;

            Debug.Log("음식의 갯수 = " + ingredientCnt);
        }
    }
}