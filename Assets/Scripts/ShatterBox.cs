using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterBox : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    Renderer rend;

    
    public int liveSpan = 800;
    public float sliceAmount = 0.3f;


    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Custom/DissolveInOut");

        rb = GetComponent<Rigidbody>();
        
        float speedX = Random.Range(-30,30);
        float speedY = Random.Range(-60, 60);
        float speedZ = Random.Range(-30, 30);
        transform.position += new Vector3(speedX, speedY, 0);
        
            rb.AddForce(transform.forward * -speedY * speed);
            rb.AddForce(transform.up * -speedX * (speed/4));
            rb.AddForce(transform.right * -speedZ * speed);
        


        
    }

    void FixedUpdate()
    {
        sliceAmount += .001f;
        rend.material.SetFloat("_SliceAmount", sliceAmount);

        if (sliceAmount > .5)
        {
            Destroy(gameObject);
        }
        

    }
}
