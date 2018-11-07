using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpdatedMovement : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {

        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point). 
        agent.autoBraking = false; 


        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        agent.isStopped = false;

        if (Vector3.Distance(points[destPoint].transform.position, this.gameObject.transform.position) < 0.5f)
        {
            agent.isStopped = true;

        }
        //agent.isStopped = false;
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;


    }


    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f && agent.isStopped == false)
        {
            agent.isStopped = true;

        }
      
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (Input.GetKeyDown(KeyCode.Space) && agent.isStopped == true)
        {
            destPoint++;
            Debug.Log(destPoint);
            GotoNextPoint();
        }
    }
}