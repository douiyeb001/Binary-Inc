using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendScriptSky : MonoBehaviour {
    
    Renderer rend;
    public int i;
    void Start () {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("SkyboxShader");
    }

    // Update is called once per frame
    void Update () {


    }
}
