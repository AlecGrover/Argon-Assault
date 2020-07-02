using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = ZeroPrefix() + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore(int scoreToAdd)
    {
        score += scoreToAdd;
        TextMeshProUGUI scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = ZeroPrefix() + score.ToString();
    }

    private string ZeroPrefix()
    {
        int logTenOfScore = 1;
        string zeroPrefix = "";
        if (score > 0)
        {
            logTenOfScore = Mathf.FloorToInt(Mathf.Log10(score)) + 1;
        }

        for (int i = 6 - logTenOfScore; i > 0; i--)
        {
            zeroPrefix += "0";
        }
        return zeroPrefix;
    }
}
