﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBoxSpawn : MonoBehaviour {
    public GameObject box;
    int liveSpan;
    Transform tf;
	// Use this for initialization
	void Start () {
        liveSpan = Random.Range(200,400);
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        liveSpan--;
        if (liveSpan < 0)
        {
            Instantiate(box,transform.position+ new Vector3(0, 4, 0),transform.rotation);
            liveSpan = 400;
        }
	}
}
