using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   
    public DayMover DayMover;
    
    // Test StartDate 22 Sept 2018
    DateTime startDate = new DateTime(2018, 9, 22);

    DateController dateController;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        dateController = new DateController(startDate);
        playerController = PlayerController.Instance;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextDay()
    {
        dateController.moveOneDay();
        DayMover.moveCalendar();
    }
}
