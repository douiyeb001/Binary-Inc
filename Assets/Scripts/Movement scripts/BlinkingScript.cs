using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingScript : MonoBehaviour {
    private int frame;
     public Image img;
	// Use this for initialization
	void Start () {
        img = FindObjectOfType<Image>();
        img.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        frame++;
        if (frame ==  90)
        {
            img.enabled = true;
            frame = 0;
        }
        else img.enabled = false;
	}
}
