using UnityEngine;
using System.Collections;

public class BallGeneratorRaw : MonoBehaviour
{
    #region Variable

    public static bool IsBallAlive = false;
    public static bool TriggerGeneration = false;
    public static int BallCount;

    public Transform RotateAround;
    public float RotateSpeed;
    public GameObject[] Ball;
    public Transform TopLeft;
    public Transform TopRight;
    public Transform Bottom;
    public GameObject BallBarrageObject;

    private int BallSelector;
    private float timer;
    private bool RotatingLeft;
    private bool LastBallGenerated;
    private Vector3 Rotate;
    private int BarrageCount;
    private bool RandomBall;
    private bool IsPatternRunning;

    #endregion


    #region System Methods

    private void Start()
    {
        Rotate = RotateAround.position;
        RotateSpeed = 50;

    }//start

    private void Update()
    {
        #region BallGernerator Rotation

        if (timer >= 10f)
        {
            RotatingLeft = !RotatingLeft;
            timer = 0;
        }
        if (RotatingLeft)
        {
            transform.RotateAround(Rotate, Vector3.forward, RotateSpeed * Time.deltaTime);
            timer += Time.deltaTime;
        }
        else
        {
            transform.RotateAround(Rotate, Vector3.forward, -RotateSpeed * Time.deltaTime);
            timer += Time.deltaTime;
        }

        #endregion

        if (!IsBallAlive)
        {
            //if pattern is over then choose a new pattern and send in the balls.
            int PatternGenerator = Random.Range(0, 5);
            Debug.Log(PatternGenerator);
            switch (PatternGenerator)
            {
                case 0:
                    //Single Ball
                    if (BallCount == 0)
                    {
                        CloneBall();
                    }

                    IsPatternRunning = false;
                    //Debug.Log("Single Ball");
                    break;
                case 1:
                    //3 balls in a row of same color
                    if (BallCount == 0)
                    {
                        BallsRow();
                    }

                    IsPatternRunning = false;
                    //Debug.Log("Method Called");
                    break;

                case 2:
                    //2 Differnet color balls
                    if (BallCount == 0)
                    {
                        Color2();
                    }
                    IsPatternRunning = false;
                    //Debug.Log(2);
                    break;

                case 3:
                    //3 Differnet color balls
                    if (BallCount == 0)
                    {
                        Color3();
                    }
                    IsPatternRunning = false;
                    //Debug.Log(3);
                    break;

                case 4:
                    //ball barrage of same color generating on a circular path

                    BallBarrage();

                    //Debug.Log(4);

                    break;

                case 5:
                    //ball barrage of same color generating on a alternate up and down

                    //Debug.Log(5);

                    break;

            }//Switch

        }//if Ball is not alive

        else
        {
            //Do nothing
            //Debug.Log("Ball is alive");
        }
    }//update

    #endregion


    #region User Define Methods
    /*
    * Single ball -> done
    * 3 balls in a row of same color -> done
    * 2 Differnet color balls -> done
    * 3 Differnet color balls -> done (Variation needed)
    * ball barrage of same color generating on a circular path
    * Ball barrage of same color generating on the top and bottom alternatly
     -----------------------------------
    * Need to set time Properly
    */

    void CloneBall()
    {
        IsPatternRunning = true;
        BallSelector = Random.Range(0, 3);
        Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
        BallCount++;
        //Debug.Log("Single Ball");
    }

    void BallsRow()
    {
        //Debug.Log("Inside Method");
        IsPatternRunning = true;
        BallSelector = Random.Range(0, 3);
        StartCoroutine(BallsRowEnum());

        //Spawn the first ball
        //Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
        //BallCount ++;

        ////Start the timer

        ////After X time Spawn second ball
        //Instantiate(Ball[BallSelector], new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Quaternion.identity);
        ////Instantiate(Ball[BallSelector], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        //BallCount++;

        //Instantiate(Ball[BallSelector], new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z), Quaternion.identity);
        ////Instantiate(Ball[BallSelector], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        //BallCount++;

        //Timer Resets
        //if (LastBallGenerated)
        //{
        //    TimeControl.StartTimer = false;
        //    LastBallGenerated = false;

        //    Debug.Log("Timer reset");
        //    Debug.Log(TimeControl.time);
        //}

    }//BallsRow

    IEnumerator BallsRowEnum()
    {
        BallScript.SpeedStatic = Random.Range(2, 5);

        Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.3f);

        BallScript.SpeedStatic = BallScript.SpeedStatic;
        Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.3f);

        BallScript.SpeedStatic = BallScript.SpeedStatic;
        Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.3f);
    }

    void Color2()
    {
        IsPatternRunning = true;
        BallSelector = Random.Range(0, 3);
        StartCoroutine(Color2Enum());

        //Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);

        //if(BallSelector==0 || BallSelector == 1)
        //{
        //    Instantiate(Ball[++BallSelector], new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Quaternion.identity);
        //}
        //else
        //{
        //    Instantiate(Ball[--BallSelector], new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Quaternion.identity);
        //}

    }//Color2

    IEnumerator Color2Enum()
    {
        BallScript.SpeedStatic = Random.Range(2, 5);
        Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.7f);

        if (BallSelector == 0 || BallSelector == 1)
        {
            BallScript.SpeedStatic = BallScript.SpeedStatic;
            Instantiate(Ball[++BallSelector], new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Quaternion.identity);
            BallCount++;
            yield return new WaitForSeconds(.5f);
        }
        else
        {
            BallScript.SpeedStatic = BallScript.SpeedStatic;
            Instantiate(Ball[--BallSelector], new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Quaternion.identity);
            BallCount++;
            yield return new WaitForSeconds(.5f);
        }
    }

    void Color3()
    {
        /*
            
        Right - Blue        0
            Left - Red      1
            Bottom - Green  2

        Right - Red         1
            Left - Green    2
            Bottom - Blue   0

        Right - Green       2
            Left - Blue     0
            Bottom - Red    1 

         */
        IsPatternRunning = true;
        BallSelector = Random.Range(0, 3);
        switch (BallSelector)
        {

            case 0:

                //Instantiate(Ball[BallSelector], TopRight.position, Quaternion.identity);
                //Instantiate(Ball[++BallSelector], TopLeft.position, Quaternion.identity);
                //Instantiate(Ball[++BallSelector], Bottom.position, Quaternion.identity);
                StartCoroutine(Color3EnumC1());

                break;

            case 1:

                //Instantiate(Ball[BallSelector], TopRight.position, Quaternion.identity);
                //Instantiate(Ball[++BallSelector], TopLeft.position, Quaternion.identity);
                //Instantiate(Ball[2-BallSelector], Bottom.position, Quaternion.identity);

                StartCoroutine(Color3EnumC2());

                break;

            case 2:

                //Instantiate(Ball[BallSelector], TopRight.position, Quaternion.identity);
                //Instantiate(Ball[2-BallSelector], TopLeft.position, Quaternion.identity);
                //Instantiate(Ball[BallSelector-1], Bottom.position, Quaternion.identity);
                StartCoroutine(Color3EnumC3());
                break;

        }//switch

    }//Color3

    IEnumerator Color3EnumC1()
    {
        BallScript.SpeedStatic = Random.Range(2, 5);

        Instantiate(Ball[BallSelector], TopRight.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.2f);

        BallScript.SpeedStatic = BallScript.SpeedStatic;
        Instantiate(Ball[++BallSelector], TopLeft.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.2f);

        BallScript.SpeedStatic = BallScript.SpeedStatic;
        Instantiate(Ball[++BallSelector], Bottom.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.2f);

    }//Color3EnumC1

    IEnumerator Color3EnumC2()
    {
        BallScript.SpeedStatic = Random.Range(2, 5);

        Instantiate(Ball[BallSelector], TopRight.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.2f);

        BallScript.SpeedStatic = BallScript.SpeedStatic;
        Instantiate(Ball[++BallSelector], TopLeft.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.2f);

        BallScript.SpeedStatic = BallScript.SpeedStatic;
        Instantiate(Ball[2 - BallSelector], Bottom.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.2f);

    }//Color3EnumC2

    IEnumerator Color3EnumC3()
    {
        BallScript.SpeedStatic = Random.Range(2, 5);

        Instantiate(Ball[BallSelector], TopRight.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.2f);

        BallScript.SpeedStatic = BallScript.SpeedStatic;
        Instantiate(Ball[2 - BallSelector], TopLeft.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.2f);

        BallScript.SpeedStatic = BallScript.SpeedStatic;
        Instantiate(Ball[BallSelector - 1], Bottom.position, Quaternion.identity);
        BallCount++;
        yield return new WaitForSeconds(.2f);

    }//Color3EnumC3

    void BallBarrage()
    {
        IsPatternRunning = true;
        if (!RandomBall)
        {
            BallSelector = Random.Range(0, 3);
            BallScript.SpeedStatic = Random.Range(2, 5);
            StartCoroutine(BallBarageEnum(BarrageCount));
            RandomBall = true;
        }
        else
        {
            StartCoroutine(BallBarageEnum(BarrageCount));
        }
        //Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);


        if (BarrageCount == 10)
        {
            IsPatternRunning = false;
            BarrageCount = 0;
            RandomBall = false;
        }
        //Debug.Log(BallBarrageObject.transform.GetChild(i).transform.position);

    }//BallBarrage

    IEnumerator BallBarageEnum(int i)
    {
        BallScript.SpeedStatic = BallScript.SpeedStatic;

        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        BallCount++;
        BarrageCount++;
        yield return new WaitForSeconds(.2f);
    }//Color3EnumC3

    #endregion
}//class