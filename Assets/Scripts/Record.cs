using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour {

    public GameObject trigger1;
    public GameObject trigger2;
    public GameObject turnPin1;
    public GameObject turnPin2;
    public int test = 0;
    public float rot1 = 0;
    public float rot2 = 0;
    public bool ready1 = false;
    public bool ready2 = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rot1 = turnPin1.transform.rotation.eulerAngles.y;
        rot2 = turnPin2.transform.rotation.eulerAngles.y;
        if (rot1 < 20 && ready1)
        {
            GetComponent<AudioSource>().mute = false;
        }
        if (rot2 < 20 && ready2)
        {
            GetComponent<AudioSource>().mute = false;
        }

    }
	
    void OnTriggerStay(Collider col)
    {
        //if (col.CompareTag("RecordPos"))
        //{
        if(col.gameObject == trigger1)
        {
            ready1 = true;
        }
        if (col.gameObject == trigger2)
        {
            ready2 = true;
        }

        //Destroy(col.gameObject);

        //obj = col.gameObject;
        //}
    }
}
