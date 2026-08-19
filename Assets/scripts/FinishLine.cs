using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// this script is for the finish line which is what will happen after the player cross the finish line
public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) // when the player triggers the finish line by going over it
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    private IEnumerator ChangeSceneAfterDelay() //load scene after 1 second
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(1);

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
}
