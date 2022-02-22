using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] private Transform m_startPos;
    [SerializeField] private Transform m_endPos;
    [SerializeField] private Transform m_objectToMove;
    [SerializeField] private float m_period;

    void Start()
    {
        m_objectToMove.position = m_startPos.position;
    }

    void Update()
    {
        var cycle = Time.time / m_period;
        var sinWave = Mathf.Sin(cycle * 2 * Mathf.PI);
        sinWave = (sinWave + 1) / 2;

        m_objectToMove.position = Vector3.Lerp(m_startPos.position, m_endPos.position, sinWave);
    }
}
