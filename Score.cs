using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int gameScore;
    int nextMilestone = 100;
    bool isAnimating = false;

    Text scoreText;
    Animator anim;

    void Awake()
    {
        scoreText = GetComponent<Text>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        scoreText.text = gameScore.ToString("D4");

        if (gameScore == nextMilestone) {
            gameScore = nextMilestone;
            if (!isAnimating) {
                anim.SetTrigger("doCheck");
                isAnimating = true;
            }
        }
        else
            gameScore = GameManager.instance.gameScore;
    }

    public void Checking()
    {
        nextMilestone += 100;
        isAnimating = false;
    }
}
