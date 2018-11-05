using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dots : MonoBehaviour {
    public float difference;
    public float x;
    float speed = 0.01f;
    float turnSpeed = 1;
	// Use this for initialization
	void Start() {
        x = gameObject.transform.position.x;
        gameObject.transform.position += new Vector3(Random.Range(-0.25f,0.25f),0,0);

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        difference = x - gameObject.transform.position.x;
        transform.position += new Vector3(speed, 0, 0);
        if (difference <-0.3&& speed>0)
        {
            speed = speed * -turnSpeed;
        }
        if (difference > 0.3 && speed < 0)
        {
            speed = speed * -turnSpeed;
        }
        


    }
}
