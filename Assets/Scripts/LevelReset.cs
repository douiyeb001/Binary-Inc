using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelReset : MonoBehaviour {
    private SteamVR_Controller.Device headset { get { return SteamVR_Controller.Input(0); } }
    private Valve.VR.EVRButtonId sensor = Valve.VR.EVRButtonId.k_EButton_ProximitySensor;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (!headset.GetPress(sensor))
        {
            Debug.Log("RESET");
            SceneManager.LoadScene("SPR5Favela");
            
        }
	}
}
