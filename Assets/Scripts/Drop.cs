using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CardType dropType;
    public Player currentPlayer;

    private void Start() {

        //if (GameManager.instance.players[0] == null)
        //{

        //    Debug.Log("xxxx");
        //}
        Debug.Log(GameManager.instance);
        

    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card d = eventData.pointerDrag.GetComponent<Card>();
        currentPlayer = GameManager.instance.players[GameManager.instance.currentPlayer-1];
        if (d != null)
        {
            if (d.cardType == dropType 
                && d.cardType == CardType.Faculty 
                && currentPlayer.reputation >= d.cardData.requiredReputation
                && currentPlayer.money >= d.cardData.cost)
            {
                BuyFaculty(d);
            }

            else if(d.cardType == dropType 
                    && d.cardType == CardType.Game 
                    && currentPlayer.reputation >= d.cardData.requiredReputation
                    && currentPlayer.tech >= d.cardData.tech
                    && currentPlayer.art >= d.cardData.art
                    && currentPlayer.design >= d.cardData.design)
            {
                MakeGame(d);
            }
        }
    }

    private void BuyFaculty(Card d)
    {
        
        {
            d.parentCanvas = this.transform;
            currentPlayer.tech += d.cardData.tech;
            currentPlayer.art += d.cardData.art;
            currentPlayer.design += d.cardData.design;
            currentPlayer.reputation += d.cardData.reputation;
            currentPlayer.money = currentPlayer.money - d.cardData.cost + d.cardData.money;

            d.cardPosition = CardPosition.PlayerFaculty;
            
            Debug.Log("faculty bought! "+ d.cardData.imageSprite);
            currentPlayer.faculty.Add(d.cardData);
            GameObject cardManager = GameObject.Find("CardManager");
            cardManager.GetComponent<CardManager>().DrawCard(CardType.Faculty);
        }

    }

    private void MakeGame(Card d)
    {
        d.parentCanvas = this.transform;
        currentPlayer.tech -= 1;
        currentPlayer.art -= 1;
        currentPlayer.design -= 1;
        currentPlayer.money += d.cardData.money;
        currentPlayer.reputation += d.cardData.reputation;

        d.cardPosition = CardPosition.DevGame;
        d.cardData.isDeving = true;
        currentPlayer.games.Add(d.cardData);
        int k = currentPlayer.cards.FindIndex(a=>a.id == d.cardData.id);
        currentPlayer.cards.RemoveAt(k);
    }
}
