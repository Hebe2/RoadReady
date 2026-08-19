using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the moving car obstacles and it controls how the car is moving
public class MovingCar : MonoBehaviour
{
   //these are the settings for the moving car
   public float speed;
   Vector3 targetPos;
   public GameObject ways;
   public Transform[] wayPoints;
   int pointIndex;
   int pointCount;
   int direction = 1;
   
private void Awake() 
   {
        wayPoints = new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
   }

   private void Start() //set the values for the moving cars
   {
        pointCount = wayPoints.Length;
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;
   }

   private void Update() //car moves
   {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if(transform.position == targetPos)
        {
            NextPoint();
        }
   }

   void NextPoint() //makes sure the moving car continues to go the next point
   {
        if(pointIndex == 0) 
        {
            direction = 1;
        }

        pointIndex += direction;
     //    targetPos = wayPoints[pointIndex].transform.position;

        if (pointIndex >= 0 && pointIndex < pointCount)
    {
        targetPos = wayPoints[pointIndex].position;
    }
   }

   
}

