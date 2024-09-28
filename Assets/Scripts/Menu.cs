using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] int gameScene;
    [SerializeField] GameObject soundPanel;
    [SerializeField] AudioSource buttonClickSound;

    // Start is called before the first frame update
    void Start()
    {
        soundPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        buttonClickSound.Play();
        SceneManager.LoadScene(gameScene);
    }

    public void OnClick()
    {
        buttonClickSound.Play();
        soundPanel.SetActive(true);
    }
}
