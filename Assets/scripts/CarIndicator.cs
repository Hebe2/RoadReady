using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarIndicator : MonoBehaviour
{
    //these are the left and right indicator icon
    public GameObject LeftIndicatorIcon;
    public GameObject RightIndicatorIcon;

    //these are all the indicate warnings before the player has to turn
    [SerializeField] GameObject IndicateLeftWarn;
    [SerializeField] GameObject IndicateRightWarn;
    [SerializeField] GameObject IndicateExitWarn;
    [SerializeField] GameObject IndicateOver;
    [SerializeField] GameObject player;

    //these are all the indicate settings
    private bool isLeftOn = false;
    private bool isRightOn = false;
    private float blinkInterval = 0.5f;
    private float leftTimer = 0f;
    private float rightTimer = 0f;

    //these are all the values set for the indicate warning/gameover (when the player gets to that point, the warning/gameover comes on)
    public float xWarnR;
    public float yWarnR;
    public float xWarnL;
    public float yWarnL;
    public float xPosL;
    public float yPosL;
    public float xPosR;
    public float yPosR;
    public float xPosExitWarn;
    public float yPosExitWarn;
    public float xPosExit;
    public float yPosExit;


    void Update()//check input or what's happening continously
    {
        if (Input.GetKeyDown(KeyCode.N))//when the N key is pressed which is for the left indicator
        {
            isLeftOn = !isLeftOn;//left blinking is not false (left indicator is on)
            LeftIndicatorIcon.SetActive(isLeftOn); //turn indicate on
            leftTimer = 0f; // Reset the timer when toggled
            RightIndicatorOff();//turn right indicator off if it is on
            
        }

        if (Input.GetKeyDown(KeyCode.M)) //when M key is pressed which is for the right indicator 
        {
            isRightOn = !isRightOn;//right blinking is not false (right indicator is on)
            RightIndicatorIcon.SetActive(isRightOn); //turn indicator on
            rightTimer = 0f; // Reset the timer when toggled
            LeftIndicatorOff(); //turn left indicator off if it is on
        }

        //left indicator blinking which is when the indicator is on
        if (isLeftOn)
        {
            leftTimer += Time.deltaTime; //start the timer
            if (leftTimer >= blinkInterval) // when the time is over the time limit
            {
                LeftIndicatorIcon.SetActive(!LeftIndicatorIcon.activeSelf); //turn indicator off
                leftTimer = 0f;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow)) //when the left arrow is pressed (which indicates the player is turning left)
            {
                Invoke("LeftIndicatorOff", 3f); // Turn off the right indicator after 3 seconds
            }
        }

        if (!isLeftOn) //LEFT INDICATOR NOT BLINKING, left indicator is not on
        {
            if (Mathf.Abs(player.transform.position.x + xWarnL) < 0.1f && Mathf.Abs(player.transform.position.y + yWarnL) < 0.1f)//before the left turn at the set position in unity inspector
            {
                IndicateLeftWarning();
            }

            if (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(xPosL, yPosL)) < 1f) //at the left turn at the set position in unity inspector
            {
                Invoke("IndicateGameOver", 1f);
            }

            if (Mathf.Abs(player.transform.position.x - xPosExitWarn) < 0.1f && Mathf.Abs(player.transform.position.y - yPosExitWarn) < 0.5f) //before the exit for the roundabout at the set position in unity inspector
            {
                ExitIndicateWarning();
            }

            if (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(xPosExit, yPosExit)) < 0.8f) //at the exit for the roundabout at the set position in unity inspector
            {
                Invoke("IndicateGameOver", 1f);
            }
        }

        //right indicator blinking which is when the indicator is on
        if (isRightOn)
        {
            rightTimer += Time.deltaTime;
            if (rightTimer >= blinkInterval)//if time is over the timer limit then, indicator off
            {
                RightIndicatorIcon.SetActive(!RightIndicatorIcon.activeSelf);
                rightTimer = 0f;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) // if right arrow key is pressed which indicates that player is turning right
            {
                Invoke("RightIndicatorOff", 3f); // Turn off the right indicator after 3 seconds
            }
        }


        if (!isRightOn) //RIGHT INDICATOR NOT BLINKING, right indicator is not on
        {
            if (Mathf.Abs(player.transform.position.x - xWarnR) < 0.1f && Mathf.Abs(player.transform.position.y - yWarnR) < 2.0f) //before the right turn/roundabout at the set position in unity inspector
            {
                IndicateRightWarning();
            }

            if (Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.y), new Vector2(xPosR, yPosR)) < 0.8f) //at theright turn/roundabout at the set position in unity inspector
            {
                Invoke("IndicateGameOver", 1f);
            }
        }

    }



    private void LeftIndicatorOff()//turn left indicator off
    {
        isLeftOn = false;
        LeftIndicatorIcon.SetActive(false);
    }

    private void RightIndicatorOff()//turn right indicator off
    {
        isRightOn = false;
        RightIndicatorIcon.SetActive(false);
    }

    private void IndicateLeftWarning() //left indicate reminder pops up and go away after 2s
    {
        IndicateLeftWarn.SetActive(true);
        Invoke("SetFalseLeftIndicate", 2.0f); // disable after 2 seconds
    }

    private void IndicateRightWarning()//right indicate reminder pops up and go away after 2s
    {
        IndicateRightWarn.SetActive(true);
        Invoke("SetFalseRightIndicate", 2.0f); // disable after 2 seconds
    }

    private void SetFalseLeftIndicate() //left indicate reminderoff
    {
        IndicateLeftWarn.SetActive(false);
    }

    private void SetFalseRightIndicate() //right indicate reminder off
    {
        IndicateRightWarn.SetActive(false);
    }

    private void IndicateGameOver() //indicate game over pops up and stop the game
    {
        IndicateOver.SetActive(true);
        Time.timeScale = 0; 
    }

    private void ExitIndicateWarning() //exit indicate reminder pops up and go away after 2s
    {
        IndicateExitWarn.SetActive(true);
        Invoke("SetFalseIndicateExit", 2.0f); // disable after 2 seconds
    }

    private void SetFalseIndicateExit()  //exit indicate reminder off
    {
        IndicateExitWarn.SetActive(false);
    }
}


