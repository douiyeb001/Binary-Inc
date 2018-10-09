using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceScript : MonoBehaviour {
  public  GameObject[] TheBuildings;
    int arrayCount;
    
	// Use this for initialization
	void Start () {
         TheBuildings = GameObject.FindGameObjectsWithTag("GazeTarget");
        arrayCount = 0;
        foreach (GameObject BD in TheBuildings)
        {
            BD.SetActive(false);
            TheBuildings[arrayCount].SetActive(true);
        }

    }

    // Update is called once per frame
    void Update () {
        if (TheBuildings[arrayCount].GetComponent<AudioSource>().mute == true || TheBuildings[arrayCount].GetComponentInChildren<AudioSource>().mute)

            arrayCount++;
            TheBuildings[arrayCount].SetActive(true);   
        }
		
	}

