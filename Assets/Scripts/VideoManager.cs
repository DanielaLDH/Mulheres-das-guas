using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    [SerializeField] private GameObject tela;

    private VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();

    }

    public void ShowVideo()
    {

        tela.SetActive(true);
        gameObject.SetActive(true);
        StartCoroutine(StopVideo());
        
    }

    private IEnumerator StopVideo()
    {
        yield return new WaitForSeconds((float)videoPlayer.length); 

        tela.SetActive(false);
        gameObject.SetActive(false);
    }
}
