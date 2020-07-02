using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        if (levelLoader)
        {
            StartCoroutine(levelLoader.DelayedLoadNextLevel(3));
        }
        else
        {
            Debug.LogError("No Level Loader Object Found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
