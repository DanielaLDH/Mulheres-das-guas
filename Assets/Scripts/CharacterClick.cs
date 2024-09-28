using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image CharacterMap;

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
        CharacterMap.gameObject.SetActive(true);
    }
}
