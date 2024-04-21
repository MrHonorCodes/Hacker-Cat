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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ReturnToTitleButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}