using UnityEngine;

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

        // Flip player sprite to match horizontal movement
        if (_moveInput.x > 0 && !_facingRight || _moveInput.x < 0 && _facingRight)
        {
            Flip();
        }

        if (touchingCreature() && iframes == 0){
            GameManager.Instance.DecreaseHealth(1);
            iframes = 1000;
        }

        if (iframes > 0){
            iframes--;
            playerSprite.color = Color.red;
        }
        else{
            playerSprite.color = Color.white;
        }
    }

    private void FixedUpdate()
    {
        // apply movement based on calculated user input
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_isInvincible)
        {
            GameManager.DecreaseHealth(1);
            _isInvincible = true;
            _invincibilityTimer = _invincibilityDuration;
        }
    }
}