using UnityEngine;

public class CreatureAI : MonoBehaviour
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxChaseDistance;
    [SerializeField] private float _minChaseDistance;
    [SerializeField] private float _difficultyScaler;

    [SerializeField] private Transform playerTransform;
    private Rigidbody2D rb;

    [SerializeField] private GameManager gameManager;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, playerTransform.position);

        float speed = Mathf.Lerp(_minSpeed, _maxSpeed, Mathf.InverseLerp(_minChaseDistance, _maxChaseDistance, distance));
        rb.velocity = direction * speed;
        _maxSpeed = _maxSpeed + (float)(_difficultyScaler * gameManager.Score)/2;
        _minSpeed = _minSpeed + (float)(_difficultyScaler * gameManager.Score)/2;
    }

    // private void OnTriggerEnter2D(Collider2D c){
    //     if (c.gameObject.tag == "Player"){
    //         GameManager.Instance.DecreaseHealth(1);
    //     }
    // }
}