using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AICar : MonoBehaviour
{
    #region 
    private struct structAI
    {
        public Transform checkpoints;
        public int idx;
        public Vector3 directionSteer;
        public Quaternion rotationSteer;
    }
    #endregion

    public float MoveSpeed = 1.0f;
    public float TurnSpeed = 0.1f;
    private Rigidbody rb = null;
    private structAI ai;
    public int gameLoserScene;

    int counter_Laps = 0;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        ai.checkpoints = GameObject.FindWithTag("WaypointsAI").transform;
        ai.idx = 0;
    }
    private void FixedUpdate()
    {
        //turn
        ai.directionSteer = ai.checkpoints.GetChild(ai.idx).position - this.transform.position;
        ai.rotationSteer = Quaternion.LookRotation(ai.directionSteer);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, ai.rotationSteer, TurnSpeed);

        //move
        rb.AddRelativeForce(Vector3.forward * MoveSpeed, ForceMode.VelocityChange);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint") == true)
        {
            ai.idx = CalcNextCheckpoint();
        }
    }
    private int CalcNextCheckpoint()
    {
        int curr = ExtractNumberFromString(ai.checkpoints.GetChild(ai.idx).name);
        int next = curr + 1;
        if (next > ai.checkpoints.childCount - 1)
        {
            next = 0;
            //calculate also if the player are the loser
            if (NrLaps.LapFromUser == 1)
                SceneManager.LoadScene(gameLoserScene);
            if (NrLaps.LapFromUser == 2 && counter_Laps == 1)
            { 
               SceneManager.LoadScene(gameLoserScene);
            }
            counter_Laps++;
        }
        Debug.Log(string.Format("current checkpoint {0}, next {1}", curr, next));

        return next;
    }
    private int ExtractNumberFromString(string s1)
    {
        return System.Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(s1, "[^0-9]", ""));
    }
}