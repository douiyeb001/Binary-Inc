using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRings : MonoBehaviour {
    public GameObject[] ring;
    public GameObject sphere;
    public GameObject reveal;
    public GameObject LevelReset;
    public GameObject P0;
    int liveSpan = 60;
    int liveSpanTime = 60;
    int current = 0;
    public bool active = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (active)
        {
            liveSpan--;
            if (liveSpan < 0 && current <= ring.Length - 1)
            {
                ring[current].SetActive(false);
                liveSpan = liveSpanTime;
                current++;
            }
            else if (current == ring.Length)
            {
                reveal.GetComponent<RevealGlass>().enabled = true;
                sphere.GetComponent<TriggerDome>().on = true;
                P0.SetActive(true);
                LevelReset.SetActive(true);
                Destroy(gameObject);
            }
        }
	}
    
}
