using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script is for the end page when the player finished all 3 levels
public class EndMenu : MonoBehaviour
{
    [SerializeField] GameObject ENDMenu; //the end menu scene
    
    public void Home() //change scene to home page
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Levels()//change scene to levels menu
    {
        SceneManager.LoadScene("LevelMenu");  
    }

    public void Quit()//leave the game
    {
        Application.Quit();
    }
}
