﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player instance;

    public int tech;
    public int design;
    public int art;
    public int money;
    public int reputation;

    public List<Game> games = new List<Game>();
    //public List<DevelopingGame> devGame = new List<DevelopingGame>();



    // Start is called before the first frame update
    void Start()
    {
       // Game ACT1 = new Game("ACT Game",0);
    }

    // Update is called once per frame
    void Update()
    {
      // Debug.log(GameManager.Player.Game[0]);
    }
}
