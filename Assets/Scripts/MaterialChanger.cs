using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour {
    public Material[] material;
    Renderer rend;
    public GameObject[] obj;
    public int currentMat;
    private int t;

	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        currentMat = 0;

    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Balloon")
        {
            t = Random.Range(1, material.Length);
            rend.sharedMaterial = material[t];
            Instantiate(obj[t-1],transform);
            currentMat = t;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        rend.sharedMaterial = material[0];
        currentMat = 0;

    }
}
