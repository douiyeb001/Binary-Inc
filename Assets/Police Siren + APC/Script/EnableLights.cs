using UnityEngine;
using System.Collections;

public class EnableLights : MonoBehaviour {

	private Light myLight;
	// Use this for initialization
	void Start () {
	
		myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.P ))
		{
			myLight.enabled = !myLight.enabled;
		}
	
	}
}
