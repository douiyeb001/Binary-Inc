using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    Renderer rend;

    public float normalizedTime = 0;
    float negativeNormalizedTime = .9f;
    public int liveSpan = 800;
    float timer = 10f;


    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Custom/DissolveInOut");

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        transform.position = transform.position + new Vector3(Random.Range(-30, 30), 0, Random.Range(-30, 30));
    }

    void FixedUpdate()
    {
        normalizedTime += Time.deltaTime / timer;
        negativeNormalizedTime -= (Time.deltaTime / timer) + 0.002f;
        rend.material.SetFloat("_SliceAmount", negativeNormalizedTime);
       
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
