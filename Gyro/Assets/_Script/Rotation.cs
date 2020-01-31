using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    #region Variables;
    public Vector2 startPos;
    public Vector2 direction;
    public Vector2 Olddirection;

    private float x;
    private float startTime;
    private Rigidbody2D rb;
    #endregion


    #region System Methods
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchpos = Camera.main.ScreenToWorldPoint(touch.position);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    Olddirection = startPos;
                    startTime = Time.time;
                    Debug.DrawLine(Vector3.zero, touchpos, Color.blue);
                    break;

                case TouchPhase.Moved:

                    
                    Debug.DrawLine(Vector3.zero, touchpos,Color.blue);
                    direction = touch.position - startPos;
                    
                    //This code can be applied to Scroll bar in the bottom of the screen
                    //if (direction.x >= Olddirection.x)
                    //{
                    //    x += touch.deltaTime * 100;

                    //}
                    //else
                    //{
                    //    x -= touch.deltaTime * 100;
                    //}
                    Olddirection = direction;
                    transform.rotation = Quaternion.Euler(0, 0,x);

                    break;

                case TouchPhase.Ended:
                    Debug.DrawLine(Vector3.zero, touchpos, Color.blue);
                    break;

            }//Switch
            
        }//if
        
    }//Update

    #endregion

    #region User Define Methods

    private void SwipeSpeed(Vector2 OldPos, Vector2 TouchPos)
    {

    }//Swipe Speed

    #endregion
}//Class
