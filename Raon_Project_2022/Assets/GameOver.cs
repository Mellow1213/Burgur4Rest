using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class GameOver : MonoBehaviour
{
    float timer = 30f;
    int tax = 5;
    public Image Panel;
    public TextMeshProUGUI text;
    void Update()
    {
        text.text = tax + "원 / 30s";
        timer += Time.deltaTime;
        if (timer >= 30f)
        {
            timer = 0f;
            GameManager.instance.myGold -= tax;
            tax += Random.Range(1, 3);
            if (GameManager.instance.myGold < 0)
                StartCoroutine(GameEnd());
        }
    }

    IEnumerator GameEnd()
    {
        Debug.Log("패배");
        Panel.DOFade(1, 2);
        yield return new WaitForSeconds(2f);
        Debug.Log("씬 이동");
    }
}
