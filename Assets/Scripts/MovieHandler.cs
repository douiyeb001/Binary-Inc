using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieHandler : MonoBehaviour {

    VideoPlayer movie;
    public long frames;
    GameObject player;
    bool active = true;
	// Use this for initialization
	void Start () {
        movie = GetComponent<VideoPlayer>();
        player = GameObject.Find("Player");

        movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
        frames = movie.frame;
        if (movie.frame == (long)movie.frameCount&& active)
        {
            Debug.Log("turnurnrnu");
            //player.GetComponent<MovementVR>().TurnOnWalk();
            //movie.Play();


        }

    }
}
