using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// what is the script for and what does it do in general?
// This script is for all the collision that is expected to happen and what warnings, reminders or gameover will pop up.

public class CollisonController : MonoBehaviour
{

    // what are all of these, not individially, but as a group
    //These SerializedField are all the warnings, reminders and gameovers that will pop up after a collision has happened,which they'll be assigned in the inspector
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject edge;
    [SerializeField] GameObject BackOnTrack;
    [SerializeField] GameObject roundabout;
    [SerializeField] GameObject WrongWay;
    [SerializeField] GameObject OffCourse;



    // what does this function do, what are the parameters that it takes and what does it return/do at the end?
    private void OnCollisionEnter2D(Collision2D collision)//This function is when the player is entering a collision with a 2D collider
    {
        if (collision.gameObject.tag == "obstacle") //if player collide with gameobjects that are tagged as obstacles
        {
            GameOverpage();
        }

        if (collision.gameObject.tag == "off") //if player collide with gameobjects that are tagged as off
        {
            OffCourseWarning();
        }

        if (collision.gameObject.tag == "roundabout")//if player collide with gameobjects that are tagged as roundabout
        {
            RoundaboutWarning();
        }
    }

    private void OnCollisionExit2D(Collision2D collision) //This function is when the player is entering a collision with a 2D collider
    { 
        if (collision.gameObject.tag == "off")  //if player exited collision with gameobjects that are tagged as off
        {
            OffCourseWarningOFF(); 
        }

        if (collision.gameObject.tag == "roundabout") //if player exited collision with gameobjects that are tagged as roundabout
        {
            RoundaboutWarningOFF();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //This function is when the player is entering a collision with a 2D collider which is set to isTrigger
    {
        if (collision.tag == "edge") //if player triggers gameobjects that are tagged as edge
        {
            EdgeWarning();
        }

        if (collision.tag == "oppositeRoad") //if player triggers gameobjects that are tagged as oppositeRoad
        {
            BackOnTrackWarning();
        }

        if (collision.tag == "WrongWay") //if player triggers gameobjects that are tagged as WrongWay
        {
            WrongWayWarning();
        }

    }

    private void OnTriggerExit2D(Collider2D collision) //This function is when the player is exiting a collision with a 2D collider which is set to isTrigger
    {
        if (collision.tag == "WrongWay") //if player exit triggered gameobjects that are tagged as WrongWay
        {
            WrongWayWarningFalse();
        }
    }



    private void GameOverpage() //This function will make the gameover page pop up and stop the game
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    private void EdgeWarning() //This function will make the edge warning pop up and go away after 2s
    {
        edge.SetActive(true);
        Invoke("SetFalseEdge", 2.0f); 
    }

    private void BackOnTrackWarning() //This function will make the Back on Track warning pop up and go away after 2s
    {
        BackOnTrack.SetActive(true);
        Invoke("SetFalseTrackWarning", 2.0f); 
    }

    private void RoundaboutWarning() //This function will make the Roundabout warning pop up
    {
        roundabout.SetActive(true);
    }

    private void OffCourseWarning() //This function will make the offcourse warning pop up
    {
        OffCourse.SetActive(true);
    }

    private void WrongWayWarning() //This function will make the Wrongway warning pop up
    {
        WrongWay.SetActive(true);
    }

    private void WrongWayWarningFalse() //This function will make the Wrongway warning go away
    {
        WrongWay.SetActive(false);
    }

    private void OffCourseWarningOFF() //This function will make the Offcourse warning go away
    {
        if (OffCourse != null) // Check if the object is not null
        {
            OffCourse.SetActive(false);
        }
    }

    private void RoundaboutWarningOFF() //This function will make the Roundabout warning go away
    {
        roundabout.SetActive(false);
    }

    private void SetFalseEdge() //This function will make the edge warning go away
    {
        edge.SetActive(false);
    }

    private void SetFalseTrackWarning() //This function will make the BackOnTrack warning go away
    {
        BackOnTrack.SetActive(false);
    }
}






