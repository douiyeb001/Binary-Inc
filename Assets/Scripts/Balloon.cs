using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {
    public float difference;
    public float y;
    float speed = 0.003f;
    float turnSpeed = 1;
    // Use this for initialization
    void Start () {
        
        transform.position = transform.position +  new Vector3(Random.Range(-30, 30), Random.Range(0,8), Random.Range(-30, 30));
        y = gameObject.transform.position.y;
        gameObject.transform.position += new Vector3(0, Random.Range(-0.25f, 0.25f), 0);
    }
	
	// Update is called once per frame
	void Update () {
        difference = y - gameObject.transform.position.y;
        transform.position += new Vector3(0, speed, 0);
        if (difference < -0.3 && speed > 0)
        {
            speed = speed * -turnSpeed;
        }
        if (difference > 0.3 && speed < 0)
        {
            speed = speed * -turnSpeed;
        }
    }
}
