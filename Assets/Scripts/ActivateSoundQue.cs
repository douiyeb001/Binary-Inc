using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSoundQue : MonoBehaviour {
    // Use this for initialization
    bool play = true;
	void Start () {
	}
	
    private void OnTriggerEnter(Collider other)
    {
        if (play)
        {
            GetComponent<AudioSource>().Play();
            play = false;
        }
        
    }
}
