using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    private AudioSource audiosource;

    public AudioClip sfx_ui_play_hover;
    public AudioClip sfx_ui_play_click;
    public AudioClip sfx_ui_map_hover;
    public AudioClip sfx_ui_map_click;

    public AudioClip sfx_item_drag_x;
    public AudioClip sfx_item_interaction;
    public AudioClip sfx_item_play;
    public AudioClip sfx_item_right;
    public AudioClip sfx_item_wrong;

    public AudioClip sfx_ui_memory_click;
    public AudioClip sfx_ui_memory_play;
    public AudioClip sfx_memory_card_x;
    public AudioClip sfx_memory_right;
    public AudioClip sfx_memory_wrong;


    // Start is called before the first frame update
    void Awake()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void PlaySFX(AudioClip sfx)
    {
        Debug.Log(sfx);
        audiosource.PlayOneShot(sfx);
    }
}
