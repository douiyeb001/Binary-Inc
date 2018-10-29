using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxSpawner : MonoBehaviour {

    public GameObject[] box;
        
    private Transform tf;
	// Use this for initialization
	void Start () {
        tf = gameObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        
        Instantiate(box[Random.Range(0,2)], tf);
    }
}
