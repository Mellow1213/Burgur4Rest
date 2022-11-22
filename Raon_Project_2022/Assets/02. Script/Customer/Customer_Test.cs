using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer_Test : MonoBehaviour
{
    string[] food_ingredient = new string[10];
    [SerializeField] Dish_Burger dish_burger = null;
    [SerializeField] Customer_Status _customer_status = null;
    [SerializeField] GameObject customer = null;
    BoxCollider _boxCollider;
    MeshRenderer _meshRenderer;
    CustomerMove _customerMove = null;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

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
                    _customer_status.money += 7;
                    if (food_ingredient[i] == _customer_status.goodIngredient)
                    {
                        _customer_status.money += 5;
                        _customer_status.star *= Random.Range(1f, 1.2f);
                    }
                    if (food_ingredient[i] == _customer_status.badIngredient)
                    {
                        _customer_status.money -= 15;
                        _customer_status.star *= Random.Range(0.85f, 0.95f);
                    }
                }
                if (food_ingredient[0] != "bread-down" || food_ingredient[dish_burger.GetIngredientCnt() - 1] != "bread-top")
                {
                    _customer_status.money = -15;
                    _customer_status.star *= Random.Range(0.85f, 0.90f);
                }
                else
                {
                    _customer_status.star *= Random.Range(1f, 1.05f);
                    Debug.Log("알맞은 형태의 햄버거!");
                }

                Destroy(other.transform.parent.gameObject);

                _customerMove.GoOut();
                GameManager.instance.myGold += _customer_status.money;
                GameManager.instance.myRate *= _customer_status.star;
            }
        }

        if (other.CompareTag("Customer"))
        {
            customer = other.gameObject;
            _customer_status = customer.GetComponent<Customer_Status>();
            _customerMove = customer.GetComponent<CustomerMove>();

            _boxCollider.enabled = true;
            _meshRenderer.enabled = true;
            _customerMove.doTimer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            customer = null;
            _customer_status = null;
            _customerMove = null;
            _boxCollider.enabled = false;
            _meshRenderer.enabled = false;
        }
    }
}
