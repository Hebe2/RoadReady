using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//this script is for the gameover page and what will happen if the button is pressed 
public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;//the gameover page
    [SerializeField] Button _restart;//the button

    private void Start() //notify the system when button is clicked and run Restart()
    {
        _restart.onClick.AddListener(Restart); 
    }

    public void Restart() //restart the game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1; //start the game
    }
}
