using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TMPro.TMP_Text ScoreText;
    [SerializeField] TMPro.TMP_Text HealthText;

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void UpdateHealth(int health)
    {
        HealthText.text = "Health: " + health;
    }
}
