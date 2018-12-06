using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPointTravel : MonoBehaviour {
    public GameObject testPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position =  Vector3.MoveTowards(gameObject.transform.position,testPoint.transform.position,0.1f);	
	}
}
