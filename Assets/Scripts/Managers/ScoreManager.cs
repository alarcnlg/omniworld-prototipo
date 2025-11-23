using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public delegate void ScoreChanged(int newScore);
    public event ScoreChanged OnScoreChanged;

    private int _score;
    public int Score
    {
        get { return _score; }
        set { 
            _score = value; 
            OnScoreChanged?.Invoke(_score);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
