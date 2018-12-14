using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMovement : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
        if (agent.remainingDistance < (agent.stoppingDistance + 0.5f))
        {
            transform.LookAt(target.transform);
        }
    }
}