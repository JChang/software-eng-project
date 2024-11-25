using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _offsetX;
    [SerializeField][Range(0.1f, 10f)] private float _smoothFactor = 0.5f;

    [SerializeField] private float _minXLimit = -3f;
    [SerializeField] private float _maxXLimit = 5f;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        float targetX = Mathf.Clamp(_followTarget.position.x + _offsetX, _minXLimit, _maxXLimit);
        Vector3 _targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, _smoothFactor);
    }
}