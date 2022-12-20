using UnityEngine;

public class ScoreController : MonoSingleton<ScoreController>
{
    private int score;
    private int highScore;
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        UIManager.Instance.highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        score = 0;
        
    }
    public void AddScore()
    {
        score++;
        UIManager.Instance.scoreText.text = "Score: " + score.ToString();
    }

    public void SaveHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            UIManager.Instance.highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        
    }
}
