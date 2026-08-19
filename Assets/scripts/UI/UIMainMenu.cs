using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script is for all the buttons for the main menu
public class UIMainMenu : MonoBehaviour
{
    //buttons
    [SerializeField] Button _newGame;
    [SerializeField] Button _levels;
    [SerializeField] Button _quit;

    private void Start() //listen to all the button actions(click) so when clicked the function they run
    {
        _newGame.onClick.AddListener(StartNewGame);
        _levels.onClick.AddListener(LoadLevelMenu);
        _quit.onClick.AddListener(Quit);
    }

    private void StartNewGame() //load the game
    {
        ScenesManager.Instance.LoadNewGame();
    }

    private void LoadLevelMenu() //change the levels menu
    {
        ScenesManager.Instance.LoadLevelMenu();
    }

    private void Quit() //quit the game
    {
        Application.Quit();
    }
} 
 