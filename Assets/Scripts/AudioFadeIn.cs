using UnityEngine;


public class AudioFadeIn : MonoBehaviour
{
    [SerializeField]
    private int m_FadeInTime = 10;
    public AudioSource m_AudioSource;


    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        if (m_AudioSource.volume < 1)
        {
            m_AudioSource.volume = m_AudioSource.volume + (Time.deltaTime / (m_FadeInTime + 1));
        }
        else
        {
            Destroy(this);
        }
    }
}