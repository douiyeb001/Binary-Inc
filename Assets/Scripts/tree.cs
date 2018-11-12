using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour {
    public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
            Instantiate(obj, transform);
        
        
	}
}
