using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip m_crashSound;
    [SerializeField] private AudioClip m_finishSound;

    private AudioSource m_audioSource;

    static private AudioManager _instance;
    static public AudioManager instance { get { return _instance; } }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public void PlayFinishSound()
    {
        m_audioSource.PlayOneShot(m_finishSound);
    }

    public void PlayCrashSound()
    {
        m_audioSource.PlayOneShot(m_crashSound);
    }
}
