using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class asd : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(GoMenu());   
    }

    IEnumerator GoMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
