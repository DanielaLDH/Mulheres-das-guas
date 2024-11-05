using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] int codigo;
    [SerializeField] private TipsGameManager tipsGameManager;


    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            DragDrop draggedItem = eventData.pointerDrag.GetComponent<DragDrop>();

            if (draggedItem.codigo == codigo)
            {
                Debug.Log("correto");

                tipsGameManager.WinVerification(true);

                //posição do item e slot
                RectTransform draggedRect = eventData.pointerDrag.GetComponent<RectTransform>();
                RectTransform slotRect = GetComponent<RectTransform>();


                draggedRect.SetParent(slotRect);

                draggedRect.localPosition = Vector2.zero;

                draggedItem.SetAsPlaced();


            }
            else
            {
                draggedItem.ResetPosition();
            }

        }
    }

}
