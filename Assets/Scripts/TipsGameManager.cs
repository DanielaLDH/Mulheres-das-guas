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


    [SerializeField] GameObject memoryGame;


    private int index = 0;

    private void Start()
    {
        gameDone = new bool[gameCountToWin];
    }

    public void WinVerification(bool gameResult)
    {
        if (index >= gameDone.Length)
        {
            Debug.Log("game is done");
            mapIcon.sprite = changeIcon.sprite;
            moneyManagement.AddMoney(4);

            memoryGame.SetActive(true);
        }
        else
        {
            Debug.Log($"Índice atual: {index}");
            gameDone[index] = gameResult;
            index++;
            
        }
    }
}
