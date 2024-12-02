using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsGameManager : MonoBehaviour
{
    public bool[] gameDone;
    [SerializeField] int gameCountToWin;
    [SerializeField] Image mapIcon;
    [SerializeField] Image changeIcon;
    [SerializeField] CharacterClick characterClick;
    [SerializeField] MoneyManagement moneyManagement;

    [SerializeField] GameObject musicSound;

    [SerializeField] GameObject memoryGame;

    private MusicManager musicManager;
    private int index = 0;

    private void Start()
    {
        gameDone = new bool[gameCountToWin];
        musicManager = musicSound.GetComponent<MusicManager>();
    }

    public void WinVerification(bool gameResult)
    {
        if (index >= gameDone.Length)
        {
            Debug.Log("game is done");

            mapIcon.sprite = changeIcon.sprite;
            RectTransform rectTransform = mapIcon.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(369.1146f, 522.0625f);



            moneyManagement.AddMoney(4);

            memoryGame.SetActive(true);
            musicManager.CompletePhase();
        }
        else
        {
            Debug.Log($"Índice atual: {index}");
            gameDone[index] = gameResult;
            index++;
            
        }
    }
}
