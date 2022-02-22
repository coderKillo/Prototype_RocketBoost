using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    LEVEL_START,
    RUN,
    LEVEL_FINISH,
    PLAYER_DIED
}

public class GameManager : MonoBehaviour
{
    private GameObject m_player;
    private GameState m_currentState;

    static private GameManager _instance;
    static public GameManager instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
    }

    public void ChangeState(GameState newState)
    {
        if (newState == m_currentState)
        {
            return;
        }

        m_currentState = newState;

        var player = GameObject.FindGameObjectWithTag("Player");

        switch (newState)
        {
            case GameState.LEVEL_START:
                PlayerUI.instance.ResetTimer();
                ChangeState(GameState.RUN);
                break;

            case GameState.RUN:
                break;

            case GameState.LEVEL_FINISH:
                AudioManager.instance.PlayFinishSound();
                PlayerUI.instance.StopTimer();

                player.GetComponent<Rigidbody>().useGravity = false;

                Invoke("LoadNextLevel", 1);
                break;

            case GameState.PLAYER_DIED:
                AudioManager.instance.PlayCrashSound();

                player.GetComponent<RocketController>().enabled = false;

                Invoke("ReloadLevel", 1);
                break;
        }
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        ChangeState(GameState.LEVEL_START);
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);

        ChangeState(GameState.LEVEL_START);
    }

}
