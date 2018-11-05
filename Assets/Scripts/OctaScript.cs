    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctaScript : MonoBehaviour {
    public float normalizedTime = 0;
    float negativeNormalizedTime = .9f;
    float timer = 10f;
    Renderer rend;

    public bool swap = true;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        
        rend.material.shader = Shader.Find("Custom/DissolveInOut");

    }

    // Update is called once per frame
    void Update() {
        normalizedTime += Time.deltaTime / timer;
        negativeNormalizedTime -= (Time.deltaTime / timer) + 0.002f;
        if (rend.material.GetFloat("_SliceAmount") >= 0.5f&& !swap)
        {
            swap = true;


        }

        else if ((rend.material.GetFloat("_SliceAmount") <= 0f)&& swap) { 
            swap = false;
        }
        if (swap)
        {
            rend.material.SetFloat("_SliceAmount", negativeNormalizedTime);

        }
        else rend.material.SetFloat("_SliceAmount", normalizedTime);

    }
    }

