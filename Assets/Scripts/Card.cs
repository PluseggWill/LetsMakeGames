using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler
{
    public CardData cardData;
    public Image cardImage;
    public CardPosition cardPosition;
    public CardType cardType;
    public Transform parentCanvas = null;

    void Start() {
        this.transform.SetParent(parentCanvas);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("onBeginDrag");
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        parentCanvas = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("onDrag");
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("onEndDrag");
        this.transform.SetParent(parentCanvas);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
