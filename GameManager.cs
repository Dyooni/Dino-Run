using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    AudioSource audioSource;

    public Player player;
    public HiScore hiScore;
    public GameObject gameOverUI;

    float gameTime;
    public float timeMultiplier = 5;
    public int gameScore;
    public bool gameOverNow;
    bool isAudioPlaying = false;
    float increaseSpeed;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Scoring();
        HighScoreUpdate();
        LevelUp();

        if (!player.isLive && !gameOverNow) {
            gameOverUI.SetActive(true);
            gameOverNow = true;
        }
    }

    void Scoring()
    {
        gameTime += timeMultiplier * Time.deltaTime;
        //gameTime = gameTime + timeMultiplier * Time.deltaTime;
        if (player.isLive)
            gameScore = Mathf.FloorToInt(gameTime);
    }

    public void Reset()
    {
        if (!isAudioPlaying) {
            audioSource.Play();
            isAudioPlaying = true;
        }
        
        gameOverNow = false;
        Invoke("LoadScene", 1);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    void HighScoreUpdate()
    {
        if (gameScore > hiScore.highScore && !player.isLive) {
            PlayerPrefs.SetInt("HighScore", gameScore);
        }
    }

    void LevelUp()
    {
        if (player.isLive)
            increaseSpeed = gameTime / 2000;
            if (increaseSpeed > 1)
                increaseSpeed = 1;
            Time.timeScale = 1 + increaseSpeed;
    }
}
