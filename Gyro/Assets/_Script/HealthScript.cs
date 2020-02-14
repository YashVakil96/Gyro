using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    #region Variables

    public static float BlueHealth;
    public static float GreenHealth;
    public static float RedHealth;

    #endregion


    #region System Methods
    private void Start()
    {
        BlueHealth = 100;
        GreenHealth = 100;
        RedHealth = 100;
    }//start

    private void Update()
    {
        if(BlueHealth <= 0 || GreenHealth <= 0 || RedHealth <=0)
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
