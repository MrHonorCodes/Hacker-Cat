using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    [SerializeField] GameObject levelCompleteMenu;
        
    void Start()
    {

        LevelCompleteButton();
    }

    public void LevelCompleteButton()
    {
        levelCompleteMenu.SetActive(true);
    }

    public void NextLevelButton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // Get the current level from PlayerPrefs and add 1 to it
        int nextLevel = PlayerPrefs.GetInt("CurrentLevel") + 1;
        SceneManager.LoadScene(nextLevel);
    }

    public void RetryButton()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name); OLD CODE
        SceneManager.LoadScene(PlayerPrefs.GetInt("CurrentLevel"));

    }
    
    public void ReturnToTitleButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}