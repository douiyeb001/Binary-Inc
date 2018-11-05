using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSiren : MonoBehaviour {

    [SerializeField] Light redLight;
    [SerializeField] Light blueLight;

    private Vector3 redTemp;
    private Vector3 blueTemp;

    [SerializeField] int speed;
  
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        redTemp.y += speed * Time.deltaTime;
        blueTemp.y -= speed * Time.deltaTime;

        redLight.transform.eulerAngles = redTemp;
        blueLight.transform.eulerAngles = blueTemp;

	}
}
