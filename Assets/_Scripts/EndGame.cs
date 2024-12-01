using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject endGameScreen; 
    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver && GameManager.Instance.Health <= 0)
        {
            TriggerEndGame();
        }
    }

    private void TriggerEndGame()
    {
        isGameOver = true;
        endGameScreen.SetActive(true); 
        Time.timeScale = 0f; 

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }
}
