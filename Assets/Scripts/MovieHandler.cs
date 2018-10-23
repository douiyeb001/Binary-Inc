using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieHandler : MonoBehaviour {

    VideoPlayer movie;
    public long frames;
	// Use this for initialization
	void Start () {
        movie = GetComponent<VideoPlayer>();

        movie.Play();
	}
	
	// Update is called once per frame
	void Update () {
        frames = movie.frame;
        if (movie.frame == (long)movie.frameCount)
            movie.Play();
	}
}
