using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    [Header("Forces")]
    [SerializeField] private float m_trustForce = 400f;
    [SerializeField] private float m_rotationSpeed = 20f;

    [Header("VFX")]
    [SerializeField] private ParticleSystem m_trusterVFX;

    private Vector2 m_input_move;
    private bool m_input_boost;
    private bool m_thrusterOn = false;

    private Rigidbody m_rigidbody;
    private AudioSource m_audioSource;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (m_input_boost && !m_thrusterOn)
        {
            ThrusterOn();
        }
        else if (!m_input_boost && m_thrusterOn)
        {
            ThrusterOff();
        }

        if (m_thrusterOn)
        {
            m_rigidbody.AddRelativeForce(Vector3.up * m_trustForce * Time.deltaTime);
        }

        m_rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * m_rotationSpeed * -m_input_move.x * Time.deltaTime);
        m_rigidbody.freezeRotation = false;
    }

    ////////////////////////////////////////////////////////////////////////////////

    void ThrusterOn()
    {
        m_thrusterOn = true;
        m_audioSource.Play();
        m_trusterVFX.Play();
    }

    void ThrusterOff()
    {
        m_thrusterOn = false;
        m_audioSource.Stop();
        m_trusterVFX.Stop();
    }

    void OnMove(InputValue value)
    {
        m_input_move = value.Get<Vector2>();
    }

    void OnBoost(InputValue value)
    {
        m_input_boost = value.isPressed;
    }
}
