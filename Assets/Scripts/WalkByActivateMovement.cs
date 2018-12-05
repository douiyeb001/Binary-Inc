using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRStandardAssets.Utils
{
    public class WalkByActivateMovement : MonoBehaviour {
        GameObject player;
        public int walkByTimer = 0;
        bool walkBy = true;
        // Use this for initialization
        void Start() {
            player = GameObject.Find("Player");
        }

        // Update is called once per frame
        void Update() {
            walkByTimer--;
            if (walkByTimer<0&&walkBy)
            {
                player.GetComponent<UpdatedMovement>().TurnOnWalk();
                walkBy = false;
            }

        }
    }
}