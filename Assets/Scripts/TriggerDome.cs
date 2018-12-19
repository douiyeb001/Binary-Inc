using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDome : MonoBehaviour {

    public float myDome = 0;
    Renderer mat;
    bool on;
     void Start()
    {
        mat = GetComponentInChildren<Renderer>();
    }
    // Update is called once per frame
    void FixedUpdate () {
        if(Input.GetKey(KeyCode.Space)){
            on = true;
        }
        if (on)
        {
            myDome += 0.002f;
        }

        mat.material.SetFloat("_DissolveScale", myDome);
    }
    void SetDissolveOn()
    {
        on = true;
    }
}
