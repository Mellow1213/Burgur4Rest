using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    LinkedList<string> IngredientList = new LinkedList<string>();    // 접시에 담긴 재료 저장하는 연결 리스트
    float foodHeight;     // 다음에 복제할 음식 프리팹의 높이 설정 위한 변수
    public FoodManager foodManager;

    void Start()
    {
        foodHeight = 0.1f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            other.transform.parent = gameObject.transform.parent;
            FoodType ingredient = other.GetComponent<FoodType>();

            Vector3 foodPos = new Vector3(0, foodHeight, 0);
            foodHeight += 0.1f;

            GameObject prefab = FoodClassification(other.name);
            Debug.Log("prefab = " + prefab);
            GameObject temp = Instantiate(prefab, transform.parent.position + foodPos, prefab.transform.rotation);
            temp.transform.parent = transform.parent;
            Destroy(other.gameObject);

            IngredientList.AddLast(ingredient.IngredientName);
            Debug.Log(ingredient.IngredientName);
            Debug.Log("음식의 갯수 = " + IngredientList.Count);
        }
    }

    GameObject FoodClassification(string name)
    {
        GameObject prefab;
        switch (name) {
            case "Food1":
                prefab = foodManager.foodPrefabs[0].gameObject;
                break;
            case "Food2":
                prefab = foodManager.foodPrefabs[1].gameObject;
                break;
            case "Food3":
                prefab = foodManager.foodPrefabs[2].gameObject;
                break;
            case "Food4":
                prefab = foodManager.foodPrefabs[3].gameObject;
                break;
        }
        return prefab;

    }
    
}