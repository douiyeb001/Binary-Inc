using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class MovementVR : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    public NavMeshAgent agent;

    public float remainDistance = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        GotoNextPoint();    
    }


    public void GotoNextPoint()
    {
        agent.isStopped = false;
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
       
            Debug.Log("ABCD");
            SetActiveAllChildren(points[destPoint], true);

                 
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    
    }

      void Update()
    {
        remainDistance = agent.remainingDistance;
        // Choose the next destination point when the agent gets
        // close to the current one.
        // agent.isStopped = true;

        if (!agent.pathPending && agent.remainingDistance < 0.5f && agent.isStopped == false)
        {
            agent.isStopped = true;

        }


    }
    public void TurnOnWalk()
    {
        agent.isStopped = false;
        GotoNextPoint();

    }
  
    private void SetActiveAllChildren(Transform points, bool value)
    {
        foreach (Transform child in points)
        {
            child.gameObject.SetActive(value);
            SetActiveAllChildren(child, value);
        }
    }
}