 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script is for all the buttons during the game play
public class UIGameMenu : MonoBehaviour
{
    //the buttons
    [SerializeField] Button _mainMenu;
    [SerializeField] Button _pause;

    void Start()//if button is clicked the load the scene so when clicked the function they run
    {
        _mainMenu.onClick.AddListener(LoadMainMenu);
        _pause.onClick.AddListener(LoadPauseMenu);
    }

    private void LoadMainMenu()//load main menu
    {
        ScenesManager.Instance.LoadMainMenu();
    }

    private void LoadPauseMenu() //load pause menu
    {
        ScenesManager.Instance.LoadPauseMenu();
    }
}
