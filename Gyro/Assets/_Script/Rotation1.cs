using UnityEngine;

public class Rotation1 : MonoBehaviour
{
    #region Variables

    public float speed;
    private Quaternion rotationZ;
    private Touch touch;
    private Vector2 TouchPos;
    Vector2 direction;
    float angle;
    Quaternion rotation;

    #endregion

    #region System Methods

    private void Update()
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);

            /*
            Vector2 direction = Camera.main.ScreenToWorldPoint(touch.position)-transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
             */

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    FaceTouch();
                    //transform.rotation = rotation;
                    Debug.Log(rotation);

                    break;

                case TouchPhase.Moved:
                    FaceTouch();
                    //transform.rotation = rotation;
                    //direction = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                    //angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    //rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    //Debug.Log(rotation);

                    //rotationZ = Quaternion.Euler(0f, 0f, touch.deltaPosition.x * speed);//This can be used in Scroll Bar
                    ////transform.rotation = Quaternion.Slerp(transform.rotation, rotationZ * transform.rotation, speed * Time.deltaTime);
                    //transform.rotation = rotationZ * transform.rotation;
                    break;

                case TouchPhase.Ended:
                    //transform.rotation = rotation;
                    break;
                    
            }//Switch Touch Phase
            
        }//If touchCount

    }//Update

    #endregion

    #region User Define Methods

    void FaceTouch()
    {
        TouchPos = Camera.main.ScreenToWorldPoint(touch.position);
        Vector2 direction =new Vector2(TouchPos.x-transform.position.x, TouchPos.y - transform.position.y) ;
        transform.up = direction;
    }

    #endregion

}//Class