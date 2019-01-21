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
        public NavMeshAgent agent;
       public  Material mat;
        bool allowedToWalk = false;
        public float playerDistanceToPoint;
        //public GameObject beforePortal;


        void Start()
        {
            mat.SetFloat("_Blend", 0);
            playerDistanceToPoint = 0;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            agent = GetComponent<NavMeshAgent>();
            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point). 
            //agent.autoBraking = false;
            Screen.fullScreen = true;

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
                
                /*if(destPoint == 6)
                {
                    beforePortal.SetActive(false);
                }*/
                //Queues[destPoint - 2].SetActive(false);
            }
            

        }


        void Update()
        {
            
            playerDistanceToPoint = Vector3.Distance(transform.position, points[9].position);
                
            if (destPoint > 10)
            {
                
                mat.SetFloat("_Blend", (playerDistanceToPoint/1000));
            }
            


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
        public void cheapAss()
        {
            foreach (Transform child in points)
            {
                SetActiveAllChildren(child, true);
            }
        }
    }
}