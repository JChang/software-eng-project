using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Vector2 _moveInput;

    private bool _facingRight = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
