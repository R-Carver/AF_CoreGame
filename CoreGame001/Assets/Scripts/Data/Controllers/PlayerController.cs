using System.Collections.Generic;
using System.Collections;
using System;

public class PlayerController
{
    public static PlayerController Instance{get; protected set;}

    // The List od f all players
    // TODO: later we should maybe consider thinking about the efficiency of the whole data processing
    // there will be probably a lot of searching and filtering so lets do a research to see 1. if its really
    // enough data that it is relevant and 2. what datasturcutes or combinations of data sructs make most sense.
    List<Data_Player_Main> players = new List<Data_Player_Main>();

    // is set from the FileLoader
    public string[] playerDataLines;

    public PlayerController()
    {
        if(Instance != null)
        {
            Console.WriteLine("There should never be two Player Containers");
        }
        Instance = this;
    }

    public void InitPlayersFromFile()
    {
        for(int i=1; i<playerDataLines.Length ; i++)
        {
            string[] row = playerDataLines[i].Split(new char[]{','});

            // create temp player
            Data_Player_Main newPlayer = new Data_Player_Main();

            // use player counter as id
            newPlayer.playerId = Data_Player_Main.playerCount;
            
            newPlayer.name = row[0];
            newPlayer.team = row[1];
            int.TryParse(row[2], out newPlayer.age);
            int.TryParse(row[3], out newPlayer.currentAbility);
            int.TryParse(row[4], out newPlayer.potentialAbility);

            PlayerPosition tempPos = (PlayerPosition)System.Enum.Parse( typeof(PlayerPosition), row[5] );
            newPlayer.position = tempPos;

            // add player to global player list
            players.Add(newPlayer);

        }
    }

    public List<Data_Player_Main> GetPlayers()
    {
        return players;
    }

    public string[] GetAllPlayersString()
    {
        string[] outString = new string[players.Count];
        int i = 0;
        foreach(Data_Player_Main player in players)
        {
            outString[i] = player.GetPlayerString();
            i++;
        }
        return outString;
    } 
}