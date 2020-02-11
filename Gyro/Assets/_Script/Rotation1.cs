using UnityEngine;

public class Rotation1 : MonoBehaviour
{
    #region Variables

    public float speed;
    private Touch touch;
    Vector2 direction;
    private Quaternion oldRotation;
    float angle;
    Quaternion rotation;
    Vector2 OldTouch;
    #endregion

    #region System Methods

    private void Update()
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:

                    OldTouch = touch.position;
                    Debug.DrawLine(Vector3.zero, Camera.main.ScreenToWorldPoint(touch.position),Color.blue);

                    break;

                case TouchPhase.Moved:

                    Debug.DrawLine(Vector3.zero, Camera.main.ScreenToWorldPoint(touch.position), Color.blue);

                    direction = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                    angle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
                    rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    Vector3 newRotation = transform.localEulerAngles;
                    if(OldTouch.magnitude<touch.position.magnitude)
                    {
                        //Right Rotation Code
                        newRotation.z -= rotation.z * speed * Time.deltaTime;
                        transform.localEulerAngles = newRotation;
                    }
                    else
                    {
                        //Left Rotation code
                        newRotation.z += rotation.z * speed * Time.deltaTime;
                        transform.localEulerAngles = newRotation;
                    }

                    OldTouch = touch.position;
                    break;

                case TouchPhase.Stationary:

                    Debug.DrawLine(Vector3.zero, Camera.main.ScreenToWorldPoint(touch.position), Color.blue);

                    break;

                case TouchPhase.Ended:

                    oldRotation = transform.rotation;
                    break;
                    
            }//Switch Touch Phase
            
        }//If touchCount

    }//Update

    #endregion

    #region User Define Methods

    #endregion

}//Class