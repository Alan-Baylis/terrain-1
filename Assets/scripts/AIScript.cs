using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class AIScript : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject[] points;
    public int destPoint = 0;

    public Transform player;
    public int chaseDistance;
    public int findDistance;

    public enum Behaviours { Patrol, Combat, Heal };
    public Behaviours currBehaviour = Behaviours.Patrol;

    void RunBehaviours()
    {

        switch (currBehaviour)
        {
            case Behaviours.Patrol:
                RunPatrolState();
                break;
            case Behaviours.Combat:
                RunCombatState();
                break;
            case Behaviours.Heal:
                RunHealState();
                break;
        }
    }
    void RunPatrolState()
    {
        if (Vector3.Distance(transform.position, player.position)<findDistance)
        {
            currBehaviour = Behaviours.Combat;
        }
        else if (agent.remainingDistance < 0.5f)
        {
            if (points.Length == 0)
            {
                return;
            }
            agent.SetDestination(points[destPoint].transform.position);
            //if goes higher than the total number of waypoints -> go back to start array
            destPoint = (destPoint + 1) % points.Length;
        }
    }

    void RunCombatState()
    {
        if (Vector3.Distance(transform.position, player.position) > chaseDistance)
        {
            currBehaviour = Behaviours.Patrol;
        }
        else
        {
            agent.SetDestination(player.position);
        }

    }

    void RunHealState()
    {
        agent.SetDestination(healthPoint.position);
        if (agent.remainingDistance < 0.1f)
        {
            currBehaviour = Behaviours.patrol;
        }
    }
}


