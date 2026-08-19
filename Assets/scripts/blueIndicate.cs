using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for the indicator for the moving cars so the inidcator blinks while the car is moving, it makes the Indicator icon blink.
public class blueIndicate : MonoBehaviour
{
    //These things are the indicator icon and their settings of how it will blink
    public GameObject LeftIndicatorIcon;
    private bool isLeftOn = false;
    private float leftTimer = 0f;
    private float blinkInterval = 0.5f;

    void Update()// The update runs nonstop 
    {
        leftTimer += Time.deltaTime;//add to the timer

        if (leftTimer >= blinkInterval) //this function will run when the time is over the timer limit to create blinking effect
        {
            isLeftOn = !isLeftOn; //turn indicator off
            LeftIndicatorIcon.SetActive(isLeftOn); //turn indicator on
            leftTimer = 0f; // Reset the timer when toggled
        }

    }
}
