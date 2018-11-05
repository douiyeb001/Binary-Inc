using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class ExampleInteractiveItem : MonoBehaviour
    {
  
        [SerializeField] private Material m_NormalMaterial;
        [SerializeField] private Material m_OverMaterial;
        [SerializeField] private Material m_ClickedMaterial;
        [SerializeField] private Material m_DoubleClickedMaterial;
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;

        public float sliceAmount = 0;
        public AudioSource audioSource;
        public float normalizedTime = 0;
        float negativeNormalizedTime = .9f;
        public float delayTimer = 0;

        Renderer rend;
        Renderer[] materials;

        public GameObject player;

        private void Awake()
        {
            player = GameObject.Find("Player");
            //.Play();
            audioSource = GetComponent<AudioSource>();
            rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Custom/Dissolve");
            materials = GetComponentsInChildren<Renderer>();    

            //m_Renderer.material = m_NormalMaterial;
        }   
        private IEnumerator Countdown()
        {
            float timer = 10f;   // 3 seconds you can change this 
                                 //to whatever you want
            normalizedTime =   0;
            while (normalizedTime <= 1f)
            {

                normalizedTime += Time.deltaTime / timer;
                negativeNormalizedTime -= (Time.deltaTime / timer) + 0.005f;
                //rend.material.SetFloat("_SliceAmount", negativeNormalizedTime);
                foreach (Renderer mat in materials)
                {
                    mat.material.SetFloat("_SliceAmount", negativeNormalizedTime);
                    sliceAmount= mat.material.GetFloat("_SliceAmount");
                }

                if (sliceAmount <= 0)
                {
                  audioSource.mute = true;
                }

                yield return null;
            }
           


        }
        private IEnumerator NewCountDown()
        {
            Debug.Log("reee");

            yield return new WaitForSecondsRealtime(delayTimer);
            Destroy(this.gameObject);
            player.GetComponent<MovementVR>().TurnOnWalk();
            
            
            yield return null;
        }


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
            StopAllCoroutines();
            normalizedTime = 0;

        }


        //Handle the Over event
        private void HandleOver()
        {
           // StartCoroutine(Countdown());
            Debug.Log("Show over state");
            StartCoroutine(NewCountDown());

            // m_Renderer.material = m_OverMaterial;
            Debug.Log("hit");

        }


        //Handle the Out event
        private void HandleOut()
        {


            Debug.Log("Show out state");
           // m_Renderer.material = m_NormalMaterial;
            normalizedTime = 0;
            StopAllCoroutines();
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
           // m_Renderer.material = m_ClickedMaterial;
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            //m_Renderer.material = m_DoubleClickedMaterial;
        }
       
    }
   
    }
