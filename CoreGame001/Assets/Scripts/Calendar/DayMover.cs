using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayMover : MonoBehaviour
{   
    public RectTransform DayPanelPrefab;
    
    public RectTransform[] dayPanels;

    public bool nextDay = false;

    public float timeToMove = 5;
    float currentTime = 0;

    Vector2[] startPositions = new Vector2[7];
    Vector2[] endPositions = new Vector2[7];

    // Start is called before the first frame update
    void Start()
    {   
        // set the start and end positions for the panels
        // those should never change
        for(int i=0; i < dayPanels.Length-1 ; i++)
        {
            startPositions[i] = dayPanels[i].anchoredPosition;
            endPositions[i] = dayPanels[i+1].anchoredPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(nextDay)
        {
            StartCoroutine("LerpDayPanel");
            nextDay = false;
        }
    }

    IEnumerator LerpDayPanel()
    {   
        float normalizedValue = 0;
        while(currentTime <= timeToMove)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime/timeToMove;

            for(int i=0; i < dayPanels.Length-1 ; i++)
            {

                dayPanels[i].anchoredPosition = Vector2.Lerp(startPositions[i], endPositions[i], normalizedValue);
            }
            yield return null;
        }
        print("test");
        UpdateArray();
        currentTime = 0;
    }

    void UpdateArray()
    {
        // detroy last panel
        RectTransform lastPanel = dayPanels[dayPanels.Length-1];
        Destroy(lastPanel.gameObject);
        
        for(int i=dayPanels.Length-1; i > 0 ; i--)
        {   

            dayPanels[i] = dayPanels[i-1];
        }

        // Instantiate new first object
        Vector3 firstPos = new Vector3(startPositions[0].x, startPositions[0].y, 0);
        RectTransform newPanel = Instantiate(DayPanelPrefab, firstPos, Quaternion.identity);
        newPanel.SetParent(this.transform, false);
        dayPanels[0] = newPanel;
        newPanel.anchoredPosition = startPositions[0];
        
    }


}
