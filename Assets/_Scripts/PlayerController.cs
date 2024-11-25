using UnityEngine;
// test comment - srin 11/25
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private bool _facingRight = true;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float _horizontalMovement = Input.GetAxis("Horizontal");
        float _verticalMovement = Input.GetAxis("Vertical");
        Vector2 _directionX = (Vector2.right * _horizontalMovement);
        Vector2 _directionY = (Vector2.up * _verticalMovement);

        transform.Translate(_directionX * _speed * Time.deltaTime);
        transform.Translate(_directionY * _speed * Time.deltaTime);

        if (_horizontalMovement > 0 && !_facingRight || _horizontalMovement < 0 && _facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector2 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        _facingRight = !_facingRight;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}