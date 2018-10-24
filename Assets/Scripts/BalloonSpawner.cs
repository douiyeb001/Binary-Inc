using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour {

    public GameObject balloon;

    private Transform tf;
    // Use this for initialization
    void Start()
    {
        tf = gameObject.transform;
        for (int i = 0; i < 500; i++)
        {
            Instantiate(balloon, tf);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

        //Instantiate(balloon[Random.Range(0, 2)], tf);
    }
}
