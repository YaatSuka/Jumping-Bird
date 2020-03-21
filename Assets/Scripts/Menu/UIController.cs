using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private Button retryButton;

    // Start is called before the first frame update
    void Start()
    {
        retryButton = GameObject.Find("RetryButton").GetComponent<Button>();
        retryButton.onClick.AddListener(RestartGame);
        retryButton = GameObject.Find("ExitButton").GetComponent<Button>();
        retryButton.onClick.AddListener(ExitGame);
    }

    void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void ExitGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
