using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHologram : MonoBehaviour {
    GameObject player;
    public Vector3 dot;
    Rigidbody rb;
    float forceStrength = 1f;
    float distance = 13;
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
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        dot = transform.position - player.transform.position;
        if (distanceToPlayer < distance)
        {
            rb.AddForce(dot * forceStrength);
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
