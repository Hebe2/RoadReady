using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    // Reference to the TopDownCarController component
    public TopDownCarController carController;

    // Update is called once per frame
    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Set input vector for controlling the car
        Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        carController.SetInputVector(inputVector);
    }
}

