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
    bool isAudioPlaying = false;

    void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player.isLive) { // 플레이어가 죽었을 때 스코어링과 레벨업 호출을 막기 위한 조건문
            Scoring();
            LevelUp();
        }
        else {
            gameOverUI.SetActive(true);
            HighScoreUpdate();
        }

        TurnOffGame();
    }

    void Scoring()
    {
        gameTime += timeMultiplier * Time.deltaTime;
        //gameTime = gameTime + timeMultiplier * Time.deltaTime;
        gameScore = Mathf.FloorToInt(gameTime);
    }

    void HighScoreUpdate()
    {
        if (gameScore > hiScore.highScore) {
            hiScore.UpdateHighScore(gameScore);
        }
    }

    public void Reset()
    {
        if (!isAudioPlaying) {
            audioSource.Play();
            isAudioPlaying = true;
        }
        
        Invoke("LoadScene", 1);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    void LevelUp()
    {
        float increaseSpeed = Mathf.Clamp(gameTime / 2000, 0, 1); // Mathf.Clamp 함수를 사용하여 0 ~ 1 범위를 넘지 않도록 설정.
        Time.timeScale = 1 + increaseSpeed;
    }

    void TurnOffGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
