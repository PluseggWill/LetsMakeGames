using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Player> players = new List<Player>();

    public GameObject myCards;
    public GameObject myFaculty;
    public GameObject myGames;
    public GameObject WinPanel;

    public Text currentPlayerText;
    public Button nextRound;
    public Button restart;
    public int currentPlayer = 1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(transform.gameObject);


        nextRound.onClick.AddListener(nextPlayer);
        currentPlayerText.text = "Current Player: " + currentPlayer.ToString();
        //Player player1 = new Player();
        //players.Add(Player1.instance);

        /*players.Add(Player2.instance);
        players.Add(Player3.instance);
        players.Add(Player4.instance);*/
    }

    void nextPlayer()
    {
        currentPlayerText.text = "Current Player: " + currentPlayer.ToString();
        if (currentPlayer == 4)
        {
            currentPlayer = 1;
        }
        else currentPlayer++;
        loadMycards();

    }

    void loadMycards()
    {
        CardManager.instance.ClearCards();
        foreach(var i in players[currentPlayer - 1].games)
        {
            CardManager.instance.CreateCard(i, CardPosition.DevGame);
        }
        foreach (var i in players[currentPlayer - 1].faculty)
        {
            CardManager.instance.CreateCard(i, CardPosition.PlayerFaculty);
        }
        foreach (var i in players[currentPlayer - 1].cards)
        {
            CardManager.instance.CreateCard(i, CardPosition.Hand);
        }
    }

    void win()
    {
       
        // WinPamel.Setactive(true);
    }




}

    //void FixedUpdate


