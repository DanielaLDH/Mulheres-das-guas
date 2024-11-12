using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SubtitleLine
{
    public float startTime;
    public float endTime;
    public string text;
}

public class SubtitleManager : MonoBehaviour
{
    public AudioSource audioSource;
    public TMP_Text subtitleText;
    public List<SubtitleLine> subtitles;

    private void Update()
    {
        float currentTime = audioSource.time;

        foreach (var line in subtitles)
        {
            if (currentTime >= line.startTime && currentTime <= line.endTime)
            {
                subtitleText.text = line.text;
                return;
            }
        }

        subtitleText.text = string.Empty;
    }

}
