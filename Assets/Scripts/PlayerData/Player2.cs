﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player2 : Player
{
    public static Player2 instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(transform.gameObject);
        PlayerID =2;
        tech = 1;
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
