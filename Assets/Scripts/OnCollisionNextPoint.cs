using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRStandardAssets.Utils
{
    public class OnCollisionNextPoint : MonoBehaviour {

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
        private void OnCollisionEnter(Collision collision)
        {

            GetComponent<UpdatedMovement>().TurnOnWalk();
            //GetComponent<UpdatedMovement>().cheapAss();
            collision.gameObject.GetComponent<BoxCollider>().gameObject.SetActive(false);

        }
          
        

    }
}
