using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using VRStandardAssets.Utils;

public class VideoController : MonoBehaviour {
    public GameObject[] video;
    bool next = false;
    int timer = 15;
    int currentVideo = 0;
    // Use this for initialization
    void Start () {
        video[currentVideo].GetComponent<VideoPlayer>().Play();
    }
	
	// Update is called once per frame
	void Update () {
        timer--;
        VideoPlayer movie = video[currentVideo].GetComponent<VideoPlayer>();
        if (movie.frame == (long)movie.frameCount&& timer<0)
        {
            currentVideo++;
            next = true;
        }
        if (next)
        {
            video[currentVideo].GetComponent<VideoPlayer>().Play();
            next = false;
        }

    }
}
