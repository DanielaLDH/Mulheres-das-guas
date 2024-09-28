using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    [SerializeField] GameObject soundSlide;


    void Start()
    {
        soundSlide.SetActive(false);

    }

    public void OnMouseEnter()
    {
        soundSlide.SetActive(true);
    }
    public void OnMouseExit()
    {
        soundSlide.SetActive(false);
    }
}
