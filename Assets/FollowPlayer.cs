using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;

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
        Vector3 _targetPosition = new Vector3(_followTarget.position.x,
                                                _followTarget.position.y,
                                                transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, 0);
    }
}
