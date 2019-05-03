using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View_PlayerList : MonoBehaviour
{   

    public GameObject prefab;
    RectTransform prefabRect;

    Vector3 startPos;
    float height;
    // Start is called before the first frame update
    void Start()
    {   
        prefabRect = (RectTransform)prefab.transform;
        startPos = prefabRect.anchoredPosition;
        height = prefabRect.rect.height;

        /* float yOffset = 0;
        Vector3 offsetY = new Vector3(0, yOffset, 0);
        for(int i=0; i<4 ; i++)
        {
            //GameObject newItem = Instantiate(prefab, startPos, Quaternion.identity);
            GameObject newItem = Instantiate(prefab);
            newItem.transform.SetParent(this.transform);
            RectTransform rect = (RectTransform)newItem.transform;
            //rect.anchoredPosition = startPos;
            rect.localScale = new Vector3(1,1,1);
            rect.anchoredPosition = startPos + offsetY;

            yOffset += height;
            offsetY = new Vector3(0, -yOffset, 0);
        }*/

        initPlayerList(PlayerController.Instance.GetPlayers());
        
    }

    void initPlayerList(List<Data_Player_Main> players)
    {   
        float yOffset = 0;
        Vector3 offsetY = new Vector3(0, yOffset, 0);

        foreach(Data_Player_Main player in players)
        {
            GameObject newItem = Instantiate(prefab);
            newItem.transform.SetParent(this.transform);
            RectTransform rect = (RectTransform)newItem.transform;
            rect.localScale = new Vector3(1,1,1);
            rect.anchoredPosition = startPos + offsetY;

            // pass the player data to the list item
            View_PlayerList_Item item_script = newItem.transform.GetComponent<View_PlayerList_Item>();
            item_script.SetPlayerData(player);
            item_script.loadData();

            yOffset += height;
            offsetY = new Vector3(0, -yOffset, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
