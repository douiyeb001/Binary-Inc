using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLights : MonoBehaviour {

    public float speed;

    private Rigidbody rb;
    Renderer rend;
    public int liveSpan;
    int liveSpanTimer;
    int resetLiveSpan = 100;
    float rotateX, rotateY, rotateZ;
    public float alphaTimer = 1;
    public float sliceAmount = .216f;
    public bool alphaColorChange = true;
    public bool sliceColorChange = true;


    void Start()
    {
        liveSpanTimer = Random.Range(0, 300);
        liveSpan = liveSpanTimer;
        rend = GetComponent<Renderer>();
        rotateX = Random.Range(-5, 5);
        rotateY = Random.Range(-5, 5);
        rotateZ = Random.Range(-5, 5);

        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * speed);
        transform.position = transform.position + new Vector3(Random.Range(-50, 50), Random.Range(-40, 40),Random.Range(-10, 10));
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(rotateX,rotateY,rotateZ));
        //Debug.Log(rend.name);
        liveSpan--;
        rend.material.SetFloat("_Alpha", alphaTimer);
        rend.material.SetFloat("_SliceAmount", sliceAmount);
        
        //if it has alphaColor
        if (liveSpan < 0 && alphaColorChange == true)
        {
            alphaTimer -= .02f;
        }
        if (liveSpan < 0 && alphaColorChange == false)
        {
            alphaTimer += .02f;
        }
        if (alphaTimer <= 0 && alphaColorChange == true)
        {
            liveSpan = resetLiveSpan;
            alphaColorChange = false;
        }
        if (alphaTimer >= 1 && alphaColorChange == false)
        {
            liveSpan = resetLiveSpan;
            alphaColorChange = true;
        }
        //if it has sliceAmount
        if (liveSpan < 0 && sliceColorChange == true)
        {
            sliceAmount += .02f;
        }
        if (liveSpan < 0 && sliceColorChange == false)
        {
            sliceAmount -= .02f;
        }
        if (sliceAmount > 1 && sliceColorChange == true)
        {
            liveSpan = resetLiveSpan;
            sliceColorChange = false;
        }
        if (sliceAmount <= 0.216f && sliceColorChange == false)
        {
            liveSpan = resetLiveSpan;
            sliceColorChange = true;
        }

    }
}
