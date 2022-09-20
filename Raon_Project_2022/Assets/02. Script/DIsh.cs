using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    string[] ingredient = new string[5]; // 접시에 담긴 재료 정보 저장 배열
    int ingredientCnt = 0; // 접시에 담긴 재료 개수 저장

    FoodType foodtype;
    public int MaximumIngredient = 5; // 접시에 담을 수 있는 최대 재료
    float foodHeight = 0f;

    void Start()
    {
        foodHeight = 0.25f;
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
    private void OnCollisionEnter(Collision collision)
    {

    }


    private void Update()
    {
        Debug.Log("foodHeight = " + foodHeight);
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