using UnityEngine;

public class CreatureAI : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float minSpeed = 1f;
    [SerializeField] private float maxChaseDistance = 10f;
    [SerializeField] private float minChaseDistance = 5f;

    [SerializeField] private Transform playerTransform;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, playerTransform.position);

        float speed = Mathf.Lerp(minSpeed, maxSpeed, Mathf.InverseLerp(minChaseDistance, maxChaseDistance, distance));
        rb.velocity = direction * speed;
    }

    // private void OnTriggerEnter2D(Collider2D c){
    //     if (c.gameObject.tag == "Player"){
    //         GameManager.Instance.DecreaseHealth(1);
    //     }
    // }
}