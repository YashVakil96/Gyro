using UnityEngine;
using System.Collections.Generic;

public class BallScript : MonoBehaviour
{
    #region Variable

    public static float SpeedStatic;
    public static string ObjectName;
    public static List<string> Ballcount = new List<string>();
    public static bool Dead;

    public bool DeadCheck;
    public float Speed;

    private Transform FollowTarget;
    private Vector2 TargetPos;
    private float size;
    private TrailRenderer Tail;
    private float alpha;
    private string HideTailIndex;

    #endregion


    #region System Methods

    private void Start()
    {
        FollowTarget = GameObject.Find("Follow").GetComponent<Transform>();//Chase
        TargetPos = FollowTarget.position;//Chase

        size = Random.Range(0.2f, 0.41f);//Ballsize
        Vector3 localSize = new Vector3(size, size, 1);//ballsize
        transform.localScale = localSize;//ballsize

        Tail = GetComponent<TrailRenderer>();//Trail Renderer
        Tail.startWidth = size;//tail start Width
        Tail.endWidth = size;//Tail end Width
        BallGenerator.IsBallAlive = true;
        this.gameObject.name = this.gameObject.GetInstanceID().ToString();
        ObjectName = this.gameObject.name;
        Ballcount.Add(gameObject.name);
        alpha = Tail.startColor.a;

        if (SpeedStatic>0)
        {
            Speed = SpeedStatic;
        }
        else
        {
            Speed = 1;
            SpeedStatic = Speed;
        }
    }//start

    private void Update()
    {
        MoveBall(Speed);
        DeadCheck = Dead;
        HideTail(HideTailIndex);
    }//update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("2");
            ScoreManager.ScorePoints++;
            foreach (var item in Ballcount)
            {
                if(item==gameObject.name)
                {
                    Debug.Log("3");
                    HideTailIndex = item;
                    Dead = true;
                    Ballcount.Remove(item);
                }
            }
        }//If collision with player

        if(collision.gameObject.name=="TriggerLine")
        {
            if(BallGenerator.PatternGenerator==0)
            {
                BallGenerator.TriggerIsSet = true;//Script 1
                //Debug.Log("Hits");
                BallGenerator.IsPatternRunning = false;
            }

            else if(BallGenerator.PatternGenerator==1)
            {
                //Debug.Log("HERE");
                BallGenerator.RowCounter++;
                Debug.Log(BallGenerator.RowCounter);
                if(BallGenerator.RowCounter == 3)
                {
                    BallGenerator.RowCounter = 0;
                    BallGenerator.IsPatternRunning = false;
                }
            }
            else if(BallGenerator.PatternGenerator == 2)
            {
                //Debug.Log("Pattern 2");
                BallGenerator.C2Counter++;
                if(BallGenerator.C2Counter==2)
                {
                    BallGenerator.C2Counter = 0;
                    BallGenerator.IsPatternRunning = false;
                }
            }
            else if (BallGenerator.PatternGenerator == 3)
            {
                //Debug.Log("Pattern 3");
                BallGenerator.C3Counter++;
                if (BallGenerator.C3Counter == 3)
                {
                    BallGenerator.C3Counter = 0;
                    BallGenerator.IsPatternRunning = false;
                }
            }
            else if (BallGenerator.PatternGenerator == 4)
            {
                //Debug.Log("Pattern 4");
                BallGenerator.BarrageCounter++;
                if (BallGenerator.BarrageCounter == 10)
                {
                    BallGenerator.BarrageCounter = 0;
                    BallGenerator.IsPatternRunning = false;
                }
            }
        }//Triggerline Collision
        
    }//Trigger Enter

    #endregion


    #region User Define Methods

    public  void MoveBall()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, Speed * Time.deltaTime);
    }//MoveBall

    public void MoveBall(float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, Speed * Time.deltaTime);
    }//MoveBall


    void HideTail(string index)
    {
        alpha = Tail.startColor.a;

        if (Dead)
        {
            alpha -= Time.deltaTime;
            GameObject.Find(index).GetComponent<TrailRenderer>().startColor= new Color(Tail.startColor.r, Tail.startColor.g, Tail.startColor.b, alpha);
            GameObject.Find(index).GetComponent<TrailRenderer>().endColor = new Color(Tail.endColor.r, Tail.endColor.g, Tail.endColor.b, alpha);

            if (alpha <= 0)
            {
                BallScript.Dead = false;
                Destroy(gameObject);
            }
        }//If Dead
    }
    #endregion


}//class