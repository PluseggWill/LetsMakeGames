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

    private int currentPlayer = 1;//player1234

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(transform.gameObject);

        nextRound.onClick.AddListener(nextPlayer);
    }

    void nextPlayer()
    {
        

    }




}

    //void FixedUpdate


