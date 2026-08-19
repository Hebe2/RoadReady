using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the turning moving car on level 3
public class MovingCarLevel3 : MonoBehaviour
{
     //values for the car's setting
     public float speed = 5f;
     public float turnSpeed = 10f;
     Vector3 targetPos;
     public GameObject ways;
     public Transform[] wayPoints;
     int pointIndex;
     int pointCount;
     int direction = 1;
     float tiltAngle = 90f;



     private void Awake()
     {
          wayPoints = new Transform[ways.transform.childCount];
          for (int i = 0; i < ways.gameObject.transform.childCount; i++)
          {
               wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
          }
     }

     private void Start() //set the values at the start
     {
          pointCount = wayPoints.Length;
          pointIndex = 1;
          targetPos = wayPoints[pointIndex].transform.position;
     }
     private void Update() //move th ecar
     {
          var step = speed * Time.deltaTime;
          transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

          if (transform.position == targetPos) //if the car has arrived at it's target position
          {
               NextPoint();
          }
     }

     void NextPoint() //move to next point 
     {
          if (pointIndex == 0)
          {
               direction = 1;
          }
          if (pointIndex == 1)
          {
               Debug.Log("reached point 2");
               Turn();
          }

          if (pointIndex == pointCount - 1)
          {
               direction = 0;
          }

          pointIndex += direction;
          targetPos = wayPoints[pointIndex].transform.position;
     }

     void Turn() //turning for the blue car
     {
          // Smoothly tilts a transform towards a target rotation.
          float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle;

          // Rotate the cube by converting the angles into a quaternion.
          Quaternion target = Quaternion.Euler(0, tiltAroundY, 180);

          // Dampen towards the target rotation
          transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * turnSpeed);
     }
}
