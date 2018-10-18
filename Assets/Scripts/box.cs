using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    public int liveSpan = 500;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        transform.position = new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(, 0.0f, 0);


        liveSpan--;
        if (liveSpan < 0)
        {
            Destroy(gameObject);
        }

    }
}
