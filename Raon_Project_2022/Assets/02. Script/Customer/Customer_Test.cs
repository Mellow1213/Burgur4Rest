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

    public OrderPanel _orderPanel;
    public bool isSet = false;

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
                        _customer_status.star *= Random.Range(1f, 1.05f);
                        Debug.Log("주문재료 제출");
                    }
                    if (food_ingredient[i] == _customer_status.badIngredient)
                    {
                        _customer_status.money -= 15;
                        _customer_status.star *= Random.Range(0.85f, 0.95f);
                        Debug.Log("기피재료 제출");
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
            isSet = true;
            _boxCollider.enabled = true;
            _meshRenderer.enabled = true;
            _customerMove.doTimer = true;
            _orderPanel.SetText("주문재료 : " + ReturnTranslate(_customer_status.goodIngredient) + "\n기피재료 : " + ReturnTranslate(_customer_status.badIngredient));
        }
    }

    string ReturnTranslate(string str)
    {
        if (str == "bread-top")         return "빵(상단)";
        else if (str == "bread-down")   return "빵(하단)";
        else if (str == "alface")       return "양상추";
        else if (str == "chesse")       return "치즈";
        else if (str == "ham-baked")    return "요리된 패티";
        else if (str == "ham-burnt")    return "타버린 패티";
        else if (str == "ham-raw")      return "안익은 패티";
        else if (str == "onion")        return "양파";
        else if (str == "tomato")       return "토마토";

        return "존재하지 않는 재료";
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
            isSet = false;
            _orderPanel.SetText("");
        }
    }
}
