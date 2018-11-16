using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingCharacterParticles : MonoBehaviour {

    int spawnTime;
    int constant = 1;
    public GameObject obj;
	// Use this for initialization
	void Start () {
        spawnTime = constant;
	}
	
	// Update is called once per frame
	void Update () {
        spawnTime--;
        if (spawnTime < 0)
        {
            Instantiate(obj,transform.position,transform.rotation);
            spawnTime = constant;
        }
	}
}
