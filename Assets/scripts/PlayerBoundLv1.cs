using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the players bounds for level 1
public class PlayerBoundLv1 : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y >= 18.2f)//top 
        {
            transform.position = new Vector3(transform.position.x, 18.2f, 0);
        }
        else if(transform.position.y <= -17.9f)//bottom
        {
            transform.position = new Vector3(transform.position.x, -17.9f, 0);
        }

        if(transform.position.x >= 7.3f)//right
        {
            transform.position = new Vector3(7.3f, transform.position.y, 0);
        }

        else if(transform.position.x <= -13.4f)//left
        {
            transform.position = new Vector3(-13.4f, transform.position.y, 0);
        }
    }
}
