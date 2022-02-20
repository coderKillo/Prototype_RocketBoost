using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    [SerializeField] private float m_trustForce = 400f;
    [SerializeField] private float m_rotationSpeed = 20f;

    private Vector2 m_input_move;
    private bool m_input_boost;

    private Rigidbody m_rigidbody;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (m_input_boost)
        {
            m_rigidbody.AddRelativeForce(Vector3.up * m_trustForce * Time.deltaTime);
        }

        m_rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * m_rotationSpeed * -m_input_move.x * Time.deltaTime);
        m_rigidbody.freezeRotation = false;
    }

    ////////////////////////////////////////////////////////////////////////////////

    void OnMove(InputValue value)
    {
        m_input_move = value.Get<Vector2>();
    }

    void OnBoost(InputValue value)
    {
        m_input_boost = value.isPressed;
    }
}
