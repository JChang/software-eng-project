using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TMPro.TMP_Text ScoreText;
    [SerializeField] TMPro.TMP_Text HealthText;
    [SerializeField] TMPro.TMP_Text TimeText;

    public static UIManager Instance { get; private set; }
    private float elapsedTime = 0f;

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

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        UpdateTime();
    }

    public void UpdateScore(int score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void UpdateHealth(int health)
    {
        HealthText.text = "Health: " + health;
    }

    public void UpdateTime()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        TimeText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }

    public void ClearStats() {
        HealthText.text = "";
        ScoreText.text = "";
        ScoreText.text = "";
    }

    public void HideStats()
    {
        HealthText.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(false);
        TimeText.gameObject.SetActive(false);
    }

    public void ShowStats()
    {
        HealthText.gameObject.SetActive(true);
        ScoreText.gameObject.SetActive(true);
        TimeText.gameObject.SetActive(true);
        elapsedTime = 0f;
    }
}
