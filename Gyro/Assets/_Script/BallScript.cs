using UnityEngine;

public class BallScript : MonoBehaviour
{
    #region Variable

    public static float SpeedStatic;
    public static string ObjectName;

    public float Speed;

    private Transform FollowTarget;
    private Vector2 TargetPos;
    private float size;
    private TrailRenderer Tail;
    
    #endregion


    #region System Methods

    private void Start()
    {
        FollowTarget = GameObject.Find("Follow").GetComponent<Transform>();
        Tail = GetComponent<TrailRenderer>();
        TargetPos = FollowTarget.position;
        size = Random.Range(0.2f, 0.41f);
        Tail.startWidth = size;
        Tail.endWidth = size;
        Vector3 localSize = new Vector3(size, size, 1);
        transform.localScale = localSize;
        BallGenerator.IsBallAlive = true;
        this.gameObject.name = this.gameObject.GetInstanceID().ToString();
        ObjectName = this.gameObject.name;
        Alpha.Ballcount.Add(gameObject.name);

        if(SpeedStatic>0)
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
    }//update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("here");
            ScoreManager.ScorePoints++;
            //Destroy(this.gameObject);
            //Debug.Log("Score Points: " + ScoreManager.ScorePoints);
        }

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
        }
        
    }//Trigger Enter

    #endregion


    #region User Define Methods

    public  void MoveBall()
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, Speed * Time.deltaTime);
    }

    public void MoveBall(float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, TargetPos, Speed * Time.deltaTime);
    }

    #endregion


}//class