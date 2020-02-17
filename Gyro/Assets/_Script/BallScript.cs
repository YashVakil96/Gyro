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
        if(collision.gameObject.name == "Blue" || collision.CompareTag("DefenderBall"))
        {

            if(gameObject.CompareTag("DefenderBall"))
            {
                PowerUps.StartDefender = true;
                Destroy(this.gameObject);
            }

            if (gameObject.GetComponent<SpriteRenderer>().color.b==1 )
            {
                ScoreManager.ScorePoints++;
                Debug.Log("BlueHealth: " + HealthScript.BlueHealth);
                foreach (var item in Ballcount)
                {
                    if (item == gameObject.name)
                    {
                        HideTailIndex = item;
                        Dead = true;
                        Ballcount.Remove(item);
                    }
                }
            }
            else
            {
                /*
                small ball -10
                medium ball -15
                large ball -25
                 */
                if(size >= 0.2 && size <= 0.29)
                {
                    HealthScript.BlueHealth -= 10;
                }//if Small

                else if(size >= 0.3 && size <= 0.35)
                {
                    HealthScript.BlueHealth -= 15;
                }//if Medium

                else if (size >= 0.35 && size <= 0.4)
                {
                    HealthScript.BlueHealth -= 25;
                }//if large
                
                foreach (var item in Ballcount)
                {
                    if (item == gameObject.name)
                    {
                        HideTailIndex = item;
                        Dead = true;
                        Ballcount.Remove(item);
                    }
                }
            }
            
        }//if hits blue
        else if(collision.gameObject.name == "Green" || collision.CompareTag("DefenderBall"))
        {
            if (gameObject.CompareTag("DefenderBall"))
            {
                PowerUps.StartDefender = true;
                Destroy(this.gameObject);
            }
            //IF green hits green score increase
            if (gameObject.GetComponent<SpriteRenderer>().color.g == 1)
            {
                ScoreManager.ScorePoints++;
                foreach (var item in Ballcount)
                {
                    if (item == gameObject.name)
                    {
                        HideTailIndex = item;
                        Dead = true;
                        Ballcount.Remove(item);
                    }
                }
            }
            else
            {
                if (size >= 0.2 && size <= 0.29)
                {
                    HealthScript.GreenHealth -= 10;
                }//if Small

                else if (size >= 0.3 && size <= 0.35)
                {
                    HealthScript.GreenHealth -= 15;
                }//if Medium

                else if (size >= 0.35 && size <= 0.4)
                {
                    HealthScript.GreenHealth -= 25;
                }//if large

                foreach (var item in Ballcount)
                {
                    if (item == gameObject.name)
                    {
                        HideTailIndex = item;
                        Dead = true;
                        Ballcount.Remove(item);
                    }
                }
            }
        }//if hits green
        else if (collision.gameObject.name == "Red" || collision.CompareTag("DefenderBall"))
        {
            if (gameObject.CompareTag("DefenderBall"))
            {
                PowerUps.StartDefender = true;
                Destroy(this.gameObject);
            }
            //IF red hits red score increase
            if (gameObject.GetComponent<SpriteRenderer>().color.r == 1)
            {
                ScoreManager.ScorePoints++;

                foreach (var item in Ballcount)
                {
                    if (item == gameObject.name)
                    {
                        HideTailIndex = item;
                        Dead = true;
                        Ballcount.Remove(item);
                    }
                }
            }
            else
            {
                if (size >= 0.2 && size <= 0.29)
                {
                    HealthScript.RedHealth -= 10;
                }//if Small

                else if (size >= 0.3 && size <= 0.35)
                {
                    HealthScript.RedHealth -= 15;
                }//if Medium

                else if (size >= 0.35 && size <= 0.4)
                {
                    HealthScript.RedHealth -= 25;
                }//if large

                foreach (var item in Ballcount)
                {
                    if (item == gameObject.name)
                    {
                        HideTailIndex = item;
                        Dead = true;
                        Ballcount.Remove(item);
                    }
                }
            }
        }//if hits red


        if (collision.gameObject.name=="TriggerLine")
        {
            if(BallGenerator.PatternGenerator==0)
            {
                BallGenerator.TriggerIsSet = true;//Script 1
                BallGenerator.IsPatternRunning = false;
            }

            else if(BallGenerator.PatternGenerator==1)
            {
                BallGenerator.RowCounter++;
                if(BallGenerator.RowCounter == 3)
                {
                    BallGenerator.RowCounter = 0;
                    BallGenerator.IsPatternRunning = false;
                }
            }
            else if(BallGenerator.PatternGenerator == 2)
            {
                BallGenerator.C2Counter++;
                if(BallGenerator.C2Counter==2)
                {
                    BallGenerator.C2Counter = 0;
                    BallGenerator.IsPatternRunning = false;
                }
            }
            else if (BallGenerator.PatternGenerator == 3)
            {
                BallGenerator.C3Counter++;
                if (BallGenerator.C3Counter == 3)
                {
                    BallGenerator.C3Counter = 0;
                    BallGenerator.IsPatternRunning = false;
                }
            }
            else if (BallGenerator.PatternGenerator == 4)
            {
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