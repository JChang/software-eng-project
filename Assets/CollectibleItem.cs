using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Coin : MonoBehaviour
{
    public int Value;
    public Gradient ColorGradient;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        float colorValue = (float)Value / 10f;
        Color coinColor = ColorGradient.Evaluate(colorValue);

        spriteRenderer.color = coinColor;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(Value);
            Destroy(gameObject);
        }
    }
}