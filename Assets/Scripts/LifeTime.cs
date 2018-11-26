using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour {


    public int liveSpan = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        liveSpan--;
        if (liveSpan < 0)
        {
            Destroy(gameObject);
        }
    }
}
