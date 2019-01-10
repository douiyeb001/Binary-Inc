using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRStandardAssets.Utils
{
    public class WalkByActivateMovement : MonoBehaviour {
        GameObject player;
        public GameObject TurnOffAfterPoint;
        public GameObject TurnOnAfterPoint;
        public int walkByTimer = 0;
        public bool walkBy = true;
        bool turnOff = true;
        bool turnOn = true;
        // Use this for initialization
        void Start() {
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update() {
            if(walkBy)
                walkByTimer--;

            if (walkByTimer<0 && walkBy)
            {
                player.GetComponent<UpdatedMovement>().TurnOnWalk();
                walkBy = false;
            }

            if(TurnOffAfterPoint != null && turnOff)
            {
                TurnOffAfterPoint.SetActive(false);
                turnOff = false;
            }
            if (TurnOnAfterPoint != null && turnOn)
            {
                TurnOnAfterPoint.SetActive(false);
                turnOn = false;
            }
        }
    }
}