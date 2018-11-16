using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
namespace VRStandardAssets.Utils
{

    public class ShatterMovie : MonoBehaviour
    {
        public GameObject shatter;
        VideoPlayer movie;
        public long frames;
        GameObject player;
        bool active = true;
        public GameObject WalkingCharacter;

        // Use this for initialization
        void Start()
        {
            movie = GetComponent<VideoPlayer>();
            player = GameObject.Find("Player");

            movie.Play();
        }

        // Update is called once per frame
        void Update()
        {
            frames = movie.frame;
            if (movie.frame == (long)movie.frameCount && active)
            {
                for (int i = 0; i < 300; i++)
                {
                    Instantiate(shatter, gameObject.transform.position, gameObject.transform.rotation);
                }
                player.GetComponent<UpdatedMovement>().TurnOnWalk();
                WalkingCharacter.SetActive(true);
                Destroy(gameObject);
                //Debug.Log("turnurnrnu");
                //player.GetComponent<MovementVR>().TurnOnWalk();
                //movie.Play();


            }

        }

    }
}
