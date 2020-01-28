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

        //Player player1 = new Player();
        //players.Add(Player1.instance);
        
        /*players.Add(Player2.instance);
        players.Add(Player3.instance);
        players.Add(Player4.instance);*/
    }

    void nextPlayer()
    {
        if(currentPlayer == 4)
        {
            currentPlayer = 1;
        }
        else currentPlayer++;

    }

    void win()
    {
       // WinPamel.Setactive(true);
    }




}

    //void FixedUpdate


