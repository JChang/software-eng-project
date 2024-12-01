using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetY;
    [SerializeField][Range(0.1f, 10f)] private float _smoothFactor = 0.5f;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 _targetPosition = new Vector3(_followTarget.position.x + _offsetX, 
                                                _followTarget.position.y + _offsetY, 
                                                transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, _smoothFactor);
    }
}