using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;
using UnityEngine.UI;

public class CompleteLap : MonoBehaviour
{
    public GameObject LapCompleteTrig;

    public GameObject BestMinuteDisplay;
    public GameObject BestSecondDisplay;
    public GameObject BestMilisecondDisplay;
    public Usercredentials usercredentials;
    public LevelGameplayMaintenance LevelGameplayMaintenance;
    public Checkpoint checkPoint;
    public int[] bestTime;
    public String Username;
    private int currentMinutes;
    private int currentSeconds;
    private string currentMiliseconds;
    private int bestMinutes;
    private int bestSeconds;
    private int bestMiliseconds;

    public String currentdir = Directory.GetCurrentDirectory();
    public String userscorePath = Usercredentials.currentdir + "\\Assets\\Userinfo\\Score.txt";
    public List<string> Scores = new List<string>();
   
    //public static string []

    public GameObject LapTimerBox;

    private void finishLap()
    {
       
    }
    public void getHighScore()
    {
        if(bestMinutes == 0 && bestSeconds ==0 && bestMiliseconds == 0)
        {
            bestMinutes = 99;
            bestSeconds = 99;
            bestMiliseconds = 9;
        }
        
        Scores = File.ReadAllLines(userscorePath).ToList();
        String[] lineEntry;
        String[] timeEntry;
        int timeEntrymili;
        int timeEntrySecond;
        int timeEntryminute;

        foreach (String laptime in Scores)
        {
            lineEntry = laptime.Split(' ');
            timeEntry = lineEntry[1].Split(':');
            timeEntryminute = Int16.Parse(timeEntry[0]);
            timeEntrySecond = Int16.Parse(timeEntry[1]);
            timeEntrymili = Int16.Parse(timeEntry[2]);
            Debug.Log("minute" + currentMinutes);
            Debug.Log("second" + currentSeconds);
            Debug.Log("milisec" + currentMiliseconds);
            

            if (timeEntryminute <= bestMinutes)
            {
                
                if (timeEntrySecond <= bestSeconds)
                {
                   
                    if (timeEntrySecond == bestSeconds)
                    {
                        if (timeEntrymili < bestMiliseconds)
                        {
                           
                            bestMinutes = timeEntryminute;
                            bestSeconds = timeEntrySecond;
                            bestMiliseconds = timeEntrymili;
                        }
                        
                    }
                    if (timeEntrySecond < bestSeconds)
                    {
                        bestMinutes = timeEntryminute;
                        bestSeconds = timeEntrySecond;
                        bestMiliseconds = timeEntrymili;
                    }
                }
            }
        }

        BestMinuteDisplay.GetComponent<Text>().text = bestMinutes +":";
        BestSecondDisplay.GetComponent<Text>().text = bestSeconds + ":";
        BestMilisecondDisplay.GetComponent<Text>().text = bestMiliseconds +"";
        
    }
    public void setLapTime()
    {
        currentMinutes = FindObjectOfType<LevelGameplayMaintenance>().getMinutes();
        currentSeconds = FindObjectOfType<LevelGameplayMaintenance>().getSeconds();
        currentMiliseconds = FindObjectOfType<LevelGameplayMaintenance>().getMiliseconds();
        String currentSecondsStr;
        String currentMinutesStr;
        if (currentSeconds < 9)
        {
            currentSecondsStr = "0" + currentSeconds; 
        }
        else
        {
            currentSecondsStr = currentSeconds +"";
        }

        if (currentMinutes < 9 )
        {
            currentMinutesStr = "0" + currentMinutes;
        }
        else
        {
            currentMinutesStr =  currentMinutes +"";
        }
        Usercredentials uc = new Usercredentials();
       // LevelGameplayMaintenance GPM = new LevelGameplayMaintenance();
        Username = uc.getusername();
       
        String score = (Username + " " + currentMinutesStr + ":" + currentSecondsStr + ":" + currentMiliseconds);
        Scores.Add(score);
        File.WriteAllLines(userscorePath, Scores);
    }

    private void onTriggerEnter()
    {
   

     
        // read top score and retreve;
        // if minutes <= top minutes -> if seconds <= top seconds if miliseconds < topmilli seconds 
        if (LevelGameplayMaintenance.Seconds <= 9)
        {
       BestSecondDisplay.GetComponent<Text> ().text ="0" + LevelGameplayMaintenance.Seconds + ".";
        }
        else
        {
            BestSecondDisplay.GetComponent<Text>().text = "" + LevelGameplayMaintenance.Seconds + ".";
        }

        if (LevelGameplayMaintenance.Seconds <= 9)
        {
            BestSecondDisplay.GetComponent<Text>().text = "0" + LevelGameplayMaintenance.Seconds + ".";
        }
        else
        {
            BestSecondDisplay.GetComponent<Text>().text = "" + LevelGameplayMaintenance.Seconds + ".";
        }



    }

}
