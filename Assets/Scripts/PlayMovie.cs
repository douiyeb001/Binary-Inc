using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovie : MonoBehaviour {
    public GameObject obj;
    int liveSpan =120;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        liveSpan--;
        if (liveSpan<0)
        {
            obj.SetActive(true);
        }
	}
}
