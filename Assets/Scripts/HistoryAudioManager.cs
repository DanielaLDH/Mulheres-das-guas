using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoryAudioManager : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;

    // Start is called before the first frame update
    public void OnClick()
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
