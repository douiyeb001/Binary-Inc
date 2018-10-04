using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    [RequireComponent(typeof(Controller))]
    public class RotateHandle : MonoBehaviour
    {

        GameObject rotateObject;
        Controller controller;

        // Use this for initialization
        void Start()
        {
            controller = GetComponent<Controller>();
        }

        // Update is called once per frame
        void Update()
        {
            if (rotateObject)
            {
                if (controller.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
                {
                    rotateObject.transform.parent = null;
                    rotateObject.GetComponent<Rigidbody>().isKinematic = false;
                    rotateObject.GetComponent<RotateObject>().parent = null;
                    rotateObject = null;
                    //GameObject.Find("pickUp").GetComponent<AudioSource>().mute = true;
                    //heldObject.GetComponent<AudioSource>().mute = true;
                }
            }
            else
            {
                if (controller.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
                {
                    Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);

                    foreach (Collider col in cols)
                    {
                        if (rotateObject == null && col.GetComponent<RotateObject>() && col.GetComponent<RotateObject>().parent == null)
                        {
                            rotateObject = col.gameObject;
                            
                            rotateObject.transform.eulerAngles = new Vector3(0, 10f, 0);
                           
                               
                            //rotateObject.transform.localPosition = Vector3.zero;
                            //rotateObject.transform.localRotation = Quaternion.identity;
                            rotateObject.GetComponent<Rigidbody>().isKinematic = true;
                            rotateObject.GetComponent<RotateObject>().parent = controller;
                            //rotateObject.GetComponent<AudioSource>().mute = false;
                        }
                    }
                }
            }
        }
    }

