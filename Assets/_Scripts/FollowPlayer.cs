using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 _targetPosition = new Vector3(_followTarget.position.x,
                                                _followTarget.position.y,
                                                transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, 0);
    }
}
