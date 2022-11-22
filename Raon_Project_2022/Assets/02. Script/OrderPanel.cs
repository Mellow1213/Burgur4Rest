using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderPanel : MonoBehaviour
{
    public TextMeshProUGUI orderText;
    // Start is called before the first frame update
    void Start()
    {
        orderText.text = "";
    }

    public void SetText(string text)
    {
        orderText.text = text;
    }

}
