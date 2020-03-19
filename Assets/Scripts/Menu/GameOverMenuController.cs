using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenuController : MonoBehaviour
{
    private Button retryButton;

    // Start is called before the first frame update
    void Start()
    {
        retryButton = GameObject.Find("RetryButton").GetComponent<Button>();
        retryButton.onClick.AddListener(RestartGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
