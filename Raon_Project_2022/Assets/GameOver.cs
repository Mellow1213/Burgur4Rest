using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    float timer = 30f;
    int tax = 10;
    public Image Panel;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            timer = 0f;
            GameManager.instance.myGold -= tax;
            tax += Random.Range(3, 8);
            if (GameManager.instance.myGold < 0)
                StartCoroutine(GameEnd());
        }
    }

    IEnumerator GameEnd()
    {
        Debug.Log("ÆĞ¹è");
        Panel.DOFade(1, 2);
        yield return new WaitForSeconds(2f);
        Debug.Log("¾À ÀÌµ¿");
    }
}
