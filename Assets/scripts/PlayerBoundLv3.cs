using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the players bounds for level 3
public class PlayerBoundLv3 : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y >= 25.5f)//top 
        {
            transform.position = new Vector3(transform.position.x, 25.5f, 0);
        }
        else if (transform.position.y <= -14.5f)//bottom
        {
            transform.position = new Vector3(transform.position.x, -14.5f, 0);
        }

        if (transform.position.x >= 14.1f)//right
        {
            transform.position = new Vector3(14.1f, transform.position.y, 0);
        }

        else if (transform.position.x <= -66.7f)//left
        {
            transform.position = new Vector3(-66.7f, transform.position.y, 0);
        }
 
    }
}
