using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuttoff : MonoBehaviour {

    Renderer renderer;
    public GameObject credits;
    public float alpha =1;
    public float constant =0.00025f;
    public bool  end = false;
    public GameObject[] turnoff;
	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        renderer.material.SetFloat("_Cutoff", 1);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        alpha -= constant;
        renderer.material.SetFloat("_Cutoff", alpha);

        if (end && alpha <0)
        {
            credits.SetActive(true);
            gameObject.SetActive(false);
            foreach (GameObject off in turnoff)
            {
                off.SetActive(false);
            }
        }
    }
}
