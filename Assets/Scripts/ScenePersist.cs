using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake()
    {
        int numOfScenePersist = FindObjectsByType<ScenePersist>(FindObjectsSortMode.None).Length;
        if(numOfScenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // khi sang map moi / khi het mang
    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
