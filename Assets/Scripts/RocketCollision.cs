using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem m_successVFX;
    [SerializeField] private ParticleSystem m_crashVFX;

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                GameManager.instance.ChangeState(GameState.LEVEL_FINISH);
                m_successVFX.Play();
                break;
            default:
                GameManager.instance.ChangeState(GameState.PLAYER_DIED);
                m_crashVFX.Play();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Fuel":
                break;
        }
    }
}
