using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeParticle : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    public int liveSpan = 500;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * Random.Range(3f, 20f) * speed);
        rb.AddForce(transform.forward * Random.Range(10f, 20f) * speed);
        rb.AddForce(-transform.forward * Random.Range(10f, 20f) * speed);
        rb.AddForce(transform.right * Random.Range(10f, 20f) * speed);
        rb.AddForce(-transform.right * Random.Range(10f, 20f) * speed);

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
