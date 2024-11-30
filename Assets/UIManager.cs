using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text ScoreText;
    [SerializeField] TMPro.TMP_Text HealthText;

    public void UpdateScore(int score)
    {
        ScoreText.text = "Score: " + score;
    }

    public void UpdateHealth(int health)
    {
        HealthText.text = "Health: " + health;
    }
}
