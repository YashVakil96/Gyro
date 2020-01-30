﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;
    public Vector2 Olddirection;

    public Text m_Text;
    string message;
    private float x;

    void Update()
    {
        //Update the Text on the screen depending on current TouchPhase, and the current direction vector
        m_Text.text = "Touch : " + message + "in direction" + direction;

        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    startPos = touch.position;
                    message = "Begun ";
                    Olddirection = startPos;
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    if (direction.x >= Olddirection.x)
                    {
                        x += touch.deltaTime * 100;

                    }
                    else
                    {
                        x -= touch.deltaTime * 100;
                    }
                    Olddirection = direction;
                    transform.rotation = Quaternion.Euler(0, 0,x);
                    message = "Moving ";
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    message = "Ending ";
                    break;
            }
            
        }
        
    }
}
