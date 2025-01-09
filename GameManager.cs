using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    float gameTime;
    float addTime = 5;
    public int gameScore;

    public Cactus[] cactus;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime = gameTime + addTime * Time.deltaTime;
        gameScore = Mathf.FloorToInt(gameTime);
    }
}
