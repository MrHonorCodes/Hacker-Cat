using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PlayMenu;
    public GameObject StatsMenu;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayButton()
    {
        // Show Levels
        MainMenu.SetActive(false);
        PlayMenu.SetActive(true);
        StatsMenu.SetActive(false);
    }



    public void Level2Button()
    {
        // Play  Button has been pressed, Load Scene Level2
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }
    
    public void Level1Button()
    {
        // Play  Button has been pressed, Load Scene Level1
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1_Dog");
    }

    public void Level3Button()
    {
        // Play  Button has been pressed, Load Scene Level3
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level3_Lion");
    }

    public void Level4Button()
    {
        // Play  Button has been pressed, Load Scene Level4
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level4_Chicken");
    }

    public void Level5Button()
    {
        // Play  Button has been pressed, Load Scene Level5
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level5_Cat");
    }

    public void FinalLevelButton()
    {
        // Play  Button has been pressed, Load Scene FinalLevel
        UnityEngine.SceneManagement.SceneManager.LoadScene("FinalBoss");
    }

    public void StatsButton()
    {
        // Show Stats Menu
        MainMenu.SetActive(false);
        PlayMenu.SetActive(false);
        StatsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        MainMenu.SetActive(true);
        PlayMenu.SetActive(false);
        StatsMenu.SetActive(false);
    }

    public void ExitButton()
    {
        // Exit Game
        Application.Quit();
    }
}