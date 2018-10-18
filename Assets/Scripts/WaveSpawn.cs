using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour {
    public GameObject wave;
    private Transform tf;
    private int timer =0;
    public int spawnTimer;
	// Use this for initialization
	void Start () {

        tf = gameObject.transform;
        //tf.rotation = wave.transform.rotation;
        tf.position = tf.position + new Vector3(0, 4.9f, 0);
        tf.localScale = wave.transform.localScale;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("space"))
        {
            Instantiate(wave, gameObject.transform);
        }
        
        
    }
    void FixedUpdate()
    {
        timer--;
        if (timer < 0)
        {
            Instantiate(wave, tf);
            timer = spawnTimer;
        }
    }
}
