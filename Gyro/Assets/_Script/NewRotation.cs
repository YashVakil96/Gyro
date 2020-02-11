using UnityEngine;

public class NewRotation : MonoBehaviour
{
    #region Variables

    
    Touch touch;
    Vector3 OldRotation;
    float x;
    float speed;

    Vector2 TouchBegun;
    Vector2 OldTouch;
    #endregion


    #region System Methods

    private void Update()
    {
        //transform.Rotate(0, 0, 10 * Time.deltaTime); // To rotate
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            switch(touch.phase)
            {
                case TouchPhase.Began:

                    /*
                     * Retrieve old rotation (If available)
                     * Set it to current transform
                     */
                    TouchBegun = touch.position;
                    OldTouch = touch.position;
                    Debug.Log("Touch Started");
                    break;

                case TouchPhase.Moved:

                    /*
                     * Check in which direction finger is moved
                     * Calculate Speed of touch moving
                     * Rotate the object in the direction of touch movement with calculated speed
                     */

                    if (OldTouch.magnitude<touch.position.magnitude)
                    {
                        speed = touch.position.magnitude - OldTouch.magnitude;
                        Debug.Log("SPEED: "+speed);
                        Debug.Log("Right");
                        x = 1000 * Time.deltaTime;
                        transform.Rotate(0,0,x);
                    }
                    else
                    {
                        Debug.Log("Left");
                        //x -= 10 * Time.deltaTime;
                        transform.Rotate(0, 0, -x);
                    }
                    

                    Debug.Log("Touch Moved");
                    OldTouch = touch.position;
                    break;

                case TouchPhase.Ended:

                    /*
                     * Store the Rotation
                     */
                    OldTouch = touch.position;
                    Debug.Log("Touch Ended");
                    break;
            }//switch
        }//if Touch count
    }
    #endregion


    #region User Define Methods

    //

    #endregion

}//Class