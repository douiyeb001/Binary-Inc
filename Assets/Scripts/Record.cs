using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour {

    public GameObject obj;
    public GameObject turnPin;
    public int test = 0;
    public float rot = 0;
    public bool ready = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rot = turnPin.transform.rotation.eulerAngles.y;
        if (rot < 20 && ready)
        {
            GetComponent<AudioSource>().mute = false;
        }

    }
	
    void OnTriggerStay(Collider col)
    {
        //if (col.CompareTag("RecordPos"))
        //{
        if(col.gameObject == obj)
        {

            //GetComponent<AudioSource>().mute = false;
            test += 1;
            ready = true;
        }
            
            //Destroy(col.gameObject);
            
            //obj = col.gameObject;
        //}
    }
}
