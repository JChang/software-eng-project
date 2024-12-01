using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Vector2 _moveInput;

    private bool _facingRight = true;

    private Rigidbody2D rb;

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
        // Get input
        _moveInput.x = Input.GetAxis("Horizontal");
        _moveInput.y = Input.GetAxis("Vertical");

        // Calculate movement direction
        _moveInput.Normalize();

        // Apply movement

        // Flip player sprite based on horizontal movement
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

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
