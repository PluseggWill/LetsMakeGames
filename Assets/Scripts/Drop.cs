using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public CardType dropType;
    public Player currentPlayer;

    private void FixedStart() {

        currentPlayer = GameManager.instance.players[GameManager.instance.currentPlayer];

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
            currentPlayer.faculty.Add(d.cardData);

        }

    }

    private void MakeGame(Card d)
    {
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

    public void ChangePlayer(int playerNum)
    {
        currentPlayer = GameManager.instance.players[playerNum-1];
    }
}
