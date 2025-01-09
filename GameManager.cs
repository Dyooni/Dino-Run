using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    float gameTime;
    public float timeMultiplier = 5;
    public int gameScore;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += timeMultiplier * Time.deltaTime;
        //gameTime = gameTime + timeMultiplier * Time.deltaTime;
        gameScore = Mathf.FloorToInt(gameTime);
    }
}
