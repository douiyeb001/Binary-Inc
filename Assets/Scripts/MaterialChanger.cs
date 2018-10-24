using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour {
    public Material[] material;
    Renderer rend;

	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Box")
        {
            rend.sharedMaterial = material[Random.Range(1,material.Length)];
        }
    }
    private void OnTriggerExit(Collider other)
    {
        rend.sharedMaterial = material[0];
    }
}
