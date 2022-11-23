using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIScript : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI rateText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "돈 | " + GameManager.instance.myGold;
        rateText.text = "평점 | " + GameManager.instance.myRate.ToString("F3");
    }
}
