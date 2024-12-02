using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public static GameObject endGameScreen; 
    private static bool _isGameOver = false;
    public static UIManager UIManager;

    public void Start()
    {
        
    }

    public static void TriggerEndGame()
    {
        _isGameOver = true;
        UIManager.Instance.HideStats();
        GameManager.Instance.Health = GameManager.DEFAULT_HEALTH;
        GameManager.Instance.Score = 0;
        SceneManager.LoadScene("GameOverScene");
        UIManager.Instance.ClearStats();
    }

    public void RestartGame()
    {
        UIManager.Instance.ShowStats();
        SceneManager.LoadScene("LostLarry"); 
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("TitleScene"); 
    }
}
