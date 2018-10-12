using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;

    Controller controller;
    private SteamVR_TrackedObject trackedObj;

    public GameObject picku;
    private GameObject obj;
    private FixedJoint fJoint;

    private bool throwing;
    private Rigidbody rigidbody;

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        fJoint = GetComponent<FixedJoint>();
    }

    void Update()
    {
        if (controller == null)
        {
            Debug.Log("Controller not initialized" );
            return;
        }
        

        if (controller.controller.GetPressDown(triggerButton))
        {
            PickUpObj();
        }

        if (controller.controller.GetPressUp(triggerButton))
        {
            DropObj();
        }
    }


    void FixedUpdate()
    {
        if (throwing)
        {
            Transform origin;
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

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            obj = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        obj = null;
    }


    void PickUpObj()
    {
        if (obj != null)
        {
            fJoint.connectedBody = obj.GetComponent<Rigidbody>();

            throwing = false;
            rigidbody = null;
        }
        else
        {
            fJoint.connectedBody = null;
        }
    }

    void DropObj()
    {
        if (fJoint.connectedBody != null)
        {
            rigidbody = fJoint.connectedBody;

		fJoint.connectedBody = null;

            throwing = true;
        }
    }
}
