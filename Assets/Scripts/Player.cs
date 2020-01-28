using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour

{

    public int PlayerID;
    public int tech ;
    public int design;
    public int art;
    public int money;
    public int reputation;

    public Text techNum;
    public Text designNum;
    public Text artNum;
    public Text moneyNum;
    public Text reputationNum;

    //public static int currentPlayer;



    public bool isBuy = false; 

    public List<CardData> games = new List<CardData>();
    public List<CardData> faculty = new List<CardData>();
    public List<CardData> cards = new List<CardData>();
    
  
    
}
