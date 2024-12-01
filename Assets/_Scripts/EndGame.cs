using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public static GameObject endGameScreen; 
    private static bool _isGameOver = false;

    public static void TriggerEndGame()
    {
        _isGameOver = true;
        GameManager.Instance.Health = GameManager.DEFAULT_HEALTH;
        GameManager.Instance.Score = 0;
        SceneManager.LoadScene("GameOverScene");
        UIManager.Instance.ClearStats();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("LostLarry"); 
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("TitleScene"); 
    }
}
