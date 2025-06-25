using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayPauseController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button playPauseButton;
    public TextMeshProUGUI buttonText;

    private bool isPlaying = false;

    void Start()
    {
        if(videoPlayer == null)
        {
            Debug.Log("VideoPlayer not assigned to VideoController script!");
            return;
        }
        
        if(playPauseButton == null)
        {
            Debug.Log("Play/Pause button not assigned to VideoController Script!");
            return;
        }
        playPauseButton.onClick.AddListener(TogglePlayPause);

        if(buttonText == null)
        {
            buttonText = playPauseButton.GetComponentInChildren<TextMeshProUGUI>();
            if(buttonText == null )
            {
                Debug.LogError("Button Text (TextMeshProUGUI) not found on Play/Pause Button or not assigned!");
            }
        }

        UpdateButtonText();
    }

    public void TogglePlayPause()
    {
        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer is null in TogglePlayPause!");
            return;
        }

        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
            isPlaying = false;
        }
        else
        {
            videoPlayer.Play();
            isPlaying = true;
        }
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        if (buttonText != null)
        {
            buttonText.text = isPlaying ? "||" : "Play";
            // buttonText.text = isPlaying ? "\u23F8" : "\u25B6";
        }
    }
}
