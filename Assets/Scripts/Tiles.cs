using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour {
    public float x, y, z,minX,minY,minZ;
    Transform tf;
	// Use this for initialization
	void Start () {
        tf = transform;
        transform.position += new Vector3(Random.Range(minX,x),y, Random.Range(minZ, z));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tile"))
        {
            Debug.Log("collide");
            transform.position = tf.position + new Vector3(Random.Range(minX, x), y, Random.Range(minZ, z));
        }
    }
}
