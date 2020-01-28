using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject facultyPool;
    public GameObject marketPool;
    public GameObject gamePool;
    public GameObject handPool;
    public Player currentPlayer;
    private Dictionary<int, CardData>[] deckData;
    private List<int> facultyKey;
    private List<int> gameKey;
    private Dictionary<int, CardData> gameCardData;
    private Dictionary<int, CardData> marketCardData;

    void FixedStart()
    {
        
        LoadDeck();
        ChangePlayer(GameManager.instance.currentPlayer); ;
        ShuffleFacultyCard(deckData[0].Count);
        ShuffleGameCard(deckData[1].Count);
        for (int i = 0;i<5;i++)
        {
            DrawCard(CardType.Faculty);
        }
        for (int i = 0;i<3;i++)
        {
            DrawCard(CardType.Market);
        }
        DrawCard(CardType.Game);
    }

    private void LoadDeck()
    {
        currentPlayer = GameManager.instance.players[0];
        deckData = new Dictionary<int, CardData>[3];

        // faculty data
        deckData[0] = new Dictionary<int, CardData>()
        {
            { 0, new CardData { id = 0, imageSprite = "Cards/Faculty/Artist", tech = 0, art = 3, design = 0, cost = 2} },
            { 1, new CardData { id = 1, imageSprite = "Cards/Faculty/Artist", tech = 0, art = 3, design = 0, cost = 2} },
            { 2, new CardData { id = 2, imageSprite = "Cards/Faculty/Artist", tech = 0, art = 3, design = 0, cost = 2} },
            { 3, new CardData { id = 3, imageSprite = "Cards/Faculty/Artist", tech = 0, art = 3, design = 0, cost = 2} },
            { 4, new CardData { id = 4, imageSprite = "Cards/Faculty/Designer", tech = 0, art = 0, design = 3, cost = 2} },
            { 5, new CardData { id = 5, imageSprite = "Cards/Faculty/Designer", tech = 0, art = 0, design = 3, cost = 2} },
            { 6, new CardData { id = 6, imageSprite = "Cards/Faculty/Designer", tech = 0, art = 0, design = 3, cost = 2} },
            { 7, new CardData { id = 7, imageSprite = "Cards/Faculty/Designer", tech = 0, art = 0, design = 3, cost = 2} },
            { 8, new CardData { id = 8, imageSprite = "Cards/Faculty/Programmer", tech = 3, art = 0, design = 0, cost = 2} },
            { 9, new CardData { id = 9, imageSprite = "Cards/Faculty/Programmer", tech = 3, art = 0, design = 0, cost = 2} },
            { 10, new CardData { id = 10, imageSprite = "Cards/Faculty/Programmer", tech = 3, art = 0, design = 0, cost = 2} },
            { 11, new CardData { id = 11, imageSprite = "Cards/Faculty/Programmer", tech = 3, art = 0, design = 0, cost = 2} },
            { 12, new CardData { id = 12, imageSprite = "Cards/Faculty/Level", tech = 2, art = 0, design = 2, cost = 3} },
            { 13, new CardData { id = 13, imageSprite = "Cards/Faculty/Level", tech = 2, art = 0, design = 2, cost = 3} },
            { 14, new CardData { id = 14, imageSprite = "Cards/Faculty/Level", tech = 2, art = 0, design = 2, cost = 3} },
            { 15, new CardData { id = 15, imageSprite = "Cards/Faculty/TA", tech = 2, art = 2, design = 0, cost = 3} },
            { 16, new CardData { id = 16, imageSprite = "Cards/Faculty/TA", tech = 2, art = 2, design = 0, cost = 3} },
            { 17, new CardData { id = 17, imageSprite = "Cards/Faculty/TA", tech = 2, art = 2, design = 0, cost = 3} },
            { 18, new CardData { id = 18, imageSprite = "Cards/Faculty/Builder", tech = 0, art = 2, design = 2, cost = 3} },
            { 19, new CardData { id = 19, imageSprite = "Cards/Faculty/Builder", tech = 0, art = 2, design = 2, cost = 3} },
            { 20, new CardData { id = 20, imageSprite = "Cards/Faculty/Builder", tech = 0, art = 2, design = 2, cost = 3} },
            { 21, new CardData { id = 21, imageSprite = "Cards/Faculty/Junichi", tech = 3, art = 3, design = 0, cost = 4, money = 1, reputation = -1} },
            { 22, new CardData { id = 22, imageSprite = "Cards/Faculty/Kojima", tech = 0, art = 2, design = 5, cost = 5, requiredReputation = 5, reputation = 1} },
            { 23, new CardData { id = 23, imageSprite = "Cards/Faculty/Miyamoto", tech = 4, art = 0, design = 4, cost = 5} },
            { 24, new CardData { id = 24, imageSprite = "Cards/Faculty/Sid", tech = 2, art = 0, design = 5, cost = 5} },
            { 25, new CardData { id = 25, imageSprite = "Cards/Faculty/Takashi", tech = 0, art = 5, design = 1, cost = 4} },
        };

        // game data
        deckData[1] = new Dictionary<int, CardData>()
        {
            { 0, new CardData {id = 0, imageSprite = "Cards/Game/ACT", tech = 1, art = 3, design = 1, money = 4, reputation = 1, gameType = GameType.Act} },
            { 1, new CardData {id = 1, imageSprite = "Cards/Game/ACT", tech = 1, art = 3, design = 1, money = 4, reputation = 1, gameType = GameType.Act} },
            { 2, new CardData {id = 2, imageSprite = "Cards/Game/ACT", tech = 1, art = 3, design = 1, money = 4, reputation = 1, gameType = GameType.Act} },
            { 3, new CardData {id = 3, imageSprite = "Cards/Game/FPS", tech = 3, art = 1, design = 1, money = 4, reputation = 1, gameType = GameType.Fps} },
            { 4, new CardData {id = 4, imageSprite = "Cards/Game/FPS", tech = 3, art = 1, design = 1, money = 4, reputation = 1, gameType = GameType.Fps} },
            { 5, new CardData {id = 5, imageSprite = "Cards/Game/FPS", tech = 3, art = 1, design = 1, money = 4, reputation = 1, gameType = GameType.Fps} },
            { 6, new CardData {id = 6, imageSprite = "Cards/Game/Mobile", tech = 1, art = 2, design = 1, money = 5, reputation = -1, gameType = GameType.Mobile} },
            { 7, new CardData {id = 7, imageSprite = "Cards/Game/Mobile", tech = 1, art = 2, design = 1, money = 5, reputation = -1, gameType = GameType.Mobile} },
            { 8, new CardData {id = 8, imageSprite = "Cards/Game/Mobile", tech = 1, art = 2, design = 1, money = 5, reputation = -1, gameType = GameType.Mobile} },
            { 9, new CardData {id = 9, imageSprite = "Cards/Game/RPG", tech = 1, art = 1, design = 3, money = 4, reputation = 1, gameType = GameType.Rpg} },
            { 10, new CardData {id = 10, imageSprite = "Cards/Game/RPG", tech = 1, art = 1, design = 3, money = 4, reputation = 1, gameType = GameType.Rpg} },
            { 11, new CardData {id = 11, imageSprite = "Cards/Game/RPG", tech = 1, art = 1, design = 3, money = 4, reputation = 1, gameType = GameType.Rpg} },
            { 12, new CardData {id = 12, imageSprite = "Cards/Game/Sports1", tech = 1, art = 2, design = 2, money = 4, reputation = 1, gameType = GameType.Sports} },
            { 13, new CardData {id = 13, imageSprite = "Cards/Game/Sports2", tech = 2, art = 1, design = 2, money = 4, reputation = 1, gameType = GameType.Sports} },
            { 14, new CardData {id = 14, imageSprite = "Cards/Game/Sports3", tech = 2, art = 2, design = 1, money = 4, reputation = 1, gameType = GameType.Sports} },
            { 15, new CardData {id = 15, imageSprite = "Cards/Game/2K", tech = 4, art = 6, design = 2, money = 9, reputation = 2, gameType = GameType.Sports} },
            { 16, new CardData {id = 16, imageSprite = "Cards/Game/BF", tech = 4, art = 6, design = 5, money = 8, reputation = 4, gameType = GameType.Fps} },
            { 17, new CardData {id = 17, imageSprite = "Cards/Game/COD", tech = 6, art = 3, design = 3, money = 8, reputation = 4, gameType = GameType.Fps} },
            { 18, new CardData {id = 18, imageSprite = "Cards/Game/FF", tech = 5, art = 7, design = 3, money = 8, reputation = 6, gameType = GameType.Rpg} },
            { 19, new CardData {id = 19, imageSprite = "Cards/Game/FIFA", tech = 4, art = 2, design = 3, money = 6, reputation = 3, gameType = GameType.Sports} },
            { 20, new CardData {id = 20, imageSprite = "Cards/Game/GOW", tech = 6, art = 6, design = 6, money = 7, reputation = 7, gameType = GameType.Act} },
            { 21, new CardData {id = 21, imageSprite = "Cards/Game/MH", tech = 6, art = 7, design = 5, money = 9, reputation = 5, gameType = GameType.Act} },
            { 22, new CardData {id = 22, imageSprite = "Cards/Game/PM", tech = 1, art = 3, design = 5, money = 7, reputation = 2, gameType = GameType.Rpg} },
        };

        // market data
        deckData[2] = new Dictionary<int, CardData>()
        {
            { 0, new CardData {imageSprite = "Cards/Market/ACT", gameType = GameType.Act} },
            { 1, new CardData {imageSprite = "Cards/Market/FPS", gameType = GameType.Fps} },
            { 2, new CardData {imageSprite = "Cards/Market/RPG", gameType = GameType.Rpg} },
            { 3, new CardData {imageSprite = "Cards/Market/Mobile", gameType = GameType.Mobile} },
            { 4, new CardData {imageSprite = "Cards/Market/Sports", gameType = GameType.Sports} }
        };
    }

    public void DrawCard(CardType type)
    {
        int rand;
        CardData tempData = new CardData();

        if (type == CardType.Faculty)
        {
            if (facultyKey.Count == 0)
            {
                ShuffleFacultyCard(deckData[0].Count);
            }
            rand = facultyKey[0];
            facultyKey.RemoveAt(0);
        }
        else if (type == CardType.Game)
        {
            if (gameKey.Count == 0)
            {
                ShuffleGameCard(deckData[1].Count);
            }
            rand = gameKey[0];
            gameKey.RemoveAt(0);
        }
        else
        {
            rand = Random.Range(0, deckData[(int)type].Count);
        }

        deckData[(int)type].TryGetValue(rand, out tempData);
        //Debug.Log(type + " card drawed, card == " + tempData.imageSprite);
        CreateCard(tempData, type);

        if (type == CardType.Faculty)
        {
            currentPlayer.faculty.Add(tempData);
        }
        else if (type == CardType.Game)
        {
            currentPlayer.cards.Add(tempData);
        }
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
            card.parentCanvas = handPool.transform;
            card.cardPosition = CardPosition.Hand;
        }
        else if (type == CardType.Market){ 
            card.parentCanvas = marketPool.transform;
            card.cardPosition = CardPosition.Market;
            card.isDraggable = false;
        }

        card.cardImage.sprite = Resources.Load<Sprite>(cardData.imageSprite);
        Debug.Log(cardData.imageSprite);
        card.cardData = cardData;
        card.cardType = type;
    }

    private void ShuffleFacultyCard(int length)
    {
        int k;
        facultyKey = new List<int>();
        do{
            k = Random.Range(0,length);
            if (!facultyKey.Contains(k)) { facultyKey.Add(k);}
            Debug.Log(k);
        }
        while (facultyKey.Count < length);
    }

    private void ShuffleGameCard(int length)
    {
        int k;
        gameKey = new List<int>();
        do{
            k = Random.Range(0,length);
            if (!gameKey.Contains(k)) { gameKey.Add(k);}
        }
        while (gameKey.Count < length);
    }

    /*public void ChangePlayer(int playerNum)
    {

        Debug.Log("first");
        /*if(Player.instance == null)
        {
            currentPlayer = GameManager.instance.players[0];
        }
        else
        {
            currentPlayer = GameManager.instance.players[playerNum-1];
            Debug.Log("Next");
        }


    }*/
}
