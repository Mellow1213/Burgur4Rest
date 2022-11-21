using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMove : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    [Tooltip("Index 0은 카운터, Index 1은 출구, 나머지는 각 테이블 위치임.")]
    PosManager _posMananger;
    public Transform[] destinations;


    public float patience = 30f;
    bool doTimer = false;
    bool acceptedOrder = false;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.destination = destinations[0].position;
        _posMananger = GameObject.Find("").GetComponent<PosManager>();
        destinations = _posMananger.positions;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(destinations[1]);
        Debug.Log(destinations[4]);
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
            patience += 20;
            acceptedOrder = true;
            ChangeDestination(2);
        }
    }

    void WaitingTime()
    {
        if(doTimer)
            patience -= Time.deltaTime;
        //Debug.Log(patience);
        if(patience <= 0)
        {
            ChangeDestination(1);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StandPosition"))
        {
            doTimer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StandPosition"))
        {
            doTimer = false;
        }
    }
}
