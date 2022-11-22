using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingMeat : MonoBehaviour
{
    AudioSource _audioSource;
    public GameObject cookedPrefab;
    float timer = 0;
    public bool isCooking = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("timer = " + timer);
        if (isCooking)
        {
            timer += Time.deltaTime;
            if(!_audioSource.isPlaying)
                _audioSource.Play();
        }
        else
        {
            if (_audioSource.isPlaying)
            {
                _audioSource.Pause();
            }
        }

        if (timer > 10)
        {
            Debug.Log("¿ä¸® µÊ");
            Instantiate(cookedPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Grill"))
        {
            isCooking = true;
        }
    }
}
