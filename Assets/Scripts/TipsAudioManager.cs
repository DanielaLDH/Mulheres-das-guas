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

    private int playCount = 0;
    private bool scorePoint = false;

    public void PlayAudio()
    {
        if (playCount < maxPlays) 
        {
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
