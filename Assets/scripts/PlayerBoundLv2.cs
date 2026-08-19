using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the players bounds for level 2
public class PlayerBoundLv2 : MonoBehaviour
{
        void Update()
    {
        if(transform.position.y >= 8.2f)//top 
        {
            transform.position = new Vector3(transform.position.x, 8.2f, 0);
        }
        else if(transform.position.y <= -17)//bottom
        {
            transform.position = new Vector3(transform.position.x, -17f, 0);
        }

        if(transform.position.x >= 20.2f)//right
        {
            transform.position = new Vector3(20.2f, transform.position.y, 0);
        }

        else if(transform.position.x <= -12)//left
        {
            transform.position = new Vector3(-12, transform.position.y, 0);
        }
    }
}
