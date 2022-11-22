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
        if(GameManager.instance.myRate != 0)
        {
            coolTime = 100f / GameManager.instance.myRate;
        }
        else
        {
            coolTime = 20f;
        }
        Debug.Log("¼Õ´Ô ÄðÅ¸ÀÓ = " + coolTime);
        if (timer > coolTime)
        {
            timer = 0f;
            Instantiate(customer, transform.position, transform.rotation);
        }
    }
}
