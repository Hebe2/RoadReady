using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script is for the players controls of the car, what key they press will move the car.
public class TopDownCarController : MonoBehaviour
{
  [Header ("Car Settings")] //car settings, public so i can edit in unity
   public float accelerationFactor = 30.0f; //how fast the car will accelerate when we press accelerate button
   public float turnFactor = 3.5f; // how fast the car will turn when changed direction
   public float driftFactor = 0.95f;
   public float maxSpeed = 20;


   //local variables for the car
   private float accelerationInput = 0;
   private float steeringInput = 0;
   private float velocityVsUp = 0;

   //components
   private Rigidbody2D carRigidbody2D;

   //Awake is called when the scipt instance is being loaded.t
   void Awake()
   {
      carRigidbody2D = GetComponent<Rigidbody2D>();
   }


  //Frame-rate Independent for physics calculations.
  void FixedUpdate()
  {
      ApplyEngineForce();
      ApplySteering();
      KillOrthogonalVelocity();
  }


    void ApplyEngineForce() // this function is for how the car moves and what happens if the car gets to the max speed etc
  {
      //Calculate how much "forward" we are going in terms of the direction of our velocity
      velocityVsUp = Vector2.Dot(transform.up, carRigidbody2D.velocity);


      //limit so we cannot go faster than the max speed in the "forward" direction
      if (velocityVsUp > maxSpeed && accelerationInput > 0)
          return;


      //limit so we cannot go faster than the 50% of max speed in the "reverse" direction
      if (velocityVsUp < -maxSpeed * 0.5f && accelerationInput < 0)
          return;
    
      //limit so we cannot go faster in the any direction while accerlerating
      if (carRigidbody2D.velocity.sqrMagnitude > maxSpeed * maxSpeed && accelerationInput > 0)
          return;


      //Apply drag if there is no acclerationInput so the car stops when the player lets go of the accelerator
      if (accelerationInput == 0)
          carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag, 1.5f, Time.fixedDeltaTime * 3);
      else carRigidbody2D.drag = 0;


      // Create a force for the engine
      Vector2 engineForceVector = transform.up * accelerationInput * accelerationFactor;


      // Apply force and push the car forward
      carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
  }



 
  void ApplySteering() // this function controls the turning/steering of the car
  {
      //Limit the cars ability to turn when moving slowly
      float minSpeedBeforeAllowTurningFactor = (carRigidbody2D.velocity.magnitude / 8);
      minSpeedBeforeAllowTurningFactor = Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);


      // Update the rotation angle based on input
      float rotationAmount = steeringInput * turnFactor * minSpeedBeforeAllowTurningFactor;
      carRigidbody2D.rotation -= rotationAmount;
  }

  public void SetInputVector(Vector2 inputVector) //this function is setting the acceleration and steering to the y and x axis
  {
      steeringInput = inputVector.x;
      accelerationInput = inputVector.y;
  }

 public void KillOrthogonalVelocity() //this functions prevents the player to not drift as much
  {
      Vector2 forwardVelocity = transform.up * Vector2.Dot(carRigidbody2D.velocity, transform.up);
      Vector2 rightVelocity = transform.right * Vector2.Dot(carRigidbody2D.velocity, transform.right);
      carRigidbody2D.velocity = forwardVelocity + rightVelocity * driftFactor;
  }
}


