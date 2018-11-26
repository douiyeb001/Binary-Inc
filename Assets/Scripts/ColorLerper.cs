﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour {

    public float speed = 1.0f;
    public Color startColor;
    public Color middleColor;
    public Color endColor;
    public Color[] _colors;

    float changer = 0f;
    float constant = 0.025f;
    

    public bool repeatable = false;
    float startTime;
    bool flip= false;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (!repeatable)
        {
            //float t = (Time.time - startTime) * speed;

            float scaledTime = startTime * (float)(_colors.Length - 1);
            Color oldColor = _colors[(int)scaledTime];
            Color newColor = _colors[(int)(scaledTime + 1f)];
            float newT = scaledTime - Mathf.Round(scaledTime);

            GetComponent<Renderer>().material.color = Color.Lerp(oldColor, newColor, newT);

            //GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);

        }
        else
        {
            changer += constant;
            float t = (Mathf.Sin(Time.time - startTime) * speed);
            float scaledTime = startTime * (float)(_colors.Length - 1);
            Color oldColor = _colors[(int)scaledTime];
            Color newColor = _colors[(int)(scaledTime + 1f)];
            float newT = scaledTime - Mathf.Round(scaledTime);
            int current = (int)changer;
            if (current >= _colors.Length - 1 && !flip)
            {
                constant = constant * -1;
                changer = current;
                flip = true;
            }
            if (current <= 0 && flip)
            {
                constant = constant * -1;
                changer = current;
                flip = false;
            }


            GetComponent<Renderer>().material.color = Color.Lerp(_colors[current], _colors[current+1], changer-current);
            
            
            Debug.Log(changer);

            //GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
        }
	}
}
