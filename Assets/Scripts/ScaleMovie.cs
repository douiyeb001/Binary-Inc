﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleMovie : MonoBehaviour {
    float x, y, z;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(transform.localScale.x< 1.52)
        {
            x += .00017f;
            y += .0001f;
            z += .0001f;
            transform.localScale += new Vector3(x, y, z);
        }
        
	}
}
