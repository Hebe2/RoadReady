using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the updating instuction box of level 3
public class PopUp : MonoBehaviour
{
    //these are the three instructions
    [SerializeField] GameObject Left;
    [SerializeField] GameObject Straight;
    [SerializeField] GameObject Right;

    private void OnTriggerEnter2D(Collider2D collision) //when the player triggers the done zone from the task before
    {
        if (collision.gameObject.name == "LeftTurnDone")
        {
            StraightInstruction();
        }

        if (collision.gameObject.name == "StraightDone")
        {
            RightInstruction();
        }
    }

    private void StraightInstruction() //change to straight instuction and make the other two disappear if they somehow appear
    {
        Left.SetActive(false);
        Straight.SetActive(true);
        Right.SetActive(false);

    }

    private void RightInstruction() //change to right instuction and make the other two disappear if they somehow appear
    {
        Left.SetActive(false);
        Straight.SetActive(false);
        Right.SetActive(true);

    }
}
