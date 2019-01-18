using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteText : MonoBehaviour {
    public GameObject brush;
    public Transform[] tf;

    int currentPoint =0;
    float speed = 3f;
    public float distance;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        /*
        if (brush.transform.position.x > tf[3].position.x)
        {
            brush.transform.position += new Vector3(.025f,0,0);
        }
        if (brush.transform.position.x < tf[3].position.x)
        {
            brush.transform.position += new Vector3(.025f, 0, 0);
        }*/
        distance = Vector3.Distance(brush.transform.position, tf[currentPoint].position);

        if (distance < .2)
            currentPoint++;

        brush.transform.position = Vector3.Lerp(brush.transform.position, tf[currentPoint].position, speed * Time.deltaTime);
    }
    



}
