using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_timer;

    static private PlayerUI _instance;
    static public PlayerUI instance { get { return _instance; } }

    bool m_timerRunning = true;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if (m_timerRunning)
        {
            SetTimerText(Time.timeSinceLevelLoad);
        }
    }

    public void ResetTimer()
    {
        SetTimerText(0f);
        m_timerRunning = true;
        m_timer.color = Color.white;
    }

    public void StopTimer()
    {
        m_timerRunning = false;
        m_timer.color = Color.green;
    }

    private void SetTimerText(float timer)
    {
        m_timer.text = timer.ToString("#0.00");
    }
}
