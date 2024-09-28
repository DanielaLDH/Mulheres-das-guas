using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundVolumeManager : MonoBehaviour
{

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    [SerializeField] AudioSource musicSource; 
    [SerializeField] AudioSource sfxSource;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1f); 
        }

        if (!PlayerPrefs.HasKey("sfxVolume"))
        {
            PlayerPrefs.SetFloat("sfxVolume", 1f); 
        }

        LoadVolume();
    }

    public void SetMusicVolume() 
    {
        AudioListener.volume = musicSlider.value;
        SaveVolume();
    }

    public void SetSfxVolume()
    {
        sfxSource.volume = sfxSlider.value;
        SaveVolume();
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        musicSource.volume = musicSlider.value;
        sfxSource.volume = sfxSlider.value;
    }
}
