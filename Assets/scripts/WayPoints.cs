using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPoints : MonoBehaviour {

    NavMeshAgent agent;
    // list or array of points- starts at number 0
    public GameObject waypoints;
    Transform[] points;
    public int destPoint = 0;

	// Use this for initialization
	void Start () {
        points = waypoints.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
        //can turn off autobraking to not stop between waypoints
        agent.autoBraking = false;
        GoToNextPoint ();
	}

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        agent.SetDestination(points[destPoint].position);
        //if it goes any hight than the total number of waypoints -> go back to the start array
        destPoint = (destPoint + 1) % points.Length;
    }

	// Update is called once per frame
	void Update () {
        if (agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
	}
}
