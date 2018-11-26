using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace VRStandardAssets.Utils
{

    public class UpdatedMovement : MonoBehaviour
    {

        public Transform[] points;
        public GameObject[] Queues;
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


        }


        void GotoNextPoint()
        {
            agent.isStopped = false;
            this.gameObject.GetComponentInChildren<VREyeRaycaster>().enabled = false;
       

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
            if (destPoint < points.Length-1)
            {
                destPoint++;
                Debug.Log(destPoint);
                //Queues[destPoint - 2].SetActive(false);
            }
            

        }


        void Update()
        {
           
            if (!agent.pathPending && agent.remainingDistance < 0.5f && agent.isStopped == false && !allowedToWalk )
            {
                this.gameObject.GetComponentInChildren<VREyeRaycaster>().enabled = true;

                Debug.Log("Turn script on");
                agent.isStopped = true;
                allowedToWalk = false;
                SetActiveAllChildren(points[destPoint], true);

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GotoNextPoint();
            }
            // Choose the next destination point when the agent gets
            // close to the current one.

        }
        public void TurnOnWalk()
        {
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
}