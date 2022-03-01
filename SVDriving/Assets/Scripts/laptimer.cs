using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class laptimer : MonoBehaviour
{

float countdown = 3f;

public Text disvar;

void Update() 
{     
  if(countdown > 0)     
  {
   countdown -= Time.deltaTime;     
  }     
  double b = System.Math.Round (countdown, 2);     
  disvar.text = b.ToString ();     
  if(countdown < 0)     
  {
    disvar.text = "Go";
    
  } 

}
}