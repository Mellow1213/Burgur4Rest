using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMeat : MonoBehaviour
{
    public GameObject cookedPrefab;
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if(timer > 10)
        {
            Debug.Log("¿ä¸® µÊ");
            Instantiate(cookedPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Grill"))
        {
            timer += Time.deltaTime;
        }
    }
}
