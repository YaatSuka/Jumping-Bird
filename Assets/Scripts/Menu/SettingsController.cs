using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    private Canvas canvas;
    private Canvas mainMenuCanvas;
    private Toggle musicCheckbox;
    private Toggle soundCheckbox;
    private Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        mainMenuCanvas = GameObject.Find("MainMenuCanvas").GetComponent<Canvas>();
        backButton = GameObject.Find("BackButton").GetComponent<Button>();
        musicCheckbox = GameObject.Find("MusicCheckbox").GetComponent<Toggle>();
        soundCheckbox = GameObject.Find("SoundCheckbox").GetComponent<Toggle>();

        musicCheckbox.onValueChanged.AddListener(UpdateMusicSetting);
        soundCheckbox.onValueChanged.AddListener(UpdateSoundSetting);
        backButton.onClick.AddListener(BackMainMenu);

        AudioSettings.Music = true;
        AudioSettings.Sound = true;
    }

    public void UpdateMusicSetting(bool value)
    {
        AudioSettings.Music = value;
    }

    public void UpdateSoundSetting(bool value)
    {
        AudioSettings.Sound = value;
    }

    void BackMainMenu()
    {
        mainMenuCanvas.enabled = true;
        canvas.enabled = false;
    }
}
