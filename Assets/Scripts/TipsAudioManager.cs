using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class TipsAudioManager : MonoBehaviour
{
 
    [SerializeField] private int maxPlays;
    [SerializeField] private int pointsPerSinglePlay;
    [SerializeField] private MoneyManagement moneyManagement;
    [SerializeField] private Sprite[] normalSprites; // Sprites para o estado normal (0, 1, 2, 3 vezes)
    [SerializeField] private Sprite[] hoverSprites;  // Sprites para o estado hover (0, 1, 2, 3 vezes)

    [SerializeField] GameObject videoPlayer;
    [SerializeField] private GameObject legenda;

    [SerializeField] GameObject sfxSound;
    [SerializeField] GameObject falasSound;

    [SerializeField] private string audioEventPath;

    [SerializeField] private BtnLibra BtnLibra;

    SFXManager sfxManager;
    FalasManager falasManager;

    private int playCount = 0;
    private bool scorePoint = false;
    private bool isAudioPlaying = false;
    private Image image;
    private Animator animator;


    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        sfxManager = sfxSound.GetComponent<SFXManager>();
        falasManager = falasSound.GetComponent<FalasManager>();
        animator = gameObject.GetComponent<Animator>();

    }

    public void PlayAudio()
    {
        if (isAudioPlaying)
        {
            Debug.Log("Uma fala já está tocando. Aguarde até terminar.");

            return;
        }

        if (playCount < maxPlays) 
        {
            isAudioPlaying = true;
            sfxManager.PlaySFX(sfxManager.sfx_item_play);
            if (BtnLibra.isActive)
            {
                videoPlayer.GetComponent<VideoManager>().ShowVideo();
            }
            legenda.SetActive(true);

            playCount++;


            switch (playCount)
            {
                case 1:
                    if (!scorePoint)
                    {
                        moneyManagement.AddMoney(1);
                        scorePoint = true;
                    }
                    PlayVoiceAndSyncAnimation(audioEventPath, "anim1");
                    break;

                case 2:
                    moneyManagement.RemoveMoney(1);
                    PlayVoiceAndSyncAnimation(audioEventPath, "anim2");
                    break;

                case 3:
                    PlayVoiceAndSyncAnimation(audioEventPath, "anim3");
                    break;



            }

            Debug.Log("Áudio tocado " + playCount + " vez(es).");
            Debug.Log(scorePoint);
            

        }
        else
        {
            Debug.Log("O áudio já foi ouvido o número máximo de vezes.");
        }
    }

    private void PlayVoiceAndSyncAnimation(string voiceEventPath, string animationTrigger)
    {
        isAudioPlaying = true;

        animator.enabled = true;

        falasManager.PlayFala(voiceEventPath);

        float duration = falasManager.GetFalaDuration(voiceEventPath);

        animator.SetTrigger(animationTrigger);
        animator.SetFloat("speedMultiplier", 1.0f / duration);
        
        StartCoroutine(WaitForAudioToEnd(duration));

    }

    private IEnumerator WaitForAudioToEnd(float duration)
    {
        yield return new WaitForSeconds(duration);
        isAudioPlaying = false;
        animator.SetFloat("speedMultiplier", 1.0f);// Reseta a velocidade da animação
        animator.enabled = false;
        UpdateButtonSprite();

    }

    public void OnHover()
    {
        if (playCount < hoverSprites.Length)
        {
            Debug.Log(normalSprites[2].name);
            image.sprite = hoverSprites[playCount];
        }
    }

    public void ExitHover()
    {
        if (playCount < normalSprites.Length)
        {
            image.sprite = normalSprites[playCount];
        }
    }

    private void UpdateButtonSprite()
    {
        // Atualiza o sprite com base no número de vezes que o áudio foi reproduzido
        if (playCount < normalSprites.Length)
        {
            Debug.Log("atualizou");
            image.sprite = normalSprites[playCount];
            legenda.SetActive(false);
        }
    }

}
