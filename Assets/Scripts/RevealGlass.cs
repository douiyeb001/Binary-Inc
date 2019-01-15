using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealGlass : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position +=  new Vector3(0,.1f,0);
        if(transform.position.y>120)
            Destroy(gameObject);
	}
}
