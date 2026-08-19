using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this script is about all the buttons for the levels menu
public class UILevelMenu : MonoBehaviour
{
    //these are all the buttons
    [SerializeField] Button _mainMenu;
    [SerializeField] Button _level1;
    [SerializeField] Button _level2;
    [SerializeField] Button _level3;
  

    private void Start()//listen to all the button actions(click) so when clicked the function they run
    {
        _mainMenu.onClick.AddListener(LoadMainMenu);
        _level1.onClick.AddListener(Level1);
        _level2.onClick.AddListener(Level2);
        _level3.onClick.AddListener(Level3);
    }

    private void LoadMainMenu()//load main menu
    {
        ScenesManager.Instance.LoadMainMenu();
    }

    private void Level1()//change to level 1
    {
        ScenesManager.Instance.LoadNewGame();
    }

    private void Level2() //change to level 2
    {
        ScenesManager.Instance.LoadLevel2();
    }

    private void Level3() //change to level 3
    {
        ScenesManager.Instance.LoadLevel3();
    }

   
} 

 