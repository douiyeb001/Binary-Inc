using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterBox : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    Renderer rend;
    //public float minX,maxX,minY,maxY,minZ,MaxZ;
    public float x, y, z;
    float rotX, rotY, rotZ;
    
    public int liveSpan = 800;
    public float sliceAmount = 0.3f;


    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Custom/DissolveInOut");

        rb = GetComponent<Rigidbody>();
        rotX = Random.Range(-5f, 5f);
        rotY = Random.Range(-5f, 5f);
        rotZ = Random.Range(-5f, 5f);
        float speedX = Random.Range(0, x);
        float speedY = Random.Range(-y, y);
        float speedZ = Random.Range(-z, z);
        transform.position += new Vector3(speedX, speedY, speedZ);
        
            rb.AddForce(transform.forward * -speedY * speed);
            rb.AddForce(transform.up * -speedX * (speed/4));
            rb.AddForce(transform.right * speedZ * speed);
        


        
    }

    void FixedUpdate()
    {
        //sliceAmount += .001f;
        rend.material.SetFloat("_SliceAmount", sliceAmount);

        if (sliceAmount > .5)
        {
            Destroy(gameObject);
        }
        if (liveSpan < 0)
        {
            Destroy(gameObject);
        }
        //transform.Rotate(x,y,z);
        transform.Rotate(rotX, rotY, rotZ);


    }
}
