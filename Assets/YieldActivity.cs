using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YieldActivity : MonoBehaviour {
    public GameObject holderLook1;
	// Use this for initialization
	void Start () {
        StartCoroutine(DelayActivity());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator DelayActivity()
    {
        yield return new WaitForSecondsRealtime(20);
        holderLook1.SetActive(true);
    }  
}
