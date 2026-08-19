using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script is for whatever button the player clicks when the pause menu is up
public class PauseMenu : MonoBehaviour
{
    //the pause menu
    [SerializeField] GameObject pauseMenu;

    public void Pause() //pause the game and the menu pops up
    {
        pauseMenu.SetActive(true);//open pause menu
        Time.timeScale = 0; //stop the game
    }

    public void Home() //change scene to home page
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1; //start the game
    }

    public void Resume() //resume the game
    {
        pauseMenu.SetActive(false);//close pause menu
        Time.timeScale = 1; //start the game
    }

    public void Restart() //restart the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1; //start the game
    }

    public void Levels() //change scene to levels menu
    {
        SceneManager.LoadScene("LevelMenu");
        Time.timeScale = 1;
    }

    public void Quit() //quit the game
    {
        Application.Quit();
    }
}
