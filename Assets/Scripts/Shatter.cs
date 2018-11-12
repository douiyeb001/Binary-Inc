using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shatter : MonoBehaviour {
    public GameObject shatter;
    public int liveSpan = 500;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        liveSpan--;
        if (liveSpan < 0)
        {
            for(int i = 0; i < 300; i++)
            {
                Instantiate(shatter, gameObject.transform.position, gameObject.transform.rotation);
            }
            
            Destroy(gameObject);
        }
    }
}
