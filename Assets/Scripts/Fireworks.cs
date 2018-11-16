using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour {
    
    public float speed;
    public GameObject fireworkExplosion;
    private Rigidbody rb;
   
    public int liveSpan = 800;
    float timer = 10f;


    void Start()
    {
        transform.position = transform.position + new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        
    }

    void FixedUpdate()
    {
        liveSpan--;
        if (liveSpan < 0)
        {
            Instantiate(fireworkExplosion,gameObject.transform.position,fireworkExplosion.transform.rotation);
            Destroy(gameObject);
        }

    }
}
