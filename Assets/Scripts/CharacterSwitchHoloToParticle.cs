using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitchHoloToParticle : MonoBehaviour {
    public GameObject charParticle;
	// Use this for initialization
	void Start () {
        //charParticle = GameObject.Find("WalkingCharParticle");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        
        charParticle.SetActive(true);
        gameObject.SetActive(false);
        
    }
}
