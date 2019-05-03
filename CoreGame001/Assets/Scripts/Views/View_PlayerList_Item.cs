using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View_PlayerList_Item : MonoBehaviour
{   
    Data_Player_Main player_data;

    Transform text_name;
    Transform text_age;
    Transform text_pos;
    Transform text_abl;
    Transform teamIcon;
    Transform faceIcon;

    void OnEnable() {
        text_name = this.gameObject.transform.Find("Text_Name");
        text_age = this.gameObject.transform.Find("Text_Age");
        text_pos = this.gameObject.transform.Find("Text_Pos");
        text_abl = this.gameObject.transform.Find("Text_Abl");
        teamIcon = this.gameObject.transform.Find("Team_Icon");
        faceIcon = this.gameObject.transform.Find("Face");
    }
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerData(Data_Player_Main data)
    {
        player_data = data;
    }

    public void loadData()
    {
        // call this when the item was created by the list
        Text nameText = text_name.GetComponent<Text>();
        nameText.text = player_data.name;

        Text ageText = text_age.GetComponent<Text>();
        ageText.text = player_data.age.ToString();

        Text posText = text_pos.GetComponent<Text>();
        posText.text = player_data.position.ToString();

        Text ablText = text_abl.GetComponent<Text>();
        ablText.text = player_data.currentAbility.ToString();

        loadTeamImg();
        loadFaceImg();
    }

    private void loadTeamImg()
    {
        Transform imgGo = teamIcon.Find("Image");
        Image img = imgGo.GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>( "Img/Team/" + player_data.team);
    }

    private void loadFaceImg()
    {
        Transform imgGo = faceIcon.Find("Image");
        Image img = imgGo.GetComponent<Image>();
        img.sprite = Resources.Load<Sprite>( "Img/Faces/" + player_data.name);
    }
}
