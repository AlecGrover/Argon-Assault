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
        // Debug.Log("Loading next level");
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        // Debug.Log("Next level index is " + nextLevel.ToString());
        switch (lastSceneBehaviour) {
            case "reload":
                if (nextLevel >= SceneManager.sceneCountInBuildSettings)
                {
                    // Debug.Log("Level Out of Range, Reloading Level");
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
        // Debug.Log("Loading level " + nextLevel.ToString());
        SceneManager.LoadScene(nextLevel);
    }

    public IEnumerator DelayedLoadNextLevel(float delay)
    {
        // Debug.Log("Loading next level on delay...");
        yield return new WaitForSeconds(delay);
        LoadNextLevel();
    }

}
