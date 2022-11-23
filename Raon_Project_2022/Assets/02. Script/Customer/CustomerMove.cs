using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class CustomerMove : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    [Tooltip("Index 0은 카운터, Index 1은 출구, 나머지는 각 테이블 위치임.")]
    PosManager _posMananger;
    Transform[] destinations = new Transform[14];

    Renderer _renderer;

    AudioSource _audioSource;
    public AudioClip outSound;
    public AudioClip orderSound;


    public float patience = 45f;
    public bool doTimer = true;
    bool acceptedOrder = false;

    int CurrentIndex;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _audioSource = GetComponent<AudioSource>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _posMananger = GameObject.Find("Pos").GetComponent<PosManager>();
        destinations = _posMananger.positions;
        _navMeshAgent.destination = destinations[0].position;

    }

    // Update is called once per frame
    void Update()
    {
        WaitingTime();
    }

    public void ChangeDestination(int index)
    {
        _navMeshAgent.destination = destinations[index].position;
    }

    public void TableDestination()
    {
        if (!acceptedOrder)
        {
            doTimer = false;
            if (_posMananger.IsFull())
            {
                Debug.Log("자리 X");
            }
            else
            {
                ChangeDestination(_posMananger.getIndex());
                CurrentIndex = _posMananger.getIndex();
                _posMananger.SeatOn(CurrentIndex);
                patience += 40;
                acceptedOrder = true;
            }
        }
    }

    bool loseStar = true;
    public void GoOut()
    {
        ChangeDestination(1);
        doTimer = false;
        _posMananger.SeatOff(CurrentIndex);
        if (loseStar)
        {
            loseStar = false;
            if (patience >= 1)
            {
                _audioSource.PlayOneShot(outSound);
            }
            else
                GameManager.instance.myRate *= 0.95f;
        }
    }

    void WaitingTime()
    {
        if (doTimer)
            patience -= Time.deltaTime;
        //Debug.Log(patience);

        if(patience >= 30)
        {
            _renderer.material.DOColor(Color.green, 2f);
        }
        else if(patience < 30 && patience > 12)
        {
            _renderer.material.DOColor(Color.yellow, 2f);
        }
        else
        {
            _renderer.material.DOColor(Color.red, 2f);
        }

        if (patience <= 0)
        {
            GoOut();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StandPosition"))
        {
            _audioSource.PlayOneShot(orderSound);
        }

        if (other.name == "Pos_exit")
        {
            Destroy(gameObject);
        }
    }
}
