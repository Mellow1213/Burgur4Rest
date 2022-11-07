using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCount : MonoBehaviour
{
    public Text timerUI;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timerUI.GetComponent<Text>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerUI.text = timer.ToString();
    }
}
