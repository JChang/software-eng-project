using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Vector2 _moveInput;

    private bool _facingRight = true;
    private bool _isInvincible = false;
    [SerializeField] private float _invincibilityDuration = 3f;
    private float _invincibilityTimer = 0f;

    private Rigidbody2D rb;
    [SerializeField] private GameManager GameManager;

    private Collider2D playerCollider;
    
    private ContactFilter2D contactFilter;

    private SpriteRenderer playerSprite;

    private int iframes = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerSprite = GetComponent<SpriteRenderer>();

        contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;
        contactFilter.SetLayerMask(LayerMask.GetMask("Default"));
        contactFilter.useLayerMask = true;

    }

    void Update()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.y = Input.GetAxis("Vertical");

        _moveInput.Normalize();

        if (_moveInput.x > 0 && !_facingRight || _moveInput.x < 0 && _facingRight)
        {
            Flip();
        }

        if (_isInvincible)
        {
            _invincibilityTimer -= Time.deltaTime;

            if (_invincibilityTimer <= 0f)
            {
                _isInvincible = false;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = _moveInput * _speed;
    }

    void Flip()
    {
        Vector2 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;

        _facingRight = !_facingRight;
    }

    private bool touchingCreature(){
        Collider2D[] allCollisions = new Collider2D[10];
        int count = playerCollider.OverlapCollider(contactFilter, allCollisions);

        for (int i = 0; i< count; i++){
            if (allCollisions[i].CompareTag("creature")){
                return true;
            }
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") && !_isInvincible)
        {
            GameManager.DecreaseHealth(1);
            _isInvincible = true;
            _invincibilityTimer = _invincibilityDuration;
        }

        if (collision.collider.CompareTag("Goal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_isInvincible)
        {
            GameManager.DecreaseHealth(1);
            _isInvincible = true;
            _invincibilityTimer = _invincibilityDuration;
        }

        if (collision.CompareTag("Goal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}