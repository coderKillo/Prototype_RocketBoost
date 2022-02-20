using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketAudio : MonoBehaviour
{
    private bool m_input_boost;

    private AudioSource m_audioSource;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (m_input_boost)
        {
            if (!m_audioSource.isPlaying)
            {
                m_audioSource.Play();
            }
        }
        else
        {
            m_audioSource.Stop();
        }
    }

    void OnBoost(InputValue value)
    {
        m_input_boost = value.isPressed;
    }
}
