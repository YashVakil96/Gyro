using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomTouchBar : MonoBehaviour
{
    #region Varaiable
    private Vector2 StartPos;
    private Vector2 Direction;
    private Vector2 OldPos;

    #endregion

    #region System Methods

    private void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            switch(touch.phase)
            {
                case TouchPhase.Began:

                    Debug.Log("Touch Begun"); 
                    StartPos = touch.position;
                    OldPos = StartPos;


                    break;

                case TouchPhase.Moved:

                    Debug.Log("Touch Moved");
                    Direction = touch.position - StartPos;
                    if(Direction.x>OldPos.x)
                    {
                        Debug.Log("Right");
                    }

                    else
                    {
                        Debug.Log("Left");
                    }
                    OldPos = Direction;

                    break;

                case TouchPhase.Ended:

                    Debug.Log("Touch Ended");

                    break;
            }//Switch
        }//if TouchCount
        
    }//update

    #endregion


    #region User Define Methods



    #endregion
}//class
