using UnityEngine;

public class JamesAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDistance;
    [SerializeField] private float pauseTime;
    [SerializeField] private float _difficultyScaler;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform lightTransform;
    [SerializeField] private Collider2D lightCollider;

    [SerializeField] private GameManager gameManager;

    private Rigidbody2D rb;
    private bool isDashing = false;
    private float dashTimer = 0f;
    private float pauseTimer = 0f;
    private bool isInLight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        gameManager = FindObjectOfType<GameManager>();
        GameObject lightObject = GameObject.FindGameObjectWithTag("Light");
        lightTransform = lightObject.transform;
        lightCollider = lightObject.GetComponent<Collider2D>();
        pauseTimer = pauseTime;
    }

    void Update()
    {
        if (isDashing)
        {
            HandleDashing();
        }
        else if (isInLight)
        {
            StartDashing();
        }
        else
        {
            MoveTowardLight();
        }
    }

    private void MoveTowardLight()
    {
        Vector2 directionToLight = (lightTransform.position - transform.position).normalized;
        rb.velocity = directionToLight * moveSpeed;
    }

    private void StartDashing()
    {
        pauseTimer -= Time.deltaTime;
        if (pauseTimer <= 0f)
        {
            isDashing = true;
            dashTimer = 0f;

            Vector2 directionToPlayer = (playerTransform.position - transform.position).normalized;
            rb.velocity = directionToPlayer * dashSpeed;
        }
        if (moveSpeed < 15)
        {
            moveSpeed = moveSpeed + (float)(_difficultyScaler * gameManager.Score);
            dashSpeed = moveSpeed + (float)(_difficultyScaler * gameManager.Score);
        }
    }

    private void HandleDashing()
    {
        dashTimer += Time.deltaTime;

        if (dashTimer >= dashDistance / dashSpeed)
        {
            isDashing = false;
            dashTimer = 0f;
            pauseTimer = pauseTime;

            rb.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == lightCollider)
        {
            isInLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == lightCollider)
        {
            isInLight = false;
        }
    }
}
