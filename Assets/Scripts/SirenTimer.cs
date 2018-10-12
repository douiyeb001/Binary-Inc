using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenTimer : MonoBehaviour {
   public Light Red;
    public      Light Blue;
    float flickerSpeed;
    // Use this for initialization
    void Start () {
        Red = GameObject.Find("RedLight").GetComponent<Light>();
        Blue = GameObject.Find("BlueLight").GetComponent<Light>();
        
        StartCoroutine(Siren());

        

    }
    IEnumerator Siren()
    {
        while (true)
        {
            Red.enabled = true;
            Blue.enabled = false;
            yield return new WaitForSeconds(2);
            Red.enabled = false;
            Blue.enabled = true;    
            yield return new WaitForSeconds(2);
        }
        

    }
    // Update is called once per frame
    void Update () {
        
       
         
      

    }
    
}

