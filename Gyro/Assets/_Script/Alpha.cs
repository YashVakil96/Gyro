using UnityEngine;
using System.Collections.Generic;
public class Alpha : MonoBehaviour
{
    #region Variable

    public static List<string> Ballcount=new List<string>();

    private TrailRenderer Tail;
    private GameObject ball;
    private float alpha;

    #endregion


    #region System Methods
    private void Start()
    {
        ball = GameObject.Find(BallScript.ObjectName);
        Tail = ball.GetComponent<TrailRenderer>();
        alpha = Tail.startColor.a;
    }//start

    private void Update()
    {
        Debug.Log("here");
        alpha -= Time.deltaTime;
        Tail.startColor = new Color(Tail.startColor.r, Tail.startColor.g, Tail.startColor.b, alpha);
        Tail.endColor = new Color(Tail.endColor.r, Tail.endColor.g, Tail.endColor.b, alpha);

    }//Update

    #endregion


    #region User Methods

    #endregion

}//class
