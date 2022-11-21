using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Test : MonoBehaviour
{
    string[] food_ingredient = new string[10];
    [SerializeField] Dish_Burger dish_burger = null;
    [SerializeField] Customer_Status _customer_status = null;
    [SerializeField] GameObject customer = null;

    CustomerMove _customerMove = null;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dish"))
        {
            dish_burger = other.GetComponent<Dish_Burger>();

            if (dish_burger)
            {
                food_ingredient = dish_burger.GetIngredient();


                for (int i = 0; i < dish_burger.GetIngredientCnt(); i++)
                {
                    if (food_ingredient[i] == _customer_status.goodIngredient)
                    {
                        Debug.Log("ȣ�� �ܹ���");
                    }
                    if (food_ingredient[i] == _customer_status.badIngredient)
                    {
                        Debug.Log("��ȣ�� �ܹ���");
                        Debug.Log("�մ��� ���� ������ �϶��մϴ�.");
                    }
                }

                if (food_ingredient[0] != "bread-down" || food_ingredient[dish_burger.GetIngredientCnt() - 1] != "bread-top")
                {
                    Debug.Log("�߸��� �ܹ���!");
                    Debug.Log("Ư�� ���� �մ��� �����ϰ� ���� ������ ũ�� �϶��մϴ�.");
                }
                else
                {
                    Debug.Log("�˸��� ������ �ܹ���!");
                }

                Destroy(other.transform.parent.gameObject);

                _customerMove.GoOut();
                GameManager.instance.myGold += 100;
                GameManager.instance.CalRate(Random.Range(5, 10));
            }
        }

        if (other.CompareTag("Customer"))
        {
            customer = other.gameObject;
            _customer_status = customer.GetComponent<Customer_Status>();
            _customerMove = customer.GetComponent<CustomerMove>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            customer = null;
            _customer_status = null;
            _customerMove = null;
        }
    }
}
