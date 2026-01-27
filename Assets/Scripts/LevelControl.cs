using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;

    int totalLevel;

    void Start()
    {
        totalLevel = SceneManager.sceneCount;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadLevel());     
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSecondsRealtime(loadDelay);

        int curLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene((curLevel + 1) % totalLevel);
    }
}
