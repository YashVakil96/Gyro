using UnityEngine;

public class Rotation1 : MonoBehaviour
{
    public float speed;


    private void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 direction = Camera.main.ScreenToWorldPoint(touch.position)-transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
            
        }//If touchCount
    }
}//Class
