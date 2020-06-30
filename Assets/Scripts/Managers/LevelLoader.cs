using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType<LevelLoader>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextLevel(string lastSceneBehaviour = "reload") {

        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        switch (lastSceneBehaviour) {
            case "reload":
                if (nextLevel >= SceneManager.sceneCountInBuildSettings)
                {
                    nextLevel--;
                }
                break;
            case "menu":
                if (nextLevel >= SceneManager.sceneCountInBuildSettings)
                {
                    nextLevel = 0;
                }
                break;
            default:
                if (nextLevel >= SceneManager.sceneCountInBuildSettings)
                {
                    nextLevel--;
                }
                break;
        }
        SceneManager.LoadScene(nextLevel);
    }

    public IEnumerator DelayedLoadNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadNextLevel();
    }

}
