using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnd : MonoBehaviour {
    public GameObject endSpray;
    bool played = false;
    bool end = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(GetComponent<AudioSource>().isPlaying)
            played = true;
        if (!GetComponent<AudioSource>().isPlaying && played && end)
        {
            endSpray.SetActive(true);
            end = false;
        }
              
	}
}
