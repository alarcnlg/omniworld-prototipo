using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Suscribe to score changes
        ScoreManager.Instance.OnScoreChanged += UpdateScore;
        UpdateScore(ScoreManager.Instance.Score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScore(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = newScore.ToString();
        }
    }
}
