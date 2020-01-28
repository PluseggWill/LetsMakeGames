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
    
    public Button nextRound;
    public Button restart;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(transform.gameObject);

        nextRound.onClick.AddListener(nextPlayer);
        Player player1 = new Player();
        players.Add(player1);
    }

    void nextPlayer()
    {
        

    }




}

    //void FixedUpdate


