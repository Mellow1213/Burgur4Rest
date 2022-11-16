using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMeat : MonoBehaviour
{
    public GameObject cookedPrefab;
    float timer = 0;
    public bool isCooking = false;
    // Update is called once per frame
    void Update()
    {
        Debug.Log("timer = " + timer);
        if (isCooking)
            timer += Time.deltaTime;

        if (timer > 10)
        {
            Debug.Log("�丮 ��");
            Instantiate(cookedPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Grill"))
            isCooking = true;
    }
}
