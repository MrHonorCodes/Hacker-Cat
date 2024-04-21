using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseGameMenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseGameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseGameMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseGameMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void ReturnToTitleButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
}