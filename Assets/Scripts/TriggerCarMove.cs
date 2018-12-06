using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class TriggerCarMove: MonoBehaviour {

    private EnableLights[] lights;
    public float speed;
    public float speedZ;
    GameObject player;
    public int destroyTimer;

	// Use this for initialization
	void Start () {
        lights = GetComponentsInChildren<EnableLights>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {

        if (this.gameObject.activeSelf == true)
        {
            foreach (EnableLights _light in lights)
            {
                _light.GetComponent<Light>().enabled = true;
            }
            
        }
        
         this.transform.position += new Vector3(speed, 0, speedZ);
       
    }
    private void FixedUpdate()
    {
        destroyTimer--;
        if (destroyTimer<0)
        {
            
            player.GetComponent<UpdatedMovement>().TurnOnWalk();
            Destroy(gameObject);
        }
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Exit")
    //    {
    //        player.GetComponent<UpdatedMovement>().TurnOnWalk();
    //        Destroy(this.gameObject);

    //    }
    //}

}
