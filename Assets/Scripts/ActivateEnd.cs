﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnd : MonoBehaviour {
    public GameObject endSpray;
    bool played = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GetComponent<AudioSource>().isPlaying)
            played = true;
        if (!GetComponent<AudioSource>().isPlaying && played)
            endSpray.SetActive(true);  
	}
}
