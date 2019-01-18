using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ending : MonoBehaviour
{

    public float alpha = 1;
    public float constant = 0.00025f;
    public List<Renderer> renderList = new List<Renderer>();
    int i = 1;
    // Use this for initialization
    void Start()
    {
                    renderList[i].enabled = true;

        //renderer = GetComponent<Renderer>();
        //renderer.material.SetFloat("_Cutoff", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         
      
        alpha -= constant;
        foreach (Renderer rend in renderList)
        {

            rend.material.SetFloat("_Cutoff", alpha);

        }
    }
}
