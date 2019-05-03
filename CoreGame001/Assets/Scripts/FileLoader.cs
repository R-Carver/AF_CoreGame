using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileLoader : MonoBehaviour
{
    PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = new PlayerController();
        setPlayersFromFile();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setPlayersFromFile()
    {
        TextAsset playerDataFile = Resources.Load<TextAsset>("Text/Player_Main");
        playerController.playerDataLines =  playerDataFile.text.Split(new char[] {'\n'});

        playerController.InitPlayersFromFile();
        foreach(string playerString in playerController.GetAllPlayersString())
        {
            print(playerString);
        }
    }
}
