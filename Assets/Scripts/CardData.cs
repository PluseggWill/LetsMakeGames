using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData
{
    public int id = 0;
    public string imageSprite = "";
    public int tech = 0;
    public int art = 0;
    public int design = 0;
    public int cost = 0;
    public int money = 0;
    public int reputation = 0;
    public int requiredReputation = 0;
    public GameType gameType;
    public bool isDeving;
}

public enum CardType { Faculty, Game, Market };
public enum CardPosition { Faculty, Market, PlayerFaculty, PlayerGame};
public enum GameType {Act, Rpg, Fps, Mobile, Sports};