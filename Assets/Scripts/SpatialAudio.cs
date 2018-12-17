﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialAudio : MonoBehaviour {

    public Transform player;
    public Camera cam;
    public float volume;
    public float difference;
    float constant = 5;
    float maxVolume,minVolume,audioVolume;
    public float rot;
    float x, z;
    float cheapX, cheapZ;
    public float angle,cheapAngle;
    public float angleDifference;
    bool inView = false;

	// Use this for initialization
	void Start () {
		
        maxVolume = .15f;
        minVolume = .03f;
        audioVolume=.15f;
        GetComponent<AudioSource>().spatialBlend = 0;
    }

    // Update is called once per frame
    void Update () {
        
     
        difference = Vector3.Distance(transform.position, player.position);
        if (difference<0)
            difference = difference*-1;
        if (maxVolume> constant / difference)
        {
            GetComponent<AudioSource>().volume = constant / difference;
        }
        else
        {
            GetComponent<AudioSource>().volume = audioVolume;
        }

        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (viewPos.x>0 && viewPos.x < 1)
        {
            inView = true;
            float convertViewPos = (viewPos.x *2)-1;
            GetComponent<AudioSource>().panStereo = convertViewPos;
        }
        else
        {
            GetComponent<AudioSource>().panStereo = 0;
            inView = false;
        }
        if (inView && maxVolume >= GetComponent<AudioSource>().volume)
        {
            audioVolume += .002f;
        }
        if (!inView && minVolume <= GetComponent<AudioSource>().volume) 
        {
            audioVolume -= .002f;
        }
        GetComponent<AudioSource>().volume = audioVolume;



    }
}
