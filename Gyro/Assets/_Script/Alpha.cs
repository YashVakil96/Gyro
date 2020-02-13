using UnityEngine;

public class Alpha : MonoBehaviour
{
    #region Variable

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
        if(BallScript.Dead)
        {
            Debug.Log("here");
            alpha -= Time.deltaTime;
            Tail.startColor = new Color(Tail.startColor.r, Tail.startColor.g, Tail.startColor.b, alpha);
            Tail.endColor = new Color(Tail.endColor.r, Tail.endColor.g, Tail.endColor.b, alpha);
            if(alpha<=0)
            {
                alpha = 0;
                Destroy(ball);
                BallScript.Dead = false;
            }

        }//if Ball is Dead

    }//Update

    #endregion


    #region User Methods

    #endregion

}//class
