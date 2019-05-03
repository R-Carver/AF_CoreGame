using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This is the main class to hold the player data.
It consists of all the basic infomation about a player and has
references to other player data like attributes, traits etc.
 */

public class Data_Player_Main
{   
    // incremental id
    public static int playerCount = 0;
    
    public Data_Player_Main()
    {
        playerCount ++;
    }

    public int playerId;
    public string name;
    public string team;
    public int age;
    public PlayerPosition position;
    public int currentAbility;
    public int potentialAbility;

    public string GetPlayerString()
    {
        return "NAME: " + name + "  TEAM: " + team + "  POS:" + position; 
    }

}
