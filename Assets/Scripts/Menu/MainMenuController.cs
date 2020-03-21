using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private Button playButton;
    private Button settingsButton;
    private Canvas canvas;
    private Canvas settingsCanvas;

    // Start is called before the first frame update
    void Start()
    {
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        settingsButton = GameObject.Find("SettingsButton").GetComponent<Button>();
        canvas = GetComponent<Canvas>();
        settingsCanvas = GameObject.Find("SettingsCanvas").GetComponent<Canvas>();

        playButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(OpenSettings);
        settingsCanvas.enabled = false;
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void OpenSettings()
    {
        settingsCanvas.enabled = true;
        canvas.enabled = false;
    }
}
