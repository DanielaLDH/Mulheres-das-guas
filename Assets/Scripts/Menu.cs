using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] int gameScene;
  

    [SerializeField] Sprite changeImgOnHover;
    [SerializeField] Sprite changeImgOnClick;

    [SerializeField] Button playButton;

    

    SFXManager sfxManager;

    Sprite buttonImg;



    // Start is called before the first frame update
    void Awake()
    {
       

        if (playButton != null)
        {
            buttonImg = playButton.image.sprite;

        }
    } 


    public void OnHover()
    {
      //  sfxManager.PlaySFX(sfxManager.sfx_ui_play_hover);
        playButton.image.sprite = changeImgOnHover;

    }

    public void ExitHover()
    {
        playButton.image.sprite = buttonImg;
    }

    public void Play()
    {
        //sfxManager.PlaySFX(sfxManager.sfx_ui_play_click);
        playButton.image.sprite = changeImgOnClick;

        SceneManager.LoadScene(gameScene);
    }

  
  

}
