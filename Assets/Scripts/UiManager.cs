using UnityEngine;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject gameWonPanel;
    [SerializeField] private GameObject gameLostPanel;


    private void Awake()
    {
        if (gameWonPanel.activeSelf)
        {
            gameWonPanel.SetActive(false);
        }
        if(gameLostPanel.activeSelf)
        {
            gameLostPanel.SetActive(false);
        }
    }

    public void GameWon()
    {
        gameWonPanel.SetActive(true);
    }
    public void GameLost()
    {
        gameLostPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Exit()
    {
        Debug.Log("Game Was Quit!");
        Application.Quit();
    }
}
