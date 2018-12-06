using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMultipleLights : MonoBehaviour {

    public GameObject[] box;
    // Use this for initialization
    void Start()
    {
        for(int i = 0; i < 50; i++)
        {
            Instantiate(box[Random.Range(0, box.Length)], gameObject.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {

        
    }
}
