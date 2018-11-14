using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHouse : MonoBehaviour
{
    Renderer[] materials;
    public float sliceAmount = 0;

    public float normalizedTime = 0;
    float negativeNormalizedTime = .9f;
    // Use this for initialization
    void Start()
    {
        materials = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car" || other.gameObject.tag == "Player")
        {
            StartCoroutine(Countdown());
            Debug.Log("Inside the OntriggerIf");
        }
    }
    private IEnumerator Countdown()
    {
        
        float timer = 10f;   // 3 seconds you can change this 
                             //to whatever you want
        normalizedTime = 0;
        while (normalizedTime <= 1f)
        {

            normalizedTime += Time.deltaTime / timer;
            negativeNormalizedTime -= (Time.deltaTime / timer) + 0.005f;
            //rend.material.SetFloat("_SliceAmount", negativeNormalizedTime);
            foreach (Renderer mat in materials)
            {
                mat.material.SetFloat("_SliceAmount", negativeNormalizedTime);
                sliceAmount = mat.material.GetFloat("_SliceAmount");
            }

            

            yield return null;
        }

    }
}
