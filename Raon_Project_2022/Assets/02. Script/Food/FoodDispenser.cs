using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDispenser : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    public Transform spawnPos;
    public int cost;
    public void SpawnPrefab()
    {
        Instantiate(foodPrefab, spawnPos.transform.position, spawnPos.transform.rotation);
        GameManager.instance.myGold -= cost;
    }
}
