using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using VRStandardAssets.Utils;

public class VideoController : MonoBehaviour {
    public GameObject[] video;
    bool next = false;
    public long frames;
    int timer = 15;
    int currentVideo = 0;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < video.Length; i++)
        {
            video[i].SetActive(false);
        }
        video[currentVideo].SetActive(true);
        video[currentVideo].GetComponent<VideoPlayer>().Play();
    }
	
	// Update is called once per frame
	void Update () {
        timer--;

        if (currentVideo < video.Length)
        {


            VideoPlayer movie = video[currentVideo].GetComponent<VideoPlayer>();

            frames = video[currentVideo].GetComponent<VideoPlayer>().frame;
            if (movie.frame == (long)movie.frameCount && timer < 0)
            {
                video[currentVideo].GetComponent<VideoPlayer>().frame = 0;
                if (currentVideo < video.Length - 1)
                    video[currentVideo].SetActive(false);
                currentVideo++;
                next = true;
            }
            if (next)
            {

                video[currentVideo].SetActive(true);
                video[currentVideo].GetComponent<VideoPlayer>().Play();
                next = false;
            }
        }

    }
}
