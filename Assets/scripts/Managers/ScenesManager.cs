using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//thi script is for managing the scenes, which is used for changing scenes from one to another
public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;
     
    private void Awake()
    {
        Instance = this;
    }

    public enum Scene //these are all the scenes
    {
        MainMenu,
        LevelMenu,
        PauseMenu,
        Level01,
        Level02,
        Level03
    }
    
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString()); 
    }

    public void LoadNewScene()// load next scene/level
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    } 

    public void LoadMainMenu()// load main menu
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString()); 
    }

     public void LoadLevelMenu()// load Level menu
    {
        SceneManager.LoadScene(Scene.LevelMenu.ToString()); 
    }

    public void LoadPauseMenu()// load Pause Menu
    {
        SceneManager.LoadScene(Scene.PauseMenu.ToString()); 
    }

    public void LoadBack()// load back
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

     public void LoadNewGame()// load level 1
    {
        SceneManager.LoadScene(Scene.Level01.ToString()); 
    } 

     public void LoadLevel2()// load Level 2
    {
        SceneManager.LoadScene(Scene.Level02.ToString()); 
    }

     public void LoadLevel3()// load Level 3
    {
        SceneManager.LoadScene(Scene.Level03.ToString()); 
    }

}
