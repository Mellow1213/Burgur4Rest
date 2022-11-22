using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    float timer = 0f;
    float coolTime;
    public GameObject customer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        coolTime = 50f * (1.2f - GameManager.instance.myRate);
        if (timer > coolTime)
        {
            timer = 0f;
            Instantiate(customer, transform.position, transform.rotation);
        }
    }
}
