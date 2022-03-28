using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class LevelGameplayMaintenance : MonoBehaviour
{
    public  int Minutes;
    public  int Seconds;
    public  float milliseconds;
    public static string milliSdisplay;

    public GameObject MinuteBox;
    public GameObject SecondBox;
    public GameObject MilliBox;
    public  string[] Laptime;
    public int[] currentTime;

    public int getMinutes()
    {
        return Minutes;
    }
    public int getSeconds()
    {
        return Seconds;
    }
    public string getMiliseconds()
    {
        return milliSdisplay;

    }

    private void CalculateTime()
    {
        milliseconds += Time.deltaTime * 10; // converting From secconds to milli seconds
        milliSdisplay = milliseconds.ToString("F0"); // converting to string to pass to box component.
        MilliBox.GetComponent<Text> ().text = "" + milliSdisplay;
        if (milliseconds >= 10)
        {
            milliseconds = 0;
            Seconds++;
        }

        if(Seconds <= 9)
        {
            SecondBox.GetComponent<Text> ().text = "0" + Seconds + ".";
        }
        else
        {
            SecondBox.GetComponent<Text> ().text =  + Seconds + ".";
        }
        if(Seconds >= 60)
        {
            Seconds = 0;
            Minutes += 1;
        }
        if (Minutes <= 9)
        {
            MinuteBox.GetComponent<Text> ().text = "0" + Minutes + ":";
        }
        else
        {
            MinuteBox.GetComponent<Text> ().text =  + Minutes + ":";
        }

    }
    public static void returnTime()
    {
       // Laptime []
    }

    void Update()
    {
        CalculateTime();
    }

}
