using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject CharacterMap;
    [SerializeField] GameObject blur;
    [SerializeField] Image anim;
    [SerializeField] GameObject memoryGameAbrilhante; // Referência ao MemoryGameAbrilhante


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (anim != null)
        {
            blur.SetActive(true);

            CharacterMap.gameObject.SetActive(true);

            anim.gameObject.SetActive(true);
            StartCoroutine(DisableAfterTime(6f)); // Inicia a Coroutine para desativar após 6 segundos

           
            
        }
        else
        {
            CharacterMap.gameObject.SetActive(true);
            blur.SetActive(true);
        }

        
    }

    public void ChangeCharacterMap(GameObject newGame)
    {
        CharacterMap = newGame;
    }

    IEnumerator DisableAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.gameObject.SetActive(false);
        memoryGameAbrilhante.gameObject.SetActive(true);

    }
}
