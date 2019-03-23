using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

class DateController
{   
    public static DateController Instance{get; protected set;}

    public DateTime firstDay{get; protected set;}
    public DateTime lastDay{get; protected set;}

    public DateTime currentDate{get; protected set;}
    public Queue<DateTime> recentDays{get; protected set;}

    public DateController(DateTime startDate)
    {   

        this.firstDay = startDate;

        // the visual calender has its current day not at the end but 
        // its the third position from the right
        this.currentDate = startDate.AddDays(-2);
        recentDays = new Queue<DateTime>();

        InitializeRecentDays(startDate);
        this.lastDay = recentDays.LastOrDefault();

        if(Instance != null)
        {
            Debug.Log("There should never be two DateControllers");
        }
        Instance = this;
    }

    void InitializeRecentDays(DateTime startDate)
    {   
        recentDays.Enqueue(startDate);

        // go back 7 days
        for(int i = 1 ; i <= 7 ; i++)
        {
            recentDays.Enqueue(startDate.AddDays(i));
        }
    }

    public void moveOneDay()
    {
        //remove last day
        recentDays.Dequeue();

        DateTime lastDay = recentDays.LastOrDefault();
        DateTime newLastDay = lastDay.AddDays(1);

        recentDays.Enqueue(newLastDay);
        Debug.Log("New Queue");
    
        this.firstDay = this.firstDay.AddDays(1);
        this.lastDay = this.lastDay.AddDays(1);
    }

    void PrintRecentDays()
    {
        foreach(DateTime day in recentDays)
        {
            Debug.Log(day);
        }
    }

}