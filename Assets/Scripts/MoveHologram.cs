using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHologram : MonoBehaviour {
    GameObject player;
    public Vector3 dott;
    Rigidbody rb;
    float forceStrength = 2f;
    float speed = 5;
    Vector3 pos;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //rb.AddForce(-transform.forward * forceStrength);
        float dis = Vector3.Distance(transform.position, player.transform.position);
        dott = transform.position - player.transform.position;
        if (dis < 13)
        {
            rb.AddForce(dott * forceStrength);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            float step = speed * Time.deltaTime;
            
            transform.position = Vector3.MoveTowards(transform.position, pos, step);
        }
	}
}
