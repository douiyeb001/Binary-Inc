using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTiles : MonoBehaviour {
    public GameObject tile;
    public int timer;
    int spawnTimer;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < 20; i++)
        {
            Instantiate(tile, transform.position, transform.rotation);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
            
          
        
        
	}
    

}
