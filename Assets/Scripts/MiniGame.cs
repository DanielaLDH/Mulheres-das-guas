using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{

    [SerializeField] GameObject blur;
    [SerializeField] GameObject Audio;

    private MusicManager musicManager;

    // Start is called before the first frame update
    void Start()
    {
        musicManager = Audio.GetComponent<MusicManager>();
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

    }
}
