using UnityEngine;
using System.Collections;

public class BallGenerator : MonoBehaviour
{
    #region Variable

    public static bool IsBallAlive=false;
    public static bool TriggerGeneration=false;
    public static bool TriggerIsSet;
    public static int PatternGenerator;
    public static bool IsPatternRunning;

    public static int RowCounter;
    public static int C2Counter;
    public static int C3Counter;
    public static int BarrageCounter;


    public Transform RotateAround;
    public GameObject[] Ball;
    public Transform TopLeft;
    public Transform TopRight;
    public Transform Bottom;
    public GameObject BallBarrageObject;

    private Vector2 GenerationPoint;
    private Vector2 PreviousBallPos;
    private int BallSelector;
    private int OldPattern;
    private int counterC2;
    private int counterC3;
    private int counterRow;
    private int counterBB;
    private BallScript ballScript;

    #endregion


    #region System Methods

    private void Start()
    {
        TriggerIsSet = true;
        ballScript = FindObjectOfType<BallScript>();

    }//start

    private void Update()
    {
        if (TriggerIsSet && !IsPatternRunning)

        {
            if (ScoreManager.ScorePoints <= 20)
            {
                PatternGenerator = Random.Range(0, 2);
                if(OldPattern==PatternGenerator)
                {
                    PatternGenerator = OldPattern == 0 ? 1 : 0;
                }
            }
            else if (ScoreManager.ScorePoints <= 40 && ScoreManager.ScorePoints > 20)
            {
                PatternGenerator = Random.Range(0, 3);
                Pattern(0, 3);
            }

            else if (ScoreManager.ScorePoints <= 70 && ScoreManager.ScorePoints > 40)
            {
                PatternGenerator = Random.Range(0, 4);
                Pattern(0, 4);
            }
            else if (ScoreManager.ScorePoints <= 100 && ScoreManager.ScorePoints > 70)
            {
                PatternGenerator = Random.Range(0, 5);
                Pattern(0, 5);
            }
            else
            {
                PatternGenerator = Random.Range(0, 5);
                Pattern(0, 5);
            }
            OldPattern = PatternGenerator;

            switch (PatternGenerator)
            {
                case 0:
                    //Single Ball
                    GenerationPoint = GeneratingPoint();//Getting the spawnning point
                    SpawnBall();
                    break;

                case 1:
                    //3 balls in a row of same color
                    GenerationPoint = GeneratingPoint();//Getting the spawnning point
                    if(counterRow > 3)
                    {
                        BallsRow();
                        counterRow = 0;
                    }
                    else
                    {
                        counterRow++;
                    }

                    break;

                case 2:
                    //2 Differnet color balls
                    GenerationPoint = GeneratingPoint();//Getting the spawnning point
                    if(counterC2 > 3)
                    {
                        Color2();
                        counterC2 = 0;
                    }
                    else
                    {
                        counterC2++;
                    }
                    break;

                case 3:
                    //3 Differnet color balls
                    GenerationPoint = GeneratingPoint();//Getting the spawnning point
                    if(counterC3 > 3)
                    {
                        Color3();
                        counterC3 = 0;
                    }
                    else
                    {
                        counterC3++;
                    }
                    break;

                case 4:
                    //ball barrage of same color generating on a circular path
                    GenerationPoint = GeneratingPoint();//Getting the spawnning point
                    if(counterBB > 10)
                    {
                        BallBarrage();
                        counterBB = 0;
                    }
                    else
                    {
                        counterBB++;
                    }
                    break;

            }//Switch

        }//If Pattern is not running

    }//update

    #endregion

    #region User Define Methods

    #region Patterns

    #region Single Ball

    void SpawnBall() //Single Ball
    {
        IsPatternRunning = true;
        CheckGeneratingPoint();
        BallSelector = Random.Range(0, 3);
        //Check the previous postion
        Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
        PreviousBallPos = transform.position;
    }//SpawnBall

    #endregion

    #region BallsRow

    void BallsRow()
    {
        IsPatternRunning = true;
        CheckGeneratingPoint();
        BallSelector = Random.Range(0, 3);
        StartCoroutine(BallsRowEnum());
    }//BallsRow

    IEnumerator BallsRowEnum()
    {
        if(GenerationPoint.y>0)
        {
            //Debug.Log("UP");

            //UP
            if (GenerationPoint.x>0)
            {
                //Right
                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable

                Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.2f);

                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable

                Instantiate(Ball[BallSelector], new Vector2(transform.position.x + .8f, transform.position.y + .2f), Quaternion.identity);
                yield return new WaitForSeconds(.2f);

                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable

                Instantiate(Ball[BallSelector], new Vector2(transform.position.x + .5f, transform.position.y + 1.3f), Quaternion.identity);
                yield return new WaitForSeconds(.2f);
            }//if Right
            else
            {
                //Left
                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable

                Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.2f);

                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable

                Instantiate(Ball[BallSelector], new Vector2(transform.position.x - .8f, transform.position.y + .2f), Quaternion.identity);
                yield return new WaitForSeconds(.2f);

                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable

                Instantiate(Ball[BallSelector], new Vector2(transform.position.x - .5f, transform.position.y + 1.3f), Quaternion.identity);
                yield return new WaitForSeconds(.2f);
            }//else Left


        }//if Up
        else
        {
            //Down
            if (GenerationPoint.x>0)
            {
                //Right
                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable


                Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.2f);

                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable

                Instantiate(Ball[BallSelector], new Vector2(transform.position.x + .8f, transform.position.y - .2f), Quaternion.identity);
                yield return new WaitForSeconds(.2f);

                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable

                Instantiate(Ball[BallSelector], new Vector2(transform.position.x + .5f, transform.position.y - 1.3f), Quaternion.identity);
                yield return new WaitForSeconds(.2f);
            }//If Right
            else
            {
                //Left
                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable


                Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.2f);

                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable

                Instantiate(Ball[BallSelector], new Vector2(transform.position.x - .8f, transform.position.y - .2f), Quaternion.identity);
                yield return new WaitForSeconds(.2f);

                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable

                Instantiate(Ball[BallSelector], new Vector2(transform.position.x - .5f, transform.position.y - 1.3f), Quaternion.identity);
                yield return new WaitForSeconds(.2f);
            }//else Left

        }//else Down
    }//BallsRowEnum

    #endregion

    #region Color2

    void Color2()
    {
        IsPatternRunning = true;
        CheckGeneratingPoint();
        BallSelector = Random.Range(0, 3);
        StartCoroutine(Color2Enum());
    }//Color2

    IEnumerator Color2Enum()
    {
        if (GenerationPoint.y > 0)
        {
            //UP
            if (GenerationPoint.x > 0)
            {
                //Right
                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable
                Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.7f);

                if (BallSelector == 0 || BallSelector == 1)
                {
                    #pragma warning disable CS1717 // Assignment made to same variable
                    BallScript.SpeedStatic = BallScript.SpeedStatic;
                    #pragma warning restore CS1717 // Assignment made to same variable
                    Instantiate(Ball[++BallSelector], new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Quaternion.identity);
                    yield return new WaitForSeconds(.7f);
                }
                else
                {
                    #pragma warning disable CS1717 // Assignment made to same variable
                    BallScript.SpeedStatic = BallScript.SpeedStatic;
                    #pragma warning restore CS1717 // Assignment made to same variable
                    Instantiate(Ball[--BallSelector], new Vector3(transform.position.x + 1, transform.position.y + 1, transform.position.z), Quaternion.identity);
                    yield return new WaitForSeconds(.7f);
                }
            }//if Right
            else
            {
                //Left
                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable
                Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.7f);

                if (BallSelector == 0 || BallSelector == 1)
                {
                    #pragma warning disable CS1717 // Assignment made to same variable
                    BallScript.SpeedStatic = BallScript.SpeedStatic;
                    #pragma warning restore CS1717 // Assignment made to same variable
                    Instantiate(Ball[++BallSelector], new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.z), Quaternion.identity);
                    yield return new WaitForSeconds(.7f);
                }
                else
                {
                    #pragma warning disable CS1717 // Assignment made to same variable
                    BallScript.SpeedStatic = BallScript.SpeedStatic;
                    #pragma warning restore CS1717 // Assignment made to same variable
                    Instantiate(Ball[--BallSelector], new Vector3(transform.position.x - 1, transform.position.y + 1, transform.position.z), Quaternion.identity);
                    yield return new WaitForSeconds(.7f);
                }
            }//else Left
        }//if UP
        else
        {
            //Down
            if (GenerationPoint.x > 0)
            {
                //Right
                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable
                Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.7f);

                if (BallSelector == 0 || BallSelector == 1)
                {
                    #pragma warning disable CS1717 // Assignment made to same variable
                    BallScript.SpeedStatic = BallScript.SpeedStatic;
                    #pragma warning restore CS1717 // Assignment made to same variable
                    Instantiate(Ball[++BallSelector], new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z), Quaternion.identity);
                    yield return new WaitForSeconds(.7f);
                }
                else
                {
                    #pragma warning disable CS1717 // Assignment made to same variable
                    BallScript.SpeedStatic = BallScript.SpeedStatic;
                    #pragma warning restore CS1717 // Assignment made to same variable
                    Instantiate(Ball[--BallSelector], new Vector3(transform.position.x + 1, transform.position.y - 1, transform.position.z), Quaternion.identity);
                    yield return new WaitForSeconds(.7f);
                }
            }//if Right
            else
            {
                //Left
                #pragma warning disable CS1717 // Assignment made to same variable
                BallScript.SpeedStatic = BallScript.SpeedStatic;
                #pragma warning restore CS1717 // Assignment made to same variable
                Instantiate(Ball[BallSelector], transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.7f);

                if (BallSelector == 0 || BallSelector == 1)
                {
                    #pragma warning disable CS1717 // Assignment made to same variable
                    BallScript.SpeedStatic = BallScript.SpeedStatic;
                    #pragma warning restore CS1717 // Assignment made to same variable
                    Instantiate(Ball[++BallSelector], new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.z), Quaternion.identity);
                    yield return new WaitForSeconds(.7f);
                }
                else
                {
                    #pragma warning disable CS1717 // Assignment made to same variable
                    BallScript.SpeedStatic = BallScript.SpeedStatic;
                    #pragma warning restore CS1717 // Assignment made to same variable
                    Instantiate(Ball[--BallSelector], new Vector3(transform.position.x - 1, transform.position.y - 1, transform.position.z), Quaternion.identity);
                    yield return new WaitForSeconds(.7f);
                }

            }//else Left
        }//else down

    }//Color2Enum

    #endregion

    #region Color3

    void Color3()
    {

        IsPatternRunning = true;
        CheckGeneratingPoint();
        BallSelector = Random.Range(0, 3);
        switch (BallSelector)
        {

            case 0:
                StartCoroutine(Color3EnumC1());
                break;

            case 1:
                StartCoroutine(Color3EnumC2());
                break;

            case 2:
                StartCoroutine(Color3EnumC3());
                break;

        }//switch

    }//Color3

    IEnumerator Color3EnumC1()
    {
        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        Instantiate(Ball[BallSelector], TopRight.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);

        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        Instantiate(Ball[++BallSelector], TopLeft.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);

        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        Instantiate(Ball[++BallSelector], Bottom.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);

    }//Color3EnumC1

    IEnumerator Color3EnumC2()
    {
        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        Instantiate(Ball[BallSelector], TopRight.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);

        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        Instantiate(Ball[++BallSelector], TopLeft.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);

        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        Instantiate(Ball[2 - BallSelector], Bottom.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);

    }//Color3EnumC2

    IEnumerator Color3EnumC3()
    {
        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        Instantiate(Ball[BallSelector], TopRight.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);

        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        Instantiate(Ball[2 - BallSelector], TopLeft.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);

        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        Instantiate(Ball[BallSelector - 1], Bottom.position, Quaternion.identity);
        yield return new WaitForSeconds(.2f);

    }//Color3EnumC3

    #endregion

    #region BallBarrage
    void BallBarrage()
    {
        IsPatternRunning = true;
        
        BallSelector = Random.Range(0, 3);
        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        StartCoroutine(BallBarageEnum(0));

    }//BallBarrage

    IEnumerator BallBarageEnum(int i)
    {
        #pragma warning disable CS1717 // Assignment made to same variable
        BallScript.SpeedStatic = BallScript.SpeedStatic;
        #pragma warning restore CS1717 // Assignment made to same variable
        float time=.4f;

        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        i++;
        yield return new WaitForSeconds(time);
        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        i++;
        yield return new WaitForSeconds(time);
        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        i++;
        yield return new WaitForSeconds(time);
        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        i++;
        yield return new WaitForSeconds(time);
        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        i++;
        yield return new WaitForSeconds(time);
        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        i++;
        yield return new WaitForSeconds(time);
        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        i++;
        yield return new WaitForSeconds(time);
        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        i++;
        yield return new WaitForSeconds(time);
        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        i++;
        yield return new WaitForSeconds(time);
        Instantiate(Ball[BallSelector], BallBarrageObject.transform.GetChild(i).transform.position, Quaternion.identity);
        i++;
        yield return new WaitForSeconds(time);

    }//BallBarrageEnum

    #endregion

    #endregion

    Vector2 GeneratingPoint()
    {
        Vector2 Point = new Vector2(0, 0);
        float x, y;
        int UD = Random.Range(1, 3);//Up/Down
        if (UD == 1)
        {
            //Code for UP
            y = Random.Range(2.2f, 5.6f);//Random for height
            if (y < 5 && y > 2.2)
            {
                //Width should be -3 or 3
                x = Random.Range(0, 2) == 0 ? -3 : 3;
                Point = new Vector2(x, y);
            }
            else if (y > 5 && y < 5.6)
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
        //Debug.Log(Point);
        return Point;

    }//Generating Point

    void CheckGeneratingPoint()
    {
        if (GenerationPoint.x > PreviousBallPos.x - .5f && GenerationPoint.x < PreviousBallPos.x + .5f)
        {
            if (GenerationPoint.y > PreviousBallPos.y - .5f && GenerationPoint.y < PreviousBallPos.y + .5f)
            {
                GenerationPoint = GeneratingPoint();//Getting the spawnning point
                //Debug.Log("Point Generated");
            }
        }

        transform.position = GenerationPoint;//Ball Generator takes the position
    }//Check Generating Point

    void Pattern(int Start, int End)
    {
        PatternGenerator = Random.Range(Start, End);
        if (OldPattern == Start)
        {
            PatternGenerator = Random.Range(Start+1, End);
        }
        else if (OldPattern == End-1)
        {
            PatternGenerator = Random.Range(Start, End-1);
        }
        else
        {
            PatternGenerator = Random.Range(0, 2) == 0 ? PatternGenerator++ : PatternGenerator--;
        }
    }

    #endregion

}//class 