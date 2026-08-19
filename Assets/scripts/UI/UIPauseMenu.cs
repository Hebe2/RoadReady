using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] Button _mainMenu;
    [SerializeField] Button _levels;

    private void Start() //listen to all the button actions(click) so when clicked the function they run
    {
        _mainMenu.onClick.AddListener(LoadMainMenu);
        _levels.onClick.AddListener(LoadLevelMenu);
    }

     private void LoadMainMenu() // change to main menu
    {
        ScenesManager.Instance.LoadMainMenu();
    }

     private void LoadLevelMenu() //change to levels menu
    {
        ScenesManager.Instance.LoadLevelMenu();
    }
}
