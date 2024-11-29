using UnityEngine;

public class LarryAI : MonoBehaviour
{
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private float pauseTime = 2f;

    [SerializeField] private Transform playerTransform;
    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float pauseTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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