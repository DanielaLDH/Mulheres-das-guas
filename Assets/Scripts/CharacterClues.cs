using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClues : MonoBehaviour
{

    [SerializeField] GameObject blur;
    [SerializeField] GameObject Audio;
    [SerializeField] FalasManager falasManager; // Referência ao FalasManager
    [SerializeField] AmbManager ambManager;
    [SerializeField] string audioEventPath;

    private MusicManager musicManager;

    void OnEnable()
    {
        musicManager = Audio.GetComponent<MusicManager>();
        ambManager.Play(audioEventPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExit()
    {
        gameObject.SetActive(false);
        blur.SetActive(false);
        musicManager.EnterMap();
        ambManager.Stop();
        // Para a fala atual
        if (falasManager != null)
        {
            falasManager.StopCurrentFala();
        }

    }
}
