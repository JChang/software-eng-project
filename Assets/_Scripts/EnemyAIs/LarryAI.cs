using UnityEngine;

public class LarryAI : MonoBehaviour
{
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDistance;
    [SerializeField] private float pauseTime;
    [SerializeField] private float _difficultyScaler;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float pauseTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        gameManager = FindObjectOfType<GameManager>();
        pauseTimer = pauseTime;
    }

    void Update()
    {
        if (!isDashing)
        {
            pauseTimer -= Time.deltaTime;
            if (pauseTimer <= 0f)
            {
                isDashing = true;
                dashTimer = 0f;
                Vector2 direction = (playerTransform.position - transform.position).normalized;
                rb.velocity = direction * dashSpeed;
            }
            dashSpeed = dashSpeed + (float)(gameManager.Score * _difficultyScaler);
        }
        else
        {
            dashTimer += Time.deltaTime;

            if (dashTimer >= dashDistance / dashSpeed)
            {
                isDashing = false;
                dashTimer = 0f;
                pauseTimer = pauseTime;
            }
        }
    }
}