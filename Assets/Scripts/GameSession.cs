using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        int numOfGameSS = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;
        if(numOfGameSS > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

    public void PlayerDie()
    {
        if(playerLives > 1)
        {
            TakeLives();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLives()
    {
        // minus life & restart level
        playerLives--;
        int curLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curLevel);
        livesText.text = playerLives.ToString();
    }

    // khi het mang
    private void ResetGameSession()
    {
        FindFirstObjectByType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
