using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    float timer = 30f;
    int tax = 5;
    public Image Panel;
    public TextMeshProUGUI text;
    void Update()
    {
        text.text = (30-timer).ToString("F0") + "s 후 " + tax + "원";
        timer += Time.deltaTime;
        if (timer >= 30f)
        {
            timer = 0f;
            GameManager.instance.myGold -= tax;
            tax = Random.Range(5, 15);
            if (GameManager.instance.myGold < 0)
                StartCoroutine(GameEnd());
        }
    }

    IEnumerator GameEnd()
    {
        Debug.Log("패배");
        Panel.DOFade(1, 2);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
