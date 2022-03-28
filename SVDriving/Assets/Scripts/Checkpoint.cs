using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using TMPro;

public  class Checkpoint : MonoBehaviour
{

    public TextMeshProUGUI checkPointDisplay;
    public static List<string> Checkpoints = new List<string>();



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            checkPointDisplay.text = "Checkpoint 1";
        }
        if (other.CompareTag("Start"))
        {
            if (Checkpoints.Count == 0)
            {
                FindObjectOfType<CompleteLap>().getHighScore();
            }
        }
        Debug.Log("HIT");
        if (other.CompareTag("checkpoint1"))
        {
            if (Checkpoints.Count == 0)
            {
                Debug.Log("CP1ADD");
                Checkpoints.Add("CP1");
                checkPointDisplay.text = "Checkpoint 1";
            }
        }
        if (other.CompareTag("checkpoint2"))
        {
            if (Checkpoints.Count == 1)
            {
                if (Checkpoints[0] == "CP1")
                {
                    Debug.Log("CP2ADD");
                    Checkpoints.Add("CP2");
                    checkPointDisplay.text = "Checkpoint 2";
                }
            }

        }
        if (other.CompareTag("checkpoint3"))
        {
            if (Checkpoints.Count == 2)
            {
                if (Checkpoints[0] == "CP1" && Checkpoints[1] == "CP2")
                {
                    Debug.Log("CP3ADD");
                    Checkpoints.Add("CP3");
                    checkPointDisplay.text = "Checkpoint 3";
                }
            }
        }
        if (other.CompareTag("checkpoint4"))
        {
            if (Checkpoints.Count == 3)
            {
                if (Checkpoints[0] == "CP1" && Checkpoints[1] == "CP2" && Checkpoints[2] == "CP3")
                {
                    Debug.Log("CP4ADD");
                    Checkpoints.Add("CP4");
                    checkPointDisplay.text = "Checkpoint 4";
                }
            }
        }
        if (other.CompareTag("FL"))
        {
            if (Checkpoints.Count == 4)
            {
                if (Checkpoints[0] == "CP1" && Checkpoints[1] == "CP2" && Checkpoints[2] == "CP3" && Checkpoints[3] == "CP4")
                {
                    Checkpoints.Add("Finish");
                    checkPointDisplay.text = "Finished!";
                    FindObjectOfType<CompleteLap>().setLapTime();
                    FindObjectOfType<CompleteLap>().getHighScore();
                }
            }
        }

    }
  
}
