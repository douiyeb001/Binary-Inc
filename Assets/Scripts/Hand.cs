using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller))]
public class Hand : MonoBehaviour {

    GameObject heldObject;
    Controller controller;
    private SteamVR_TrackedObject trackedObj;

    private bool throwing;
    private Rigidbody rigidbodyObject;
    

	// Use this for initialization
	void Start () {
        controller = GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        if (heldObject)
        {
            
            if (controller.controller.GetPressUp(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                heldObject.transform.parent = null;
                heldObject.GetComponent<Rigidbody>().isKinematic = false;
                heldObject.GetComponent<HeldObject>().parent = null;
                heldObject = null;
                throwing = true;
            }
        }
        else
        {
            if (controller.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);

                foreach (Collider col in cols)
                {
                    if (heldObject == null && col.GetComponent<HeldObject>() && col.GetComponent<HeldObject>().parent == null)
                    {
                        heldObject = col.gameObject;
                        heldObject.transform.parent = transform;
                        //heldObject.transform.localPosition = new Vector3(0.05f,0,0.05f);
                        //heldObject.transform.localRotation = Quaternion.identity;
                        heldObject.GetComponent<Rigidbody>().isKinematic = true;
                        heldObject.GetComponent<HeldObject>().parent = controller;
                        if (!heldObject.CompareTag("Record"))
                            heldObject.GetComponent<AudioSource>().mute = false;
                        throwing = false;
                    }
                }
            }
        }
	}
    void FixedUpdate()
    {
        if (throwing)
        {
            Transform origin;
            Rigidbody rigidbody = heldObject.GetComponent<Rigidbody>();
            if (trackedObj.origin != null)
            {
                origin = trackedObj.origin;
            }
            else
            {
                origin = trackedObj.transform.parent;
            }

            if (origin != null)
            {
                rigidbody.velocity = origin.TransformVector(controller.controller.velocity);
                rigidbody.angularVelocity = origin.TransformVector(controller.controller.angularVelocity * 0.25f);
            }
            else
            {
                rigidbody.velocity = controller.controller.velocity;
                rigidbody.angularVelocity = controller.controller.angularVelocity * 0.25f;

            }

            rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;

            throwing = false;
        }
    }
}
