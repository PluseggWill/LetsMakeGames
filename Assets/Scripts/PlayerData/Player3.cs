using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player3 : Player
{

    public static Player3 instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(transform.gameObject);
        PlayerID = 3;
        tech = 0;
        design = 0;
        art = 0;
        money = 5;
    }

    void Update()
    {

        techNum.text = this.tech.ToString();
        designNum.text = this.design.ToString();
        artNum.text = this.art.ToString();
        moneyNum.text = "Money:" + this.money.ToString();
        reputationNum.text = "Reputation:" + this.reputation.ToString();
        //Debug.Log(tech);

        // Debug.log(GameManager.Player.Game[0]);
    }

}
