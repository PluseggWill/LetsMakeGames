using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

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


    public bool isBuy = false; 

    public List<CardData> games = new List<CardData>();
    public List<CardData> faculty = new List<CardData>();
    public List<CardData> cards = new List<CardData>();
    




    // Start is called before the first frame update
    void Start()
    {
        tech = 10;
        design = 0;
        art = 0;

    }

    // Update is called once per frame
    void Update()
    {

        techNum.text = tech.ToString(); 
        designNum.text = design.ToString(); 
        artNum.text = art.ToString();
        Debug.Log(tech);
        
        // Debug.log(GameManager.Player.Game[0]);
    }
}
