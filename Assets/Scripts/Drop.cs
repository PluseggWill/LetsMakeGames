using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CardType dropType;
    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Drag d = eventData.pointerDrag.GetComponent<Drag>();
        if (d != null)
        {
            d.parentCanvas = this.transform;
        }
    }
}
