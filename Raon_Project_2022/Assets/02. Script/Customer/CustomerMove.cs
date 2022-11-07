using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerMove : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    [Tooltip("Index 0은 카운터, Index 1은 출구, 나머지는 각 테이블 위치임.")]
    public Transform[] destinations;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.destination = destinations[0].position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeDestination(int index)
    {
        _navMeshAgent.destination = destinations[index].position;
        GetComponent<BoxCollider>().enabled = false;
    }
}
