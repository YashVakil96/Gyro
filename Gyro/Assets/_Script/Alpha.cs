using UnityEngine;

public class Alpha : MonoBehaviour
{
    #region Variable
    SpriteRenderer sprite;
    TrailRenderer Tail;
    float alpha;
    #endregion


    #region System Methods
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Tail = GetComponent<TrailRenderer>();
        Debug.Log(sprite.color.a);
        alpha = sprite.color.a;
    }//start
    private void Update()
    {
        if(BallScript.Dead)
        {
            Debug.Log("here");
            alpha -= Time.deltaTime;
            Tail.startColor = new Color(Tail.startColor.r, Tail.startColor.g, Tail.startColor.b, alpha);
            Tail.endColor = new Color(Tail.endColor.r, Tail.endColor.g, Tail.endColor.b, alpha);
        }
        //sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
    }//Update

    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }
    #endregion


    #region User Methods
    void MoveUp()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
    }
    void MoveDown()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
    }
    void MoveLeft()
    {
        transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
    }
    void MoveRight()
    {
        transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
    }
    #endregion
}//class
