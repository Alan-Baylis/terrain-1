using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyNavMovement : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;

    void Start()
    {
        var playerGo = GameObject.FindGameObjectWithTag("Player");
        target = playerGo.transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }

        // agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
        if (agent.remainingDistance < (agent.stoppingDistance + 0.5f))
        {
            transform.LookAt(target.transform);
        }
    }
}