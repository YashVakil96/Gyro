using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alpha : MonoBehaviour
{
    #region Variable
    SpriteRenderer sprite;
    float alpha;
    #endregion


    #region System Methods
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Debug.Log(sprite.color.a);
        alpha = sprite.color.a;
    }//start
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (float i = alpha; i >= alpha; i++)
            {

            }
        }
        alpha -= Time.deltaTime;
        sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b, alpha);
    }//Update
    #endregion


    #region User Methods

    #endregion
}//class
