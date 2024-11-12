using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TipsAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;   
    [SerializeField] private int maxPlays;
    [SerializeField] private int pointsPerSinglePlay;
    [SerializeField] private MoneyManagement moneyManagement;

    [SerializeField] private GameObject videoPlayer;

    [SerializeField] AudioSource sfxSound;

    SFXManager sfxManager;


    private int playCount = 0;
    private bool scorePoint = false;


    private void Start()
    {

        sfxManager = sfxSound.GetComponent<SFXManager>();

    }

    public void PlayAudio()
    {
        if (playCount < maxPlays) 
        {
            sfxManager.PlaySFX(sfxManager.sfx_item_play);

            videoPlayer.GetComponent<VideoManager>().ShowVideo();

            playCount++;

            audioSource.clip = clip;
            audioSource.Play();

            if (playCount == 1 && !scorePoint)
            {
                moneyManagement.AddMoney(1);
                scorePoint = true;
            }
            if (playCount == 2) 
            {
                moneyManagement.RemoveMoney(1);
            }

            Debug.Log("Áudio tocado " + playCount + " vez(es).");
            Debug.Log(scorePoint);

        }
        else
        {
            Debug.Log("O áudio já foi ouvido o número máximo de vezes.");
        }
    }

}
