using UnityEngine;
using UnityEngine.UI;

public class HiScore : MonoBehaviour
{
    public int highScore;

    Text highScoreText;

    void Awake()
    {
        highScoreText = GetComponent<Text>();    
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = highScore.ToString("D4");
    }
}
