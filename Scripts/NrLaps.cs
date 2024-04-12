using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NrLaps : MonoBehaviour
{
    public static int LapFromUser = 1;
   //set the numbers of laps 
    public void oneLap()
     {
        LapFromUser = 1;
     }
    public void twoLap()
    {
        LapFromUser = 2;
    }

}
