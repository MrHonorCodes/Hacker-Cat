using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    [SerializeField] GameObject endGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        EndGameButton();
    }

    public void EndGameButton()
    {
        // Show End Game Menu
        endGameMenu.gameObject.SetActive(true);
    }

    public void RetryButton()
    {
        //SceneManager.LoadScene(sceneID);
    }

    public void ReturnToTitleButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}