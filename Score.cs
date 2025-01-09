using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int gameScore;
    int nextCheck = 100;
    bool isAnim = false;

    Text scoreText;
    Animator anim;

    void Awake()
    {
        scoreText = GetComponent<Text>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        scoreText.text = string.Format("{0:D4}", gameScore);        

        if (gameScore == nextCheck) {
            gameScore = nextCheck;
            if (!isAnim) {
                anim.SetTrigger("doCheck");
                isAnim = true;
            }
        }
        else
            gameScore = GameManager.instance.gameScore;
    }

    public void Checking()
    {
        nextCheck += 100;
        isAnim = false;
    }
}
