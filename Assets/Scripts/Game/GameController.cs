using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private ScrollingSpeedController scrollingController;
    private Move birdMoveController;
    private Text scoreText;
    private Canvas gameOverCanvas;
    private Button exitBtn;
    private Canvas pauseMenuCanvas;
    private int score = 0;
    private bool onPause = false;

    // Start is called before the first frame update
    void Start()
    {
        scrollingController = GameObject.Find("ScrollingSpeedController").GetComponent<ScrollingSpeedController>();
        birdMoveController = GameObject.FindWithTag("Player").GetComponent<Move>();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        exitBtn = GameObject.Find("QuitButton").GetComponent<Button>();
        exitBtn.onClick.AddListener(ExitGame);

        gameOverCanvas = GameObject.Find("GameOverUI").GetComponent<Canvas>();
        gameOverCanvas.enabled = false;
        pauseMenuCanvas = GameObject.Find("PauseMenu").GetComponent<Canvas>();
        pauseMenuCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape)) {
           if (!onPause) {
                onPause = true;
                Time.timeScale = 0f;
                pauseMenuCanvas.enabled = true;
           } else {
               onPause = false;
               Time.timeScale = 1f;
               pauseMenuCanvas.enabled = false;
           }
        }
    }

    public void GameOver()
    {
        scrollingController.Freeze();
        birdMoveController.GameOver();
        gameOverCanvas.enabled = true;
    }

    public void IncreaseScore(int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    void ExitGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
