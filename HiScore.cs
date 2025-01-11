using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    public int highScore;

    Text highScoreText;

    void Awake()
    {
        highScoreText = GetComponent<Text>();
        LoadHighScore();
    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateUI();
    }

    public void UpdateHighScore(int newScore)
    {
        highScore = newScore;
        PlayerPrefs.SetInt("HighScore", highScore);
        UpdateUI();
    }

    void UpdateUI()
    {
        highScoreText.text = highScore.ToString("D4");
    }
}
