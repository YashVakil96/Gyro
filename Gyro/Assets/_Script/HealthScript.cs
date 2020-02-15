using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    #region Variables

    public static float BlueHealth;
    public static float GreenHealth;
    public static float RedHealth;

    private Color BlueAlpha;
    private Color GreenAlpha;
    private Color RedAlpha;

    private float BlueAplhaHandler;
    private float GreenAplhaHandler;
    private float RedAplhaHandler;

    #endregion


    #region System Methods
    private void Start()
    {
        BlueHealth = 100;
        GreenHealth = 100;
        RedHealth = 100;
        //BlueAlpha = GetComponentInChildren<SpriteRenderer>().color;
        BlueAlpha = transform.GetChild(0).GetComponent<SpriteRenderer>().color;
        GreenAlpha = transform.GetChild(1).GetComponent<SpriteRenderer>().color;
        RedAlpha = transform.GetChild(2).GetComponent<SpriteRenderer>().color;
    }//start

    private void Update()
    {
        BlueAplhaHandler = BlueHealth;
        BlueAlpha.a = BlueHealth / 100;
        if(BlueAlpha.a <= .2f)
        {
            BlueAlpha.a = .2f;
        }
        GreenAlpha.a = GreenHealth / 100;
        if (GreenAlpha.a <= .2f)
        {
            GreenAlpha.a = .2f;
        }
        RedAlpha.a = RedHealth / 100;
        if (RedAlpha.a <= .2f)
        {
            RedAlpha.a = .2f;
        }
        transform.GetChild(0).GetComponent<SpriteRenderer>().color=BlueAlpha;
        transform.GetChild(1).GetComponent<SpriteRenderer>().color=GreenAlpha;
        transform.GetChild(2).GetComponent<SpriteRenderer>().color=RedAlpha;
        Debug.Log(BlueAlpha.a);

        if (BlueHealth <= 0 || GreenHealth <= 0 || RedHealth <=0)
        {
            Debug.Log("Game Over");
        }
        else
        {
            return;
        }

    }//Update
    #endregion


    #region User Define Methods

    #endregion
}//class
