using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace VRStandardAssets.Utils
{

    public class UpdatedMovement : MonoBehaviour
    {

        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;
        bool allowedToWalk = false;


        void Start()
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point). 
            //agent.autoBraking = false;


           //    GotoNextPoint();
        }


        void GotoNextPoint()
        {
            agent.isStopped = false;
            this.gameObject.GetComponentInChildren<VREyeRaycaster>().enabled = false;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
       

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
            if (!agent.pathPending && agent.remainingDistance < 0.5f && agent.isStopped == false && !allowedToWalk )
            {
                agent.isStopped = true;
                this.gameObject.GetComponentInChildren<VREyeRaycaster>().enabled = true;
                this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                allowedToWalk = false;
               


            }

            // Choose the next destination point when the agent gets
            // close to the current one.
            if (agent.isStopped == true && allowedToWalk)
            {
                destPoint++;
                Debug.Log(destPoint);
                GotoNextPoint();
            }
        }
        public void TurnOnWalk()
        {
            allowedToWalk = true;   
        }
    }
}