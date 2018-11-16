using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour {

    public GameObject obj;
    int spawnTimer;
    int constant = 5;
    // Use this for initialization
    void Start()
    {
        spawnTimer = constant;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnTimer--;
        if (spawnTimer < 0)
        {
            Instantiate(obj, transform);
            spawnTimer = constant;
        }
    }
}
