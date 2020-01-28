using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject facultyPool;
    public GameObject marketPool;
    public GameObject currentGamePool;
    private Dictionary<int, CardData>[] deckData;
    private Dictionary<int, CardData> gameCardData;
    private Dictionary<int, CardData> marketCardData;

    void Start()
    {
        LoadDeck();
        DrawCard(CardType.Faculty);
    }

    private void LoadDeck()
    {
        deckData = new Dictionary<int, CardData>[3];

        // faculty data
        deckData[0] = new Dictionary<int, CardData>()
        {
            { 0, new CardData { id = 0, imageSprite = "Cards/Empty Card", tech = 0, art = 0, design = 0, cost = 0, money = 0, reputation = 0, requiredReputation = 0 } },
            { 1, new CardData { id = 1, imageSprite = "Cards/Outsourcing Faculty Card", tech = 1, art = 0, design = 0, cost = 0, money = 0, reputation = 0, requiredReputation = 0 } },
        };

        // game data
        deckData[1] = new Dictionary<int, CardData>()
        {
            { 0, new CardData {imageSprite = "Cards/BasicGameCards/ACTGameCard", tech = 1, art = 3, design = 1, money = 4, reputation = 1} }
        };

        // market data
        deckData[2] = new Dictionary<int, CardData>()
        {
            { 0, new CardData {imageSprite = "Cards/BasicGameCards/ACTGameCard", tech = 1, art = 3, design = 1, money = 4, reputation = 1} }
        };
    }

    public void DrawCard(CardType type)
    {
        int rand;
        CardData tempData = new CardData();

        rand = Random.Range(0, deckData[(int)type].Count);
        deckData[(int)type].TryGetValue(rand, out tempData);
        Debug.Log(type + " card drawed, id == " + tempData.id);
        CreateCard(tempData, type);
    }

    public void CreateCard(CardData cardData, CardType type)
    {
        GameObject cardInstance = (GameObject)Instantiate(Resources.Load("Prefab/Card"));
        Card card = cardInstance.GetComponent<Card>();

        // set parent pool
        if (type == CardType.Faculty){ 
            card.parentCanvas = facultyPool.transform;
            card.cardPosition = CardPosition.Faculty;
        }
        else if (type == CardType.Game){ 
            card.parentCanvas = currentGamePool.transform;
            card.cardPosition = CardPosition.PlayerGame;
        }
        else if (type == CardType.Market){ 
            card.parentCanvas = marketPool.transform;
            card.cardPosition = CardPosition.Market;
        }

        card.cardImage.sprite = Resources.Load<Sprite>(cardData.imageSprite);
        card.cardData = cardData;
        card.cardType = type;
    }
}
