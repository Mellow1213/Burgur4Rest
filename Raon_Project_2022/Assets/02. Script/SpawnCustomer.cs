using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
    float timer = 0f;
    public GameObject customer;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("��ũ��Ʈ ���� ������Ʈ �̸� : " + gameObject);
        timer += Time.deltaTime;
        if (timer > 10f)
        {
            timer = 0f;
            Instantiate(customer, transform.position, transform.rotation);
        }
    }
}
