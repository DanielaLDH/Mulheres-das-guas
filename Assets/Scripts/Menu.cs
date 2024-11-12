using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] int gameScene;
    [SerializeField] GameObject soundPanel;
    [SerializeField] AudioSource buttonClickSound;

    [SerializeField] Sprite changeImgOnHover;
    [SerializeField] Sprite changeImgOnClick;

    [SerializeField] Button playButton;

    SFXManager sfxManager;
    Sprite buttonImg;
    
    // Start is called before the first frame update
    void Start()
    {
        soundPanel.SetActive(false);
        sfxManager = buttonClickSound.GetComponent<SFXManager>();

        if (playButton != null)
        {
            buttonImg = playButton.image.sprite;

        }
    }


    public void OnHover()
    {
        sfxManager.PlaySFX(sfxManager.sfx_ui_play_hover);
        playButton.image.sprite = changeImgOnHover;

    }

    public void ExitHover()
    {
        playButton.image.sprite = buttonImg;
    }

    public void Play()
    {
        sfxManager.PlaySFX(sfxManager.sfx_ui_play_click);
        playButton.image.sprite = changeImgOnClick;

        SceneManager.LoadScene(gameScene);
    }

    public void OnClick()
    {

        if (soundPanel.activeSelf == true)
        {          
            //sfxManager.PlaySFX(sfxManager.sfx_ui_play_click);
            soundPanel.SetActive(false);

        }
        else if (soundPanel.activeSelf == false)
        {
            //sfxManager.PlaySFX(sfxManager.sfx_ui_play_click);
            soundPanel.SetActive(true);
        }
    }
}
