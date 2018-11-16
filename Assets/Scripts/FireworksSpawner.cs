using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksSpawner : MonoBehaviour {

    public GameObject fireworks;
    int spawnTimer;
    public int spawnTime;
   
    // Use this for initialization
    void Start()
    {
        spawnTimer = spawnTime;
         Instantiate(fireworks, gameObject.transform);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        spawnTimer--;
        if (spawnTimer < 0)
        {
            Instantiate(fireworks, gameObject.transform);
            spawnTimer = spawnTime;
        }

    }
}
