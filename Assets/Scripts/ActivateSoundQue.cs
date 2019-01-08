using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSoundQue : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
    }
}
