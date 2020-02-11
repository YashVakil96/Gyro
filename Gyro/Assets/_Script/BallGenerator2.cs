using System.Collections;
using UnityEngine;

public class BallGenerator2 : MonoBehaviour
{
    #region Variable

    public static bool Hits;
    public static int Pattern;
    public static bool PatternRunning;
    public static int BallCount;

    public GameObject[] Balls;

    private int BallSelector;
    private Vector2 GenerationPoint;
    private Vector2 PreviousBallPos;

    #endregion


    #region System Methods

    private void Start()
    {
        Hits = true;
    }

    private void Update()
    {
        if(!PatternRunning && BallCount <=1)
        {
            GenerationPoint = GeneratingPoint();//Getting the spawnning point
            Pattern = Random.Range(0, 2);
            switch (Pattern)
            {
                case 0:

                    //Single Ball
                    SpawnBall();
                    Hits = false;

                    break;
                case 1:

                    //BallsRow
                    BallsRow();

                    break;
            }//Switch
            PatternRunning = true;
        }// Is PatternRunning FALSE
    }//Update
    #endregion


    #region User Define Methods
    Vector2 GeneratingPoint()
    {
        Vector2 Point=new Vector2(0,0);
        float x,y;
        int UD = Random.Range(1, 3);
        if(UD==1)
        {
            //Code for UP
            y = Random.Range(2.2f, 5.6f);//Random for height
            if(y < 5 && y > 2.2)
            {
                //Width should be -3 or 3
                x = Random.Range(0, 2) == 0 ? -3 : 3;
                Point = new Vector2(x, y); 
            }
            else if(y > 5 && y < 5.6)
            {
                //width can be Between -3 and 3
                x = Random.Range(-3f, 3.1f);
                Point = new Vector2(x, y);
            }
        }//IF UD
        else
        {
            //Code for Down
            y = Random.Range(-2.2f, -5.6f);//Random for height
            if (y > -5 && y < -2.2)
            {
                //Width should be -3 or 3
                x = Random.Range(0, 2) == 0 ? -3 : 3;
                Point = new Vector2(x, y);
            }
            else if (y < -5 && y > -5.6)
            {
                //width can be Between -3 and 3
                x = Random.Range(-3f, 3.1f);
                Point = new Vector2(x, y);
            }
        }
        return Point;

    }//Generating Point

    void SpawnBall() //Single Ball
    {
        if (GenerationPoint.x > PreviousBallPos.x - .5f && GenerationPoint.x < PreviousBallPos.x + .5f)
        {
            if (GenerationPoint.y > PreviousBallPos.y - .5f && GenerationPoint.y < PreviousBallPos.y + .5f)
            {
                GenerationPoint = GeneratingPoint();//Getting the spawnning point
            }
        }

        transform.position = GenerationPoint;//Ball Generator takes the position
        BallSelector = Random.Range(0, 3);
        //Check the previous postion
        Instantiate(Balls[BallSelector],transform.position,Quaternion.identity);
        PreviousBallPos = transform.position;
    }//SpawnBall

    void BallsRow()
    {
        BallSelector = Random.Range(0, 3);
        StartCoroutine(BallsRowEnum());
    }//BallsRow

    IEnumerator BallsRowEnum()
    {

        BallScript.SpeedStatic = 1;
        Instantiate(Balls[BallSelector], transform.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.5f);

        Instantiate(Balls[BallSelector], transform.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.5f);

        Instantiate(Balls[BallSelector], transform.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.5f);
    }

    #endregion

}//Class